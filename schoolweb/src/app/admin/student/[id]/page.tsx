'use client';
import React from 'react';
import { useSelector } from 'react-redux';
import { useGetStudent } from 'src/actions/student';
import { StudentDetailView } from 'src/sections/student/view/student-detail-view';

/**
 * Page for editing a student, given an ID.
 * @param {PageProps} props - Props for the page, including the ID of the student to edit.
 * @returns {JSX.Element} The page component.
 */
export default function StudentDetailPage({ params: { id } }: PageProps): JSX.Element {
  const school = useSelector((state: any) => state.school);
  const { student, studentEmpty, studentError, studentLoading, studentValidating } = useGetStudent(
    school.id,
    id
  );
  if (studentLoading || studentValidating) {
    return <div>Loading...</div>;
  }

  if (studentError) {
    return <div>Error: {studentError.message}</div>;
  }

  if (studentEmpty) {
    return <div>No student data available.</div>;
  }

  return student ? <StudentDetailView currentStudent={student} /> : null;

  // return <StudentEditView student={student} />;
}

interface PageProps {
  params: {
    id: number;
  };
}
