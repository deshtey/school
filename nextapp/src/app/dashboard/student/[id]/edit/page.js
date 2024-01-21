import PropTypes from 'prop-types';
// _mock
import { _studentList } from 'src/_mock/_student';
// sections
import { StudentEditView } from 'src/sections/student/view';

// ----------------------------------------------------------------------

export const metadata = {
  title: 'Dashboard: student Edit',
};

export default function StudentEditPage({ params }) {
  const { id } = params;

  return <StudentEditView id={id} />;
}

export async function generateStaticParams() {
  return _studentList.map((student) => ({
    id: student.id,
  }));
}

StudentEditPage.propTypes = {
  params: PropTypes.shape({
    id: PropTypes.string,
  }),
};
