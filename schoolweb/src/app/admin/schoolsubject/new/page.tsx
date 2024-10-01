'use client';
import React from 'react';
import { useGetSchoolsubject } from 'src/actions/schoolsubject';
import { SchoolsubjectEditView } from 'src/sections/schoolsubject/view/schoolsubject-edit-view';

/**
 * Page for editing a schoolsubject, given an ID.
 * @param {PageProps} props - Props for the page, including the ID of the schoolsubject to edit.
 * @returns {JSX.Element} The page component.
 */
export default function SchoolsubjectNewPage({ params: { id } }: PageProps): JSX.Element {
  return <SchoolsubjectEditView currentSchoolsubject={null} />;
}

interface PageProps {
  params: {
    id: number;
  };
}
