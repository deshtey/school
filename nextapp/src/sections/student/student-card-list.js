import PropTypes from 'prop-types';
// @mui
import Box from '@mui/material/Box';
//
import StudentCard from '../student/student-card';

// ----------------------------------------------------------------------

export default function StudentCardList({ Students }) {
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
      {Students.map((Student) => (
        <StudentCard key={Student.id} Student={Student} />
      ))}
    </Box>
  );
}

StudentCardList.propTypes = {
  Students: PropTypes.array,
};
