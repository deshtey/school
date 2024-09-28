'use client';

import { paths } from 'src/routes/paths';

import { DashboardContent } from 'src/layouts/dashboard';

import { CustomBreadcrumbs } from 'src/components/custom-breadcrumbs';

import Box from '@mui/material/Box';
import Card from '@mui/material/Card';
import Stack from '@mui/material/Stack';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';

import { useRouter } from 'src/routes/hooks';

import { useSelector } from 'react-redux';
import {
  Avatar,
  CardHeader,
  IconButton,
  ListItemText,
  MenuItem,
  Table,
  TableBody,
} from '@mui/material';
import { Iconify } from 'src/components/iconify';
import { Scrollbar } from 'src/components/scrollbar';
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
import { ClassroomTableRow } from 'src/sections/classroom/classroom-table-row';
import { useCallback } from 'react';
const TABLE_HEAD = [
  // { id: 'classroomNumber', label: 'Id', width: 88 },
  { id: 'name', label: 'ClassroomName' },
  { id: 'createdAt', label: 'Created', width: 140 },
  { id: 'location', label: 'Location', width: 140 },
  { id: 'phone', label: 'Phone', width: 140 },
  { id: 'city', label: 'City', width: 110 },
  { id: '', width: 88 },
];
export function GradeDetailView({ currentGrade: grade }) {
  const table = useTable({ defaultClassroomBy: 'classroomNumber' });
  const selectedGrade = useSelector((state) => state.grade);
  const router = useRouter();
  const notFound = !grade.classrooms.length;
  const handleViewRow = useCallback(
    (classRoomId) => {
      router.push(paths.admin.classroom.details(classRoomId));
    },
    [router]
  );
  const renderGrade = (
    <>
      <CardHeader
        title="Grade info"
        action={
          <IconButton onClick={() => router.push(paths.admin.grade.edit(grade.id))}>
            <Iconify icon="solar:pen-bold" />
          </IconButton>
        }
      />
      <Stack direction="row" sx={{ p: 3 }}>
        <Avatar alt={grade?.name} src={grade?.logo} sx={{ width: 48, height: 48, mr: 2 }} />

        <Stack spacing={0.5} alignItems="flex-start" sx={{ typography: 'body2' }}>
          <Typography variant="subtitle2">{grade?.name}</Typography>

          <Box sx={{ color: 'text.secondary' }}>{grade?.email}</Box>
        </Stack>
      </Stack>
    </>
  );

  // const renderSubjects = (
  //   <>
  //     <CardHeader
  //       title="Shipping"
  //       action={
  //         <IconButton>
  //           <Iconify icon="solar:pen-bold" />
  //         </IconButton>
  //       }
  //     />
  //     <Stack spacing={1.5} sx={{ p: 3, typography: 'body2' }}>
  //       <Stack direction="row">
  //         <Box component="span" sx={{ color: 'text.secondary', width: 120, flexShrink: 0 }}>
  //           Address
  //         </Box>
  //         {shippingAddress?.fullAddress}
  //       </Stack>

  //       <Stack direction="row">
  //         <Box component="span" sx={{ color: 'text.secondary', width: 120, flexShrink: 0 }}>
  //           Phone number
  //         </Box>
  //         {shippingAddress?.phoneNumber}
  //       </Stack>
  //     </Stack>
  //   </>
  // );
  // const renderTimetable = (
  //   <>
  //     <CardHeader
  //       title="Payment"
  //       action={
  //         <IconButton>
  //           <Iconify icon="solar:pen-bold" />
  //         </IconButton>
  //       }
  //     />
  //     <Box
  //       display="flex"
  //       alignItems="center"
  //       justifyContent="flex-end"
  //       sx={{ p: 3, gap: 0.5, typography: 'body2' }}
  //     >
  //       {payment?.cardNumber}
  //       <Iconify icon="logos:mastercard" width={24} />
  //     </Box>
  //   </>
  // );
  return (
    <DashboardContent>
      <CustomBreadcrumbs
        heading="Details"
        links={[
          { name: 'Dashboard', href: paths.admin.root },
          { name: 'Grade', href: paths.admin.grade.root },
          { name: 'New Grade' },
        ]}
        sx={{ mb: { xs: 3, md: 5 } }}
      />
      <Card>
        {renderGrade}
        <Scrollbar sx={{ minHeight: 444 }}>
          <Table size={table.dense ? 'small' : 'medium'} sx={{ minWidth: 960 }}>
            <TableHeadCustom
              classroom={table.classroom}
              classroomBy={table.classroomBy}
              headLabel={TABLE_HEAD}
              rowCount={grade.classrooms.length}
              numSelected={table.selected.length}
              onSort={table.onSort}
              onSelectAllRows={(checked) =>
                table.onSelectAllRows(
                  checked,
                  grade.classrooms.map((row) => row.id)
                )
              }
            />

            <TableBody>
              {grade.classrooms.map((row) => (
                <ClassroomTableRow
                  key={row.classroomId}
                  row={row}
                  selected={table.selected.includes(row.classroomId)}
                  onSelectRow={() => table.onSelectRow(row.classroomId)}
                  onDeleteRow={() => handleDeleteRow(row.classroomId)}
                  onViewRow={() => handleViewRow(row.classRoomId)}
                />
              ))}

              <TableEmptyRows
                height={table.dense ? 56 : 56 + 20}
                emptyRows={emptyRows(table.page, table.rowsPerPage, grade.classrooms.length)}
              />

              <TableNoData notFound={notFound} />
            </TableBody>
          </Table>
        </Scrollbar>
      </Card>
    </DashboardContent>
  );
}
