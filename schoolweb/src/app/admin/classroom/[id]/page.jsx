'use client';
import { useGetClassroom } from 'src/actions/classroom';
import { CONFIG } from 'src/config-global';

import { ClassroomEditView } from 'src/sections/classroom/view/classroom-edit-view';

// ----------------------------------------------------------------------

export default function Page({ params }) {
  const { id } = params;
  const { classroom, classroomEmpty, classroomError, classroomLoading, classroomValidating } =
    useGetClassroom(id);

  return <ClassroomEditView classroom={classroom} />;
}
