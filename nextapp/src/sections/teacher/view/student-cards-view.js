'use client';

// @mui
import Button from '@mui/material/Button';
import Container from '@mui/material/Container';
// routes
import { paths } from 'src/routes/paths';
// _mock
import { _teacherCards } from 'src/_mock';
// components
import Iconify from 'src/components/iconify';
import { RouterLink } from 'src/routes/components';
import { useSettingsContext } from 'src/components/settings';
import CustomBreadcrumbs from 'src/components/custom-breadcrumbs';
//
import TeacherCardList from '../teacher-card-list';

// ----------------------------------------------------------------------

export default function TeacherCardsView() {
  const settings = useSettingsContext();

  return (
    <Container maxWidth={settings.themeStretch ? false : 'lg'}>
      <CustomBreadcrumbs
        heading="Teacher Cards"
        links={[
          { name: 'Dashboard', href: paths.dashboard.root },
          { name: 'Teacher', href: paths.dashboard.teacher.root },
          { name: 'Cards' },
        ]}
        action={
          <Button
            component={RouterLink}
            href={paths.dashboard.teacher.new}
            variant="contained"
            startIcon={<Iconify icon="mingcute:add-line" />}
          >
            New Teacher
          </Button>
        }
        sx={{ mb: { xs: 3, md: 5 } }}
      />

      <TeacherCardList teachers={_teacherCards} />
    </Container>
  );
}
