'use client';

import Button from '@mui/material/Button';

import { paths } from 'src/routes/paths';
import { RouterLink } from 'src/routes/components';

import { _studentCards } from 'src/_mock';
import { DashboardContent } from 'src/layouts/dashboard';

import { Iconify } from 'src/components/iconify';
import { CustomBreadcrumbs } from 'src/components/custom-breadcrumbs';

import { StudentCardList } from '../student-card-list';

// ----------------------------------------------------------------------

export function StudentCardsView() {
  return (
    <DashboardContent>
      <CustomBreadcrumbs
        heading="Student cards"
        links={[
          { name: 'Dashboard', href: paths.dashboard.root },
          { name: 'Student', href: paths.dashboard.student.root },
          { name: 'Cards' },
        ]}
        action={
          <Button
            component={RouterLink}
            href={paths.dashboard.student.new}
            variant="contained"
            startIcon={<Iconify icon="mingcute:add-line" />}
          >
            New student
          </Button>
        }
        sx={{ mb: { xs: 3, md: 5 } }}
      />

      <StudentCardList students={_studentCards} />
    </DashboardContent>
  );
}
