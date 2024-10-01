'use client';
import React from 'react';
import { useGetStudentsubject } from 'src/actions/studentsubject';
import { StudentsubjectEditView } from 'src/sections/studentsubject/view/studentsubject-edit-view';

/**
 * Page for editing a studentsubject, given an ID.
 * @param {PageProps} props - Props for the page, including the ID of the studentsubject to edit.
 * @returns {JSX.Element} The page component.
 */
export default function StudentsubjectNewPage({ params: { id } }: PageProps): JSX.Element {
  return <StudentsubjectEditView currentStudentsubject={null} />;
}

interface PageProps {
  params: {
    id: number;
  };
}
