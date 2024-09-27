'use client';

import { paths } from 'src/routes/paths';

import { DashboardContent } from 'src/layouts/dashboard';

import { CustomBreadcrumbs } from 'src/components/custom-breadcrumbs';

import { z as zod } from 'zod';
import { useEffect, useMemo } from 'react';
import { useForm } from 'react-hook-form';
import { isValidPhoneNumber } from 'react-phone-number-input/input';

import Box from '@mui/material/Box';
import Card from '@mui/material/Card';
import Stack from '@mui/material/Stack';
import Button from '@mui/material/Button';
import Grid from '@mui/material/Unstable_Grid2';
import Typography from '@mui/material/Typography';
import LoadingButton from '@mui/lab/LoadingButton';

import { useRouter } from 'src/routes/hooks';

import { fData } from 'src/utils/format-number';

import { Label } from 'src/components/label';
import { toast } from 'src/components/snackbar';
import { Form, Field, schemaHelper } from 'src/components/hook-form';
import { usePostClassrooms } from 'src/actions/classroom';
import { useSelector } from 'react-redux';
import { zodResolver } from '@hookform/resolvers/zod';
import { createClassroom } from 'src/actions/classroom';
import { useGetGrades } from 'src/actions/grade';
import { transformArray } from 'src/utils/transformarrays';
import { Avatar, CardHeader, IconButton, MenuItem } from '@mui/material';
import { Iconify } from 'src/components/iconify';

export const NewClassroomSchema = zod.object({
  classroomName: zod.string().min(1, { message: 'Name is required!' }),
  schoolId: zod.number(),
  year: zod.number(),
  gradeId: zod.number().min(1, { message: 'Grade is required!' }),
});

// ----------------------------------------------------------------------

export function ClassroomDetailView({ currentClassroom: classroom }) {
  const school = useSelector((state) => state.school);
  const { grades, gradesEmpty, gradesError, gradesLoading } = useGetGrades(school.id);

  const router = useRouter();
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
      <Stack direction="row" sx={{ p: 3 }}>
        <Avatar
          alt={classroom?.name}
          src={classroom?.avatarUrl}
          sx={{ width: 48, height: 48, mr: 2 }}
        />

        <Stack spacing={0.5} alignItems="flex-start" sx={{ typography: 'body2' }}>
          <Typography variant="subtitle2">{classroom?.name}</Typography>

          <Box sx={{ color: 'text.secondary' }}>{classroom?.email}</Box>

          <div>
            IP address:
            <Box component="span" sx={{ color: 'text.secondary', ml: 0.25 }}>
              {classroom?.ipAddress}
            </Box>
          </div>

          <Button
            size="small"
            color="error"
            startIcon={<Iconify icon="mingcute:add-line" />}
            sx={{ mt: 1 }}
          >
            Add to Blacklist
          </Button>
        </Stack>
      </Stack>
    </>
  );
  // const renderStudents = (
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

        {/* <Divider sx={{ borderStyle: 'dashed' }} />

        {renderDelivery}

        <Divider sx={{ borderStyle: 'dashed' }} />

        {renderShipping}

        <Divider sx={{ borderStyle: 'dashed' }} />

        {renderPayment} */}
      </Card>
    </DashboardContent>
  );
}
