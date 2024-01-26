'use client';

// @mui
import Container from '@mui/material/Container';
// routes
import { paths } from 'src/routes/paths';
// components
import { useSettingsContext } from 'src/components/settings';
import CustomBreadcrumbs from 'src/components/custom-breadcrumbs';
//
import TeacherNewEditForm from '../teacher-new-edit-form';

// ----------------------------------------------------------------------

export default function TeacherCreateView() {
  const settings = useSettingsContext();

  return (
    <Container maxWidth={settings.themeStretch ? false : 'lg'}>
      <CustomBreadcrumbs
        heading="Create a new teacher"
        links={[
          {
            name: 'Dashboard',
            href: paths.dashboard.root,
          },
          {
            name: 'Teacher',
            href: paths.dashboard.teacher.root,
          },
          { name: 'New teacher' },
        ]}
        sx={{
          mb: { xs: 3, md: 5 },
        }}
      />

      <TeacherNewEditForm />
    </Container>
  );
}
