'use client';

import PropTypes from 'prop-types';
// @mui
import Container from '@mui/material/Container';
// routes
import { paths } from 'src/routes/paths';
// _mock
import { _teacherList } from 'src/_mock';
// components
import { useSettingsContext } from 'src/components/settings';
import CustomBreadcrumbs from 'src/components/custom-breadcrumbs';
//
import TeacherNewEditForm from '../teacher-new-edit-form';

// ----------------------------------------------------------------------

export default function TeacherEditView({ id }) {
  const settings = useSettingsContext();

  const currentTeacher = _teacherList.find((teacher) => teacher.id === id);

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
            name: 'Teacher',
            href: paths.dashboard.teacher.root,
          },
          { name: currentTeacher?.name },
        ]}
        sx={{
          mb: { xs: 3, md: 5 },
        }}
      />

      <TeacherNewEditForm currentTeacher={currentTeacher} />
    </Container>
  );
}

TeacherEditView.propTypes = {
  id: PropTypes.string,
};
