'use client';

import Button from '@mui/material/Button';
import Container from '@mui/material/Container';

import { paths } from 'src/routes/paths';
import { RouterLink } from 'src/routes/components';

import { _schoolCards } from 'src/_mock';

import Iconify from 'src/components/iconify';
import { useSettingsContext } from 'src/components/settings';
import CustomBreadcrumbs from 'src/components/custom-breadcrumbs';

import SchoolCardList from '../school-card-list';

// ----------------------------------------------------------------------

export default function SchoolCardsView() {
  const settings = useSettingsContext();

  return (
    <Container maxWidth={settings.themeStretch ? false : 'lg'}>
      <CustomBreadcrumbs
        heading="School Cards"
        links={[
          { name: 'Dashboard', href: paths.admin.root },
          { name: 'School', href: paths.admin.school.root },
          { name: 'Cards' },
        ]}
        action={
          <Button
            component={RouterLink}
            href={paths.admin.school.new}
            variant="contained"
            startIcon={<Iconify icon="mingcute:add-line" />}
          >
            New School
          </Button>
        }
        sx={{ mb: { xs: 3, md: 5 } }}
      />

      <SchoolCardList schools={_schoolCards} />
    </Container>
  );
}
