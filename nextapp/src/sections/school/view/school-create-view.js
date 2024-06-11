'use client';

import Container from '@mui/material/Container';

import { paths } from 'src/routes/paths';

import { useSettingsContext } from 'src/components/settings';
import CustomBreadcrumbs from 'src/components/custom-breadcrumbs';

import SchoolNewEditForm from '../school-new-edit-form';

// ----------------------------------------------------------------------

export default function SchoolCreateView() {
  const settings = useSettingsContext();

  return (
    <Container maxWidth={settings.themeStretch ? false : 'lg'}>
      <CustomBreadcrumbs
        heading="Create a new school"
        links={[
          {
            name: 'Dashboard',
            href: paths.admin.root,
          },
          {
            name: 'School',
            href: paths.admin.school.root,
          },
          { name: 'New school' },
        ]}
        sx={{
          mb: { xs: 3, md: 5 },
        }}
      />

      <SchoolNewEditForm />
    </Container>
  );
}
