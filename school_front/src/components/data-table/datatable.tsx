
import React, { useState, useMemo } from "react";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import {
  Table,
  TableHeader,
  TableBody,
  TableHead,
  TableRow,
  TableCell,
} from "@/components/ui/table";
import { Skeleton } from "@/components/ui/skeleton";
import { ExternalLink, ArrowUpDown, Search, X } from "lucide-react";
import { useRouter } from "next/navigation";

export interface Column<T> {
  header: string;
  accessorKey: keyof T;
  cell?: (row: T) => React.ReactNode;
  sortable?: boolean;
  enableLink?: boolean;
  linkPath?: string;
}

interface DataTableProps<T> {
  data: T[];
  columns: Column<T>[];
  isLoading?: boolean;
  searchable?: boolean;
  linkPath?: string;
  detailsPath?: string;
  idField?: keyof T;
}

export function DataTable<T extends Record<string, any>>({
  data,
  columns,
  isLoading = false,
  searchable = true,
  detailsPath = "",
  idField = "id",
}: DataTableProps<T>) {
  const [sortBy, setSortBy] = useState<{
    column: keyof T | null;
    direction: "asc" | "desc";
  }>({ column: null, direction: "asc" });
  const [searchTerm, setSearchTerm] = useState("");
  const router = useRouter();

  const handleSort = (column: keyof T) => {
    if (sortBy.column === column) {
      setSortBy({
        column,
        direction: sortBy.direction === "asc" ? "desc" : "asc",
      });
    } else {
      setSortBy({ column, direction: "asc" });
    }
  };

  const handleRowClick = (id: string | number) => {
    if (detailsPath) {
        //router.push(`${detailsPath}/${id}`);
    }
  };

  const filteredData = useMemo(() => {
    if (!searchTerm) return data;

    return data.filter((item) => {
      return columns.some((column) => {
        const value = item[column.accessorKey];
        if (value === null || value === undefined) return false;
        return String(value).toLowerCase().includes(searchTerm.toLowerCase());
      });
    });
  }, [data, searchTerm, columns]);

  const sortedData = useMemo(() => {
    if (!sortBy.column) return filteredData;

    return [...filteredData].sort((a, b) => {
      const aValue = a[sortBy.column as keyof T];
      const bValue = b[sortBy.column as keyof T];

      if (aValue === null || aValue === undefined) return 1;
      if (bValue === null || bValue === undefined) return -1;

      // Handle string comparison
      if (typeof aValue === "string" && typeof bValue === "string") {
        return sortBy.direction === "asc"
          ? aValue.localeCompare(bValue)
          : bValue.localeCompare(aValue);
      }

      // Handle number comparison
      if (typeof aValue === "number" && typeof bValue === "number") {
        return sortBy.direction === "asc" 
          ? aValue - bValue 
          : bValue - aValue;
      }

      // Handle date comparison
    //   if (aValue instanceof Date && bValue instanceof Date) {
    //     return sortBy.direction === "asc"
    //       ? aValue.getTime() - bValue.getTime()
    //       : bValue.getTime() - aValue.getTime();
    //   }

      // Default comparison
      return sortBy.direction === "asc"
        ? String(aValue).localeCompare(String(bValue))
        : String(bValue).localeCompare(String(aValue));
    });
  }, [filteredData, sortBy]);

  const clearSearch = () => {
    setSearchTerm("");
  };

  if (isLoading) {
    return (
      <div className="space-y-4">
        <div className="flex justify-between">
          <Skeleton className="h-10 w-64" />
          <Skeleton className="h-10 w-32" />
        </div>
        <Table>
          <TableHeader>
            {columns.map((column, index) => (
              <TableHead key={index}>
                <Skeleton className="h-4 w-24" />
              </TableHead>
            ))}
          </TableHeader>
          <TableBody>
            {Array.from({ length: 5 }).map((_, rowIndex) => (
              <TableRow key={rowIndex}>
                {columns.map((_, colIndex) => (
                  <TableCell key={colIndex}>
                    <Skeleton className="h-4 w-full" />
                  </TableCell>
                ))}
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </div>
    );
  }

  return (
    <div className="w-full space-y-4">
      {searchable && (
        <div className="flex items-center space-x-2">
          <div className="relative flex-1">
            <Search className="absolute left-3 top-1/2 h-4 w-4 -translate-y-1/2 text-muted-foreground" />
            <Input
              placeholder="Search..."
              value={searchTerm}
              onChange={(e) => setSearchTerm(e.target.value)}
              className="pl-10 pr-10"
            />
            {searchTerm && (
              <Button
                variant="ghost"
                size="icon"
                className="absolute right-1 top-1/2 h-7 w-7 -translate-y-1/2"
                onClick={clearSearch}
              >
                <X className="h-4 w-4" />
              </Button>
            )}
          </div>
        </div>
      )}

      <div className="rounded-md border">
        <Table>
          <TableHeader>
            {columns.map((column, index) => (
              <TableHead key={index}>
                {column.sortable ? (
                  <Button
                    variant="ghost"
                    size="sm"
                    className="-ml-3 flex items-center gap-1 hover:bg-transparent"
                    onClick={() => handleSort(column.accessorKey)}
                  >
                    {column.header}
                    <ArrowUpDown
                      className={`ml-1 h-4 w-4 ${
                        sortBy.column === column.accessorKey
                          ? "text-primary"
                          : "text-muted-foreground"
                      }`}
                    />
                  </Button>
                ) : (
                  column.header
                )}
              </TableHead>
            ))}
          </TableHeader>
          <TableBody>
            {sortedData.length === 0 ? (
              <TableRow>
                <TableCell
                  colSpan={columns.length}
                  className="h-32 text-center"
                >
                  No results found.
                </TableCell>
              </TableRow>
            ) : (
              sortedData.map((row, rowIndex) => (
                <TableRow
                  key={rowIndex}
                  className={detailsPath ? "cursor-pointer" : ""}
                  onClick={() => detailsPath && handleRowClick(row[idField])}
                >
                  {columns.map((column, cellIndex) => (
                    <TableCell key={cellIndex}>
                      {column.cell ? (
                        column.cell(row)
                      ) : column.enableLink && column.linkPath ? (
                        <a
                          href={`${column.linkPath}/${row[idField]}`}
                          className="flex items-center text-blue-600 hover:underline"
                          onClick={(e) => e.stopPropagation()}
                        >
                          {String(row[column.accessorKey])}
                          <ExternalLink className="ml-1 h-3 w-3" />
                        </a>
                      ) : (
                        String(row[column.accessorKey] || "")
                      )}
                    </TableCell>
                  ))}
                </TableRow>
              ))
            )}
          </TableBody>
        </Table>
      </div>
    </div>
  );
}