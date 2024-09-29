'use client';

import Tab from '@mui/material/Tab';
import Tabs from '@mui/material/Tabs';

import { paths } from 'src/routes/paths';

import { useTabs } from 'src/hooks/use-tabs';

import { AdminContent } from 'src/layouts/admin';

import { Iconify } from 'src/components/iconify';
import { CustomBreadcrumbs } from 'src/components/custom-breadcrumbs';
import { Button, Grid } from '@mui/material';

const TABS = [
  { value: 'profile', label: 'Profile', icon: <Iconify icon="solar:student-id-bold" width={24} /> },
  { value: 'address', label: 'Address', icon: <Iconify icon="solar:bill-list-bold" width={24} /> },
  {
    value: 'notifications',
    label: 'Notifications',
    icon: <Iconify icon="solar:bell-bing-bold" width={24} />,
  },
  { value: 'social', label: 'Social links', icon: <Iconify icon="solar:share-bold" width={24} /> },
  { value: 'security', label: 'Security', icon: <Iconify icon="ic:round-vpn-key" width={24} /> },
];

export function StudentDetailView({ currentStudent: student }) {
  const tabs = useTabs('profile');

  return (
    <AdminContent>
      <CustomBreadcrumbs
        heading="Student"
        links={[
          { name: 'Admin', href: paths.admin.root },
          { name: 'Student', href: paths.admin.student.root },
          { name: 'Details' },
        ]}
        sx={{ mb: { xs: 3, md: 5 } }}
      />

      <Tabs value={tabs.value} onChange={tabs.onChange} sx={{ mb: { xs: 3, md: 5 } }}>
        {TABS.map((tab) => (
          <Tab key={tab.value} label={tab.label} icon={tab.icon} value={tab.value} />
        ))}
      </Tabs>
      {tabs.value === 'profile' && (
        <>
          <Grid container spacing={{ xs: 0.5, md: 2 }}>
            <Grid xs={12} md={4} sx={{ color: 'text.secondary' }}>
              Name
            </Grid>
            <Grid xs={12} md={8} sx={{ color: 'text.secondary' }}>
              {student.studentDto.fullName}
            </Grid>
          </Grid>
        </>
      )}
    </AdminContent>
  );
}
