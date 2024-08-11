'use client';

import { paths } from 'src/routes/paths';

import { DashboardContent } from 'src/layouts/dashboard';

import { CustomBreadcrumbs } from 'src/components/custom-breadcrumbs';

import { StudentNewEditForm } from '../student-new-edit-form';

// ----------------------------------------------------------------------

export function StudentEditView({ student: currentStudent }) {
  return (
    <DashboardContent>
      <CustomBreadcrumbs
        heading="Edit"
        links={[
          { name: 'Dashboard', href: paths.dashboard.root },
          { name: 'Student', href: paths.dashboard.student.root },
          { name: currentStudent?.name },
        ]}
        sx={{ mb: { xs: 3, md: 5 } }}
      />

      <StudentNewEditForm currentStudent={currentStudent} />
    </DashboardContent>
  );
}
