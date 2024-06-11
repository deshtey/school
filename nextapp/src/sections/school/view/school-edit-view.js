'use client';

import PropTypes from 'prop-types';

import Container from '@mui/material/Container';

import { paths } from 'src/routes/paths';

import { _schoolList } from 'src/_mock';

import { useSettingsContext } from 'src/components/settings';
import CustomBreadcrumbs from 'src/components/custom-breadcrumbs';

import SchoolNewEditForm from '../school-new-edit-form';

// ----------------------------------------------------------------------

export default function SchoolEditView({ id }) {
  const settings = useSettingsContext();

  const currentSchool = _schoolList.find((school) => school.id === id);

  return (
    <Container maxWidth={settings.themeStretch ? false : 'lg'}>
      <CustomBreadcrumbs
        heading="Edit"
        links={[
          {
            name: 'Dashboard',
            href: paths.admin.root,
          },
          {
            name: 'School',
            href: paths.admin.school.root,
          },
          { name: currentSchool?.name },
        ]}
        sx={{
          mb: { xs: 3, md: 5 },
        }}
      />

      <SchoolNewEditForm currentSchool={currentSchool} />
    </Container>
  );
}

SchoolEditView.propTypes = {
  id: PropTypes.string,
};
