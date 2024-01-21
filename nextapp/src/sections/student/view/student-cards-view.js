'use client';

// @mui
import Button from '@mui/material/Button';
import Container from '@mui/material/Container';
// routes
import { paths } from 'src/routes/paths';
// _mock
import { _studentCards } from 'src/_mock';
// components
import Iconify from 'src/components/iconify';
import { RouterLink } from 'src/routes/components';
import { useSettingsContext } from 'src/components/settings';
import CustomBreadcrumbs from 'src/components/custom-breadcrumbs';
//
import StudentCardList from '../student-card-list';

// ----------------------------------------------------------------------

export default function StudentCardsView() {
  const settings = useSettingsContext();

  return (
    <Container maxWidth={settings.themeStretch ? false : 'lg'}>
      <CustomBreadcrumbs
        heading="Student Cards"
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
            New Student
          </Button>
        }
        sx={{ mb: { xs: 3, md: 5 } }}
      />

      <StudentCardList students={_studentCards} />
    </Container>
  );
}
