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
import { useGetGrades } from 'src/actions/grade';
import { Avatar, CardHeader, IconButton } from '@mui/material';
import { Iconify } from 'src/components/iconify';

export function SupportStaffDetailView({ currentSupportStaff: supportstaff }) {
  const selectedSupportStaff = useSelector((state) => state.supportstaff);
  const { grades, gradesEmpty, gradesError, gradesLoading } = useGetGrades(
    supportstaff.supportstaffId
  );
  const router = useRouter();
  const renderSupportStaff = (
    <>
      <CardHeader
        title="SupportStaff info"
        action={
          <IconButton
            onClick={() => router.push(paths.admin.supportstaff.edit(supportstaff.supportstaffId))}
          >
            <Iconify icon="solar:pen-bold" />
          </IconButton>
        }
      />
      <Stack direction="row" sx={{ p: 3 }}>
        <Avatar
          alt={supportstaff?.name}
          src={supportstaff?.logo}
          sx={{ width: 48, height: 48, mr: 2 }}
        />

        <Stack spacing={0.5} alignItems="flex-start" sx={{ typography: 'body2' }}>
          <Typography variant="subtitle2">{supportstaff?.name}</Typography>

          <Box sx={{ color: 'text.secondary' }}>{supportstaff?.email}</Box>
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
        heading="Details"
        links={[
          { name: 'Dashboard', href: paths.admin.root },
          { name: 'SupportStaff', href: paths.admin.supportstaff.root },
          { name: 'New SupportStaff' },
        ]}
        sx={{ mb: { xs: 3, md: 5 } }}
      />
      <Card>
        {renderSupportStaff}

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
