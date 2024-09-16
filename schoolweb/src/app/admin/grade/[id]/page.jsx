'use client';
import { useGetGrade } from 'src/actions/grade';
import { CONFIG } from 'src/config-global';

import { GradeEditView } from 'src/sections/grade/view/grade-edit-view';

// ----------------------------------------------------------------------

export default function Page({ params }) {
  const { id } = params;
  const { grade, gradeEmpty, gradeError, gradeLoading, gradeValidating } = useGetGrade(id);

  return <GradeEditView grade={grade} />;
}
