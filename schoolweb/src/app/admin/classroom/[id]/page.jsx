'use client';
import { useGetClassroom } from 'src/actions/classroom';
import { ClassroomDetailView } from 'src/sections/classroom/view/classroom-detail-view';

export default function Page({ params }) {
  const { id } = params;
  const { classroom, classroomEmpty, classroomError, classroomLoading, classroomValidating } =
    useGetClassroom(id);

  if (classroomLoading || classroomValidating) {
    return <div>Loading...</div>;
  }

  if (classroomError) {
    return <div>Error: {classroomError.message}</div>;
  }

  if (classroomEmpty) {
    return <div>No classroom data available.</div>;
  }

  return classroom ? <ClassroomDetailView currentClassroom={classroom} /> : null;
}
