import PropTypes from 'prop-types';

import { _schoolList } from 'src/_mock/_school';

import { SchoolEditView } from 'src/sections/school/view';

// ----------------------------------------------------------------------

export const metadata = {
  title: 'Admin: School Edit',
};

export default function SchoolEditPage({ params }) {
  const { id } = params;

  return <SchoolEditView id={id} />;
}

export async function generateStaticParams() {
  return _schoolList.map((school) => ({
    id: school.id,
  }));
}

SchoolEditPage.propTypes = {
  params: PropTypes.shape({
    id: PropTypes.string,
  }),
};
