'use client';
import { useGetSchool } from 'src/actions/school';
import { CONFIG } from 'src/config-global';

import { SchoolEditView } from 'src/sections/school/view/school-edit-view';

// ----------------------------------------------------------------------

export default function Page({ params }) {
  const { id } = params;
  const { school, schoolEmpty, schoolError, schoolLoading, schoolValidating } = useGetSchool(id);
  return <SchoolEditView school={school} />;
}
