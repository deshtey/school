'use client';

import { useState, useCallback } from 'react';

import Tab from '@mui/material/Tab';
import Box from '@mui/material/Box';
import Tabs from '@mui/material/Tabs';
import Card from '@mui/material/Card';
import Table from '@mui/material/Table';
import Button from '@mui/material/Button';
import Tooltip from '@mui/material/Tooltip';
import TableBody from '@mui/material/TableBody';
import IconButton from '@mui/material/IconButton';

import { paths } from 'src/routes/paths';
import { useRouter } from 'src/routes/hooks';

import { useBoolean } from 'src/hooks/use-boolean';
import { useSetState } from 'src/hooks/use-set-state';

import { fIsAfter, fIsBetween } from 'src/utils/format-time';

import { varAlpha } from 'src/theme/styles';
import { AdminContent } from 'src/layouts/admin';

import { Label } from 'src/components/label';
import { toast } from 'src/components/snackbar';
import { Iconify } from 'src/components/iconify';
import { Scrollbar } from 'src/components/scrollbar';
import { ConfirmDialog } from 'src/components/custom-dialog';
import { CustomBreadcrumbs } from 'src/components/custom-breadcrumbs';
import {
  useTable,
  emptyRows,
  rowInPage,
  TableNoData,
  getComparator,
  TableEmptyRows,
  TableHeadCustom,
  TableSelectedAction,
  TablePaginationCustom,
} from 'src/components/table';

import { PermissionsTableRow } from '../permissions-table-row';
import { PermissionsTableToolbar } from '../permissions-table-toolbar';
import { PermissionsTableFiltersResult } from '../permissions-table-filters-result';
import { useGetPermissions } from 'src/actions/permissions';
import { RouterLink } from 'src/routes/components';

// ----------------------------------------------------------------------

const STATUS_OPTIONS = [
  { value: 'all', label: 'All' },
  { value: 'active', label: 'Active' },
  { value: 'inactive', label: 'Inactive' },
];

const TABLE_HEAD = [
  // { id: 'permissionsNumber', label: 'Id', width: 88 },
  { id: 'name', label: 'Permission Name' },
  { id: 'desc', label: 'Description' },
  { id: '', width: 88 },
];

// ----------------------------------------------------------------------

export function PermissionsListView() {
  const table = useTable({ defaultPermissionsBy: 'permissionsNumber' });
  const {
    permissions,
    permissionsEmpty,
    permissionsError,
    permissionsLoading,
    permissionsValidating,
  } = useGetPermissions();
  const router = useRouter();

  const confirm = useBoolean();

  const [tableData, setTableData] = useState(permissions);

  const filters = useSetState({
    name: '',
    status: 'all',
    startDate: null,
    endDate: null,
  });

  const dateError = fIsAfter(filters.state.startDate, filters.state.endDate);

  const dataFiltered = applyFilter({
    inputData: permissions,
    comparator: getComparator(table.permissions, table.permissionsBy),
    filters: filters.state,
    dateError,
  });

  const dataInPage = rowInPage(dataFiltered, table.page, table.rowsPerPage);

  const canReset =
    !!filters.state.name ||
    filters.state.status !== 'all' ||
    (!!filters.state.startDate && !!filters.state.endDate);

  const notFound = (!dataFiltered.length && canReset) || !dataFiltered.length;

  const handleDeleteRow = useCallback(
    (id) => {
      const deleteRow = tableData.filter((row) => row.id !== id);

      toast.success('Delete success!');

      setTableData(deleteRow);

      table.onUpdatePageDeleteRow(dataInPage.length);
    },
    [dataInPage.length, table, tableData]
  );

  const handleDeleteRows = useCallback(() => {
    const deleteRows = tableData.filter((row) => !table.selected.includes(row.id));

    toast.success('Delete success!');

    setTableData(deleteRows);

    table.onUpdatePageDeleteRows({
      totalRowsInPage: dataInPage.length,
      totalRowsFiltered: dataFiltered.length,
    });
  }, [dataFiltered.length, dataInPage.length, table, tableData]);

  const handleViewRow = useCallback(
    (id) => {
      router.push(paths.admin.permissions.details(id));
    },
    [router]
  );

  const handleFilterStatus = useCallback(
    (event, newValue) => {
      table.onResetPage();
      filters.setState({ status: newValue });
    },
    [filters, table]
  );

  return (
    <>
      <AdminContent>
        <CustomBreadcrumbs
          heading="List"
          links={[
            { name: 'Admin', href: paths.admin.root },
            { name: 'Permissions', href: paths.admin.permissions.root },
            { name: 'List' },
          ]}
          action={
            <Button
              component={RouterLink}
              href={paths.admin.permissions.new}
              variant="contained"
              startIcon={<Iconify icon="mingcute:add-line" />}
            >
              New permissions
            </Button>
          }
          sx={{ mb: { xs: 3, md: 5 } }}
        />

        <Card>
          <Tabs
            value={filters.state.status}
            onChange={handleFilterStatus}
            sx={{
              px: 2.5,
              boxShadow: (theme) =>
                `inset 0 -2px 0 0 ${varAlpha(theme.vars.palette.grey['500Channel'], 0.08)}`,
            }}
          >
            {STATUS_OPTIONS.map((tab) => (
              <Tab
                key={tab.value}
                iconPosition="end"
                value={tab.value}
                label={tab.label}
                icon={
                  <Label
                    variant={
                      ((tab.value === 'all' || tab.value === filters.state.status) && 'filled') ||
                      'soft'
                    }
                    color={
                      (tab.value === 'active' && 'success') ||
                      (tab.value === 'inactive' && 'warning') ||
                      'default'
                    }
                  >
                    {['completed', 'pending', 'cancelled', 'refunded'].includes(tab.value)
                      ? tableData.filter((user) => user.status === tab.value).length
                      : tableData.length}
                  </Label>
                }
              />
            ))}
          </Tabs>

          <PermissionsTableToolbar
            filters={filters}
            onResetPage={table.onResetPage}
            dateError={dateError}
          />

          {canReset && (
            <PermissionsTableFiltersResult
              filters={filters}
              totalResults={dataFiltered.length}
              onResetPage={table.onResetPage}
              sx={{ p: 2.5, pt: 0 }}
            />
          )}

          <Box sx={{ position: 'relative' }}>
            <TableSelectedAction
              dense={table.dense}
              numSelected={table.selected.length}
              rowCount={dataFiltered.length}
              onSelectAllRows={(checked) =>
                table.onSelectAllRows(
                  checked,
                  dataFiltered.map((row) => row.id)
                )
              }
              action={
                <Tooltip title="Delete">
                  <IconButton color="primary" onClick={confirm.onTrue}>
                    <Iconify icon="solar:trash-bin-trash-bold" />
                  </IconButton>
                </Tooltip>
              }
            />

            <Scrollbar sx={{ minHeight: 444 }}>
              <Table size={table.dense ? 'small' : 'medium'} sx={{ minWidth: 960 }}>
                <TableHeadCustom
                  permissions={table.permissions}
                  permissionsBy={table.permissionsBy}
                  headLabel={TABLE_HEAD}
                  rowCount={dataFiltered.length}
                  numSelected={table.selected.length}
                  onSort={table.onSort}
                  onSelectAllRows={(checked) =>
                    table.onSelectAllRows(
                      checked,
                      dataFiltered.map((row) => row.id)
                    )
                  }
                />

                <TableBody>
                  {dataFiltered
                    .slice(
                      table.page * table.rowsPerPage,
                      table.page * table.rowsPerPage + table.rowsPerPage
                    )
                    .map((row) => (
                      <PermissionsTableRow
                        key={row.permissionsId}
                        row={row}
                        selected={table.selected.includes(row.permissionsId)}
                        onSelectRow={() => table.onSelectRow(row.permissionsId)}
                        onDeleteRow={() => handleDeleteRow(row.permissionsId)}
                        onViewRow={() => handleViewRow(row.permissionsId)}
                      />
                    ))}

                  <TableEmptyRows
                    height={table.dense ? 56 : 56 + 20}
                    emptyRows={emptyRows(table.page, table.rowsPerPage, dataFiltered.length)}
                  />

                  <TableNoData notFound={notFound} />
                </TableBody>
              </Table>
            </Scrollbar>
          </Box>

          <TablePaginationCustom
            page={table.page}
            dense={table.dense}
            count={dataFiltered.length}
            rowsPerPage={table.rowsPerPage}
            onPageChange={table.onChangePage}
            onChangeDense={table.onChangeDense}
            onRowsPerPageChange={table.onChangeRowsPerPage}
          />
        </Card>
      </AdminContent>

      <ConfirmDialog
        open={confirm.value}
        onClose={confirm.onFalse}
        title="Delete"
        content={
          <>
            Are you sure want to delete <strong> {table.selected.length} </strong> items?
          </>
        }
        action={
          <Button
            variant="contained"
            color="error"
            onClick={() => {
              handleDeleteRows();
              confirm.onFalse();
            }}
          >
            Delete
          </Button>
        }
      />
    </>
  );
}

function applyFilter({ inputData, comparator, filters, dateError }) {
  const { status, name, startDate, endDate } = filters;

  const stabilizedThis = inputData.map((el, index) => [el, index]);

  stabilizedThis.sort((a, b) => {
    const permissions = comparator(a[0], b[0]);
    if (permissions !== 0) return permissions;
    return a[1] - b[1];
  });

  inputData = stabilizedThis.map((el) => el[0]);

  if (name) {
    inputData = inputData.filter(
      (permissions) =>
        permissions.permissionsNumber.toLowerCase().indexOf(name.toLowerCase()) !== -1 ||
        permissions.customer.name.toLowerCase().indexOf(name.toLowerCase()) !== -1 ||
        permissions.customer.email.toLowerCase().indexOf(name.toLowerCase()) !== -1
    );
  }

  if (status !== 'all') {
    inputData = inputData.filter((permissions) => permissions.status === status);
  }

  if (!dateError) {
    if (startDate && endDate) {
      inputData = inputData.filter((permissions) =>
        fIsBetween(permissions.createdAt, startDate, endDate)
      );
    }
  }

  return inputData;
}
