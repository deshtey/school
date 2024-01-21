'use client';

import PropTypes from 'prop-types';
// @mui
import Container from '@mui/material/Container';
// routes
import { paths } from 'src/routes/paths';
// _mock
import { _studentList } from 'src/_mock';
// components
import { useSettingsContext } from 'src/components/settings';
import CustomBreadcrumbs from 'src/components/custom-breadcrumbs';
//
import StudentNewEditForm from '../student-new-edit-form';

// ----------------------------------------------------------------------

export default function StudentEditView({ id }) {
  const settings = useSettingsContext();

  const currentStudent = _studentList.find((student) => student.id === id);

  return (
    <Container maxWidth={settings.themeStretch ? false : 'lg'}>
      <CustomBreadcrumbs
        heading="Edit"
        links={[
          {
            name: 'Dashboard',
            href: paths.dashboard.root,
          },
          {
            name: 'Student',
            href: paths.dashboard.student.root,
          },
          { name: currentStudent?.name },
        ]}
        sx={{
          mb: { xs: 3, md: 5 },
        }}
      />

      <StudentNewEditForm currentStudent={currentStudent} />
    </Container>
  );
}

StudentEditView.propTypes = {
  id: PropTypes.string,
};
