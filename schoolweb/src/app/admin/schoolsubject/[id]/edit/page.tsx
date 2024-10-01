'use client';
import React from 'react';
import { useGetSchoolsubject } from 'src/actions/schoolsubject';
import { SchoolsubjectEditView } from 'src/sections/schoolsubject/view/schoolsubject-edit-view';

/**
 * Page for editing a schoolsubject, given an ID.
 * @param {PageProps} props - Props for the page, including the ID of the schoolsubject to edit.
 * @returns {JSX.Element} The page component.
 */
export default function SchoolsubjectEditPage({ params: { id } }: PageProps): JSX.Element {
  const {
    schoolsubject,
    schoolsubjectEmpty,
    schoolsubjectError,
    schoolsubjectLoading,
    schoolsubjectValidating,
  } = useGetSchoolsubject(id);
  if (schoolsubjectLoading || schoolsubjectValidating) {
    return <div>Loading...</div>;
  }

  if (schoolsubjectError) {
    return <div>Error: {schoolsubjectError.message}</div>;
  }

  if (schoolsubjectEmpty) {
    return <div>No schoolsubject data available.</div>;
  }

  return schoolsubject ? <SchoolsubjectEditView currentSchoolsubject={schoolsubject} /> : null;

  // return <SchoolsubjectEditView schoolsubject={schoolsubject} />;
}

interface PageProps {
  params: {
    id: number;
  };
}
