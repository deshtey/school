import PropTypes from 'prop-types';
// @mui
import Box from '@mui/material/Box';
//
import TeacherCard from '../teacher/teacher-card';

// ----------------------------------------------------------------------

export default function TeacherCardList({ Teachers }) {
  return (
    <Box
      gap={3}
      display="grid"
      gridTemplateColumns={{
        xs: 'repeat(1, 1fr)',
        sm: 'repeat(2, 1fr)',
        md: 'repeat(3, 1fr)',
      }}
    >
      {Teachers.map((Teacher) => (
        <TeacherCard key={Teacher.id} Teacher={Teacher} />
      ))}
    </Box>
  );
}

TeacherCardList.propTypes = {
  Teachers: PropTypes.array,
};
