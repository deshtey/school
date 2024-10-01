'use client';
import React from 'react';
import { useGetSchoolsubject } from 'src/actions/schoolsubject';
import { SchoolsubjectDetailView } from 'src/sections/schoolsubject/view/schoolsubject-detail-view';

/**
 * Page for editing a schoolsubject, given an ID.
 * @param {PageProps} props - Props for the page, including the ID of the schoolsubject to edit.
 * @returns {JSX.Element} The page component.
 */
export default function SchoolsubjectDetailPage({ params: { id } }: PageProps): JSX.Element {
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

  return schoolsubject ? <SchoolsubjectDetailView currentSchoolsubject={schoolsubject} /> : null;
}

interface PageProps {
  params: {
    id: number;
  };
}
