'use client';
import React from 'react';
import { useGetStudentsubject } from 'src/actions/studentsubject';
import { StudentsubjectDetailView } from 'src/sections/studentsubject/view/studentsubject-detail-view';

/**
 * Page for editing a studentsubject, given an ID.
 * @param {PageProps} props - Props for the page, including the ID of the studentsubject to edit.
 * @returns {JSX.Element} The page component.
 */
export default function StudentsubjectDetailPage({ params: { id } }: PageProps): JSX.Element {
  const {
    studentsubject,
    studentsubjectEmpty,
    studentsubjectError,
    studentsubjectLoading,
    studentsubjectValidating,
  } = useGetStudentsubject(id);
  if (studentsubjectLoading || studentsubjectValidating) {
    return <div>Loading...</div>;
  }

  if (studentsubjectError) {
    return <div>Error: {studentsubjectError.message}</div>;
  }

  if (studentsubjectEmpty) {
    return <div>No studentsubject data available.</div>;
  }

  return studentsubject ? (
    <StudentsubjectDetailView currentStudentsubject={studentsubject} />
  ) : null;
}

interface PageProps {
  params: {
    id: number;
  };
}
