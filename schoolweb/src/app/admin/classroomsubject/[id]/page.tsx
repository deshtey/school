'use client';
import React from 'react';
import { useGetClassroomsubject } from 'src/actions/classroomsubject';
import { ClassroomsubjectDetailView } from 'src/sections/classroomsubject/view/classroomsubject-detail-view';

/**
 * Page for editing a classroomsubject, given an ID.
 * @param {PageProps} props - Props for the page, including the ID of the classroomsubject to edit.
 * @returns {JSX.Element} The page component.
 */
export default function ClassroomsubjectDetailPage({ params: { id } }: PageProps): JSX.Element {
  const {
    classroomsubject,
    classroomsubjectEmpty,
    classroomsubjectError,
    classroomsubjectLoading,
    classroomsubjectValidating,
  } = useGetClassroomsubject(id);
  if (classroomsubjectLoading || classroomsubjectValidating) {
    return <div>Loading...</div>;
  }

  if (classroomsubjectError) {
    return <div>Error: {classroomsubjectError.message}</div>;
  }

  if (classroomsubjectEmpty) {
    return <div>No classroomsubject data available.</div>;
  }

  return classroomsubject ? (
    <ClassroomsubjectDetailView currentClassroomsubject={classroomsubject} />
  ) : null;
}

interface PageProps {
  params: {
    id: number;
  };
}
