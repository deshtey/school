'use client';

import { paths } from 'src/routes/paths';

import { DashboardContent } from 'src/layouts/dashboard';

import { CustomBreadcrumbs } from 'src/components/custom-breadcrumbs';

import { StudentNewEditForm } from '../student-new-edit-form';

// ----------------------------------------------------------------------

export function StudentCreateView() {
  return (
    <DashboardContent>
      <CustomBreadcrumbs
        heading="Create a new student"
        links={[
          { name: 'Dashboard', href: paths.dashboard.root },
          { name: 'Student', href: paths.dashboard.student.root },
          { name: 'New student' },
        ]}
        sx={{ mb: { xs: 3, md: 5 } }}
      />

      <StudentNewEditForm />
    </DashboardContent>
  );
}
