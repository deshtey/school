'use client';

import { useState, useCallback, useMemo } from 'react';
import {
  ColumnDef,
  flexRender,
  getCoreRowModel,
  getPaginationRowModel,
  getSortedRowModel,
  useReactTable,
  SortingState,
} from '@tanstack/react-table';
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import { CaretSortIcon } from "@radix-ui/react-icons";

import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { Label } from "@/components/ui/label";
import { Plus as IconPlus } from 'lucide-react';

// Define a generic type for your entity data
export type Entity = Record<string, any>;

interface Props<T extends Entity> {
  data: T[];
  columns: ColumnDef<T>[];
  filterOptions?: {
    [key: string]: {
      label: string;
      options: { value: string; label: string }[];
      onFilter: (value: string, data: T[]) => T[];
    };
  };
  onView?: (entityId: string) => void;
  onDelete?: (entityId: string) => void;
  onAdd?: () => void;
  entityName: string; // e.g., "student", "teacher", "class" for better context
  idKey: keyof T; // The key that uniquely identifies each entity
}

export function EntityTable<T extends Entity>({
  data,
  columns,
  filterOptions,
  onView,
  onDelete,
  onAdd,
  entityName,
  idKey,
}: Props<T>) {
  const [sorting, setSorting] = useState<SortingState>([]);
  const [globalFilter, setGlobalFilter] = useState('');
  const [columnFilters, setColumnFilters] = useState<{
    [columnId: string]: string;
  }>({});

  const table = useReactTable({
    data,
    columns,
    getCoreRowModel: getCoreRowModel(),
    getPaginationRowModel: getPaginationRowModel(),
    getSortedRowModel: getSortedRowModel(),
    state: {
      sorting,
      globalFilter,
      // columnFilters,
    },
    onSortingChange: setSorting,
    onGlobalFilterChange: setGlobalFilter,
  });

  const handleColumnFilterChange = useCallback(
    (columnId: string, value: string) => {
      setColumnFilters((prev) => ({ ...prev, [columnId]: value }));
    },
    []
  );

  const filteredData = useMemo(() => {
    let filtered = [...data];

    // Apply global filter
    if (globalFilter) {
      filtered = filtered.filter((row) =>
        Object.values(row).some((value) =>
          String(value).toLowerCase().includes(globalFilter.toLowerCase())
        )
      );
    }

    // Apply column-specific filters
    for (const columnId in columnFilters) {
      const filterValue = columnFilters[columnId];
      if (filterValue) {
        filtered = filtered.filter((row) =>
          String(row[columnId]).toLowerCase().includes(filterValue.toLowerCase())
        );
      }
    }

    // Apply custom filter options if provided
    if (filterOptions) {
      for (const filterKey in filterOptions) {
        const filterValue = columnFilters[filterKey];
        const filterConfig = filterOptions[filterKey];
        if (filterValue && filterConfig.onFilter) {
          filtered = filterConfig.onFilter(filterValue, filtered);
        }
      }
    }

    return filtered;
  }, [data, globalFilter, columnFilters, filterOptions]);

  const rowCount = filteredData.length;
  const pageCount = Math.ceil(rowCount / table.getState().pagination.pageSize);

  return (
    <div className="space-y-4">
      <div className="flex items-center justify-between">
        <h2 className="text-xl font-semibold capitalize">{entityName} List</h2>
        {onAdd && (
          <Button onClick={onAdd}>
            <IconPlus className="mr-2 h-4 w-4" />
            Add {entityName}
          </Button>
        )}
      </div>

      <div className="flex items-center space-x-4">
        <Input
          placeholder={`Filter ${entityName}s...`}
          value={globalFilter ?? ''}
          onChange={(e) => setGlobalFilter(e.target.value)}
          className="w-1/3"
        />

        {filterOptions &&
          Object.entries(filterOptions).map(([key, config]) => (
            <div key={key}>
              <Label htmlFor={`filter-${key}`} className="block text-sm font-medium">
                {config.label}
              </Label>
              <Select
                value={columnFilters[key] ?? ''}
                onValueChange={(value) => handleColumnFilterChange(key, value)}
              >
                <SelectTrigger id={`filter-${key}`}>
                  <SelectValue placeholder="All" />
                </SelectTrigger>
                <SelectContent>
                  <SelectItem value="-">All</SelectItem>
                  {config.options.map((option) => (
                    <SelectItem key={option.value} value={option.value}>
                      {option.label}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>
          ))}
      </div>

      <div className="rounded-md border">
        <Table>
          <TableHeader>
            {table.getHeaderGroups().map((headerGroup) => (
              <TableRow key={headerGroup.id}>
                {headerGroup.headers.map((header) => {
                  const isSortable = header.column.columnDef.enableSorting !== false;
                  return (
                    <TableHead 
                      key={header.id} 
                      className={isSortable ? 'cursor-pointer' : ''}
                      onClick={isSortable ? () => header.column.toggleSorting() : undefined}
                    >
                      {header.isPlaceholder ? null : (
                        <div className="flex items-center gap-1">
                          {flexRender(header.column.columnDef.header, header.getContext())}
                          {isSortable && (
                            <CaretSortIcon
                              className="h-4 w-4"
                            />
                          )}
                        </div>
                      )}
                    </TableHead>
                  );
                })}
                {(onView || onDelete) && <TableHead className="text-right">Actions</TableHead>}
              </TableRow>
            ))}
          </TableHeader>
          <TableBody>
            {table.getRowModel().rows.length > 0 ? (
              table.getRowModel().rows.map((row) => (
                <TableRow key={row.id}>
                  {row.getVisibleCells().map((cell) => (
                    <TableCell key={cell.id}>
                      {flexRender(cell.column.columnDef.cell, cell.getContext())}
                    </TableCell>
                  ))}
                  {(onView || onDelete) && (
                    <TableCell className="text-right">
                      <div className="flex justify-end gap-2">
                        {onView && (
                          <Button size="sm" variant="outline" onClick={() => onView(String(row.original[idKey]))}>
                            View
                          </Button>
                        )}
                        {onDelete && (
                          <Button size="sm" variant="destructive" onClick={() => onDelete(String(row.original[idKey]))}>
                            Delete
                          </Button>
                        )}
                      </div>
                    </TableCell>
                  )}
                </TableRow>
              ))
            ) : (
              <TableRow>
                <TableCell colSpan={columns.length + (onView || onDelete ? 1 : 0)} className="h-24 text-center">
                  No {entityName}s found.
                </TableCell>
              </TableRow>
            )}
          </TableBody>
        </Table>
      </div>

      {rowCount > 0 && (
        <div className="flex items-center justify-between">
          <div className="flex items-center space-x-2">
            <Label htmlFor="rows-per-page" className="text-sm">
              Rows per page:
            </Label>
            <Select
              value={table.getState().pagination.pageSize.toString()}
              onValueChange={(value) => {
                table.setPageSize(Number(value));
              }}
            >
              <SelectTrigger id="rows-per-page" className="w-16">
                <SelectValue placeholder={table.getState().pagination.pageSize} />
              </SelectTrigger>
              <SelectContent>
                {[10, 20, 50].map((pageSize) => (
                  <SelectItem key={pageSize} value={pageSize.toString()}>
                    {pageSize}
                  </SelectItem>
                ))}
              </SelectContent>
            </Select>
          </div>
          <div className="flex items-center space-x-2">
            <Button
              variant="outline"
              size="sm"
              onClick={() => table.previousPage()}
              disabled={!table.getCanPreviousPage()}
            >
              Previous
            </Button>
            <span className="text-sm">
              {table.getState().pagination.pageIndex + 1} of {pageCount}
            </span>
            <Button
              variant="outline"
              size="sm"
              onClick={() => table.nextPage()}
              disabled={!table.getCanNextPage()}
            >
              Next
            </Button>
          </div>
        </div>
      )}
    </div>
  );
}

// Example usage:
interface School {
  schoolId: string;
  name: string;
  location: string;
  phone: string;
  city: string;
  createdAt: Date;
  status: 'active' | 'inactive';
}

const schoolColumns: ColumnDef<School>[] = [
  {
    accessorKey: 'name',
    header: 'School Name',
  },
  {
    accessorKey: 'location',
    header: 'Location',
  },
  {
    accessorKey: 'city',
    header: 'City',
  },
  {
    accessorKey: 'phone',
    header: 'Phone',
  },
  {
    accessorKey: 'createdAt',
    header: 'Created At',
    cell: ({ row }) => new Date(row.getValue('createdAt')).toLocaleDateString(),
    enableSorting: true,
  },
  {
    accessorKey: 'status',
    header: 'Status',
    cell: ({ row }) => {
      const status = row.getValue('status');
      return (
        <span className={`inline-flex rounded-full px-2 py-1 text-xs font-semibold ${
          status === 'active' ? 'bg-green-100 text-green-800' : 'bg-yellow-100 text-yellow-800'
        }`}>
          {/* {status} */}
        </span>
      );
    },
    filterFn: (row, id, value) => value === 'all' || row.getValue(id) === value,
    enableSorting: true,
  },
];

const statusFilterOptions = {
  status: {
    label: 'Status',
    options: [
      { value: 'active', label: 'Active' },
      { value: 'inactive', label: 'Inactive' },
    ],
    onFilter: (value: string, data: School[]) =>
      value === 'all' ? data : data.filter((school) => school.status === value),
  },
};

const ExampleSchoolList = () => {
  const [schools, setSchools] = useState<School[]>([
    { schoolId: '1', name: 'School A', location: 'Nairobi', phone: '123', city: 'Nairobi', createdAt: new Date(), status: 'active' },
    { schoolId: '2', name: 'School B', location: 'Mombasa', phone: '456', city: 'Mombasa', createdAt: new Date(), status: 'inactive' },
    // ... more schools
  ]);

  const handleViewSchool = (id: string) => {
    console.log('View school:', id);
  };

  const handleDeleteSchool = (id: string) => {
    setSchools(schools.filter((school) => school.schoolId !== id));
    console.log('Delete school:', id);
  };

  const handleAddSchool = () => {
    console.log('Add new school');
  };

  return (
    <EntityTable
      data={schools}
      columns={schoolColumns}
      onView={handleViewSchool}
      onDelete={handleDeleteSchool}
      onAdd={handleAddSchool}
      entityName="school"
      idKey="schoolId"
      filterOptions={statusFilterOptions}
    />
  );
};

export default ExampleSchoolList;