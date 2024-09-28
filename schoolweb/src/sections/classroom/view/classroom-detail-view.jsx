'use client';

import { paths } from 'src/routes/paths';

import { DashboardContent } from 'src/layouts/dashboard';

import { CustomBreadcrumbs } from 'src/components/custom-breadcrumbs';

import { z as zod } from 'zod';

import Box from '@mui/material/Box';
import Card from '@mui/material/Card';
import Stack from '@mui/material/Stack';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';

import { useRouter } from 'src/routes/hooks';

import { useSelector } from 'react-redux';
import { Avatar, CardHeader, IconButton, Table, TableBody } from '@mui/material';
import { Iconify } from 'src/components/iconify';
import { Scrollbar } from 'src/components/scrollbar';
import {
  emptyRows,
  TableNoData,
  TableEmptyRows,
  TableHeadCustom,
  useTable,
} from 'src/components/table';
import { StudentTableRow } from 'src/sections/student/student-table-row';
import { useCallback } from 'react';
const TABLE_HEAD = [
  // { id: 'classroomNumber', label: 'Id', width: 88 },
  { id: 'name', label: 'Student Name' },
  { id: 'regNumber', label: 'Reg Number', width: 140 },
  { id: 'gender', label: 'Gender', width: 140 },
  { id: 'status', label: 'Status', width: 140 },
  { id: '', width: 88 },
];

// ----------------------------------------------------------------------

export function ClassroomDetailView({ currentClassroom: classroom }) {
  const school = useSelector((state) => state.school);
  const table = useTable({ defaultClassroomBy: 'classroomNumber' });
  const notFound = !classroom.students.length;

  const router = useRouter();
  const handleViewRow = useCallback(
    (studentId) => {
      router.push(paths.admin.student.details(studentId));
    },
    [router]
  );
  const renderClassroom = (
    <>
      <CardHeader
        title="Classroom info"
        action={
          <IconButton>
            <Iconify icon="solar:pen-bold" />
          </IconButton>
        }
      />
    </>
  );
  //   <>
  //     <CardHeader
  //       title="Delivery"
  //       action={
  //         <IconButton>
  //           <Iconify icon="solar:pen-bold" />
  //         </IconButton>
  //       }
  //     />
  //     <Stack spacing={1.5} sx={{ p: 3, typography: 'body2' }}>
  //       <Stack direction="row" alignItems="center">
  //         <Box component="span" sx={{ color: 'text.secondary', width: 120, flexShrink: 0 }}>
  //           Ship by
  //         </Box>
  //         {delivery?.shipBy}
  //       </Stack>
  //       <Stack direction="row" alignItems="center">
  //         <Box component="span" sx={{ color: 'text.secondary', width: 120, flexShrink: 0 }}>
  //           Speedy
  //         </Box>
  //         {delivery?.speedy}
  //       </Stack>
  //       <Stack direction="row" alignItems="center">
  //         <Box component="span" sx={{ color: 'text.secondary', width: 120, flexShrink: 0 }}>
  //           Tracking No.
  //         </Box>
  //         <Link underline="always" color="inherit">
  //           {delivery?.trackingNumber}
  //         </Link>
  //       </Stack>
  //     </Stack>
  //   </>
  // );

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
        heading="Create a new classroom"
        links={[
          { name: 'Dashboard', href: paths.admin.root },
          { name: 'Classroom', href: paths.admin.classroom.root },
          { name: 'New Classroom' },
        ]}
        sx={{ mb: { xs: 3, md: 5 } }}
      />
      <Card>
        {renderClassroom}

        <Scrollbar sx={{ minHeight: 444 }}>
          <Table size={table.dense ? 'small' : 'medium'} sx={{ minWidth: 960 }}>
            <TableHeadCustom
              classroom={table.classroom}
              classroomBy={table.classroomBy}
              headLabel={TABLE_HEAD}
              rowCount={classroom.students.length}
              numSelected={table.selected.length}
              onSort={table.onSort}
              onSelectAllRows={(checked) =>
                table.onSelectAllRows(
                  checked,
                  classroom.students.map((row) => row.id)
                )
              }
            />

            <TableBody>
              {classroom.students.map((row) => (
                <StudentTableRow
                  key={row.id}
                  row={row}
                  selected={table.selected.includes(row.id)}
                  onSelectRow={() => table.onSelectRow(row.id)}
                  onDeleteRow={() => handleDeleteRow(row.id)}
                  onViewRow={() => handleViewRow(row.id)}
                />
              ))}

              <TableEmptyRows
                height={table.dense ? 56 : 56 + 20}
                emptyRows={emptyRows(table.page, table.rowsPerPage, classroom.students.length)}
              />

              <TableNoData notFound={notFound} />
            </TableBody>
          </Table>
        </Scrollbar>
      </Card>
    </DashboardContent>
  );
}
