import PropTypes from 'prop-types';

import Box from '@mui/material/Box';

import SchoolCard from './school-card';

// ----------------------------------------------------------------------

export default function SchoolCardList({ schools }) {
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
      {schools.map((school) => (
        <SchoolCard key={school.id} school={school} />
      ))}
    </Box>
  );
}

SchoolCardList.propTypes = {
  schools: PropTypes.array,
};
