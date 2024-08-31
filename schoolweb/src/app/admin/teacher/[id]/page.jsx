'use client';
import { useGetTeacher } from 'src/actions/teacher';
import { CONFIG } from 'src/config-global';

import { TeacherEditView } from 'src/sections/teacher/view/teacher-edit-view';

// ----------------------------------------------------------------------

export default function Page({ params }) {
  const { id } = params;
  const { teacher, teacherEmpty, teacherError, teacherLoading, teacherValidating } =
    useGetTeacher(id);
  return <TeacherEditView teacher={teacher} />;
}
