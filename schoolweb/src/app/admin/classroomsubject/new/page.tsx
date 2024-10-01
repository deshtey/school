'use client';
import React from 'react';
import { useGetClassroomsubject } from 'src/actions/classroomsubject';
import { ClassroomsubjectEditView } from 'src/sections/classroomsubject/view/classroomsubject-edit-view';

/**
 * Page for editing a classroomsubject, given an ID.
 * @param {PageProps} props - Props for the page, including the ID of the classroomsubject to edit.
 * @returns {JSX.Element} The page component.
 */
export default function ClassroomsubjectNewPage({ params: { id } }: PageProps): JSX.Element {
  return <ClassroomsubjectEditView currentClassroomsubject={null} />;
}

interface PageProps {
  params: {
    id: number;
  };
}
