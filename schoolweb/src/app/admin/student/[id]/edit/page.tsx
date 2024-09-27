'use client';
import React from 'react';
import { useGetStudent } from 'src/actions/student';
import { StudentEditView } from 'src/sections/student/view/student-edit-view';

/**
 * Page for editing a student, given an ID.
 * @param {PageProps} props - Props for the page, including the ID of the student to edit.
 * @returns {JSX.Element} The page component.
 */
export default function StudentEditPage({ params: { id } }: PageProps): JSX.Element {
  const { student, studentEmpty, studentError, studentLoading, studentValidating } =
    useGetStudent(id);
  if (studentLoading || studentValidating) {
    return <div>Loading...</div>;
  }

  if (studentError) {
    return <div>Error: {studentError.message}</div>;
  }

  if (studentEmpty) {
    return <div>No student data available.</div>;
  }

  return student ? <StudentEditView currentStudent={student} /> : null;

  // return <StudentEditView student={student} />;
}

interface PageProps {
  params: {
    id: number;
  };
}
