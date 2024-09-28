'use client';
import React from 'react';
import { useGetSchool } from 'src/actions/school';
import { SchoolDetailView } from 'src/sections/school/view/school-detail-view';

/**
 * Page for editing a school, given an ID.
 * @param {PageProps} props - Props for the page, including the ID of the school to edit.
 * @returns {JSX.Element} The page component.
 */
export default function SchoolDetailPage({ params: { id } }: PageProps): JSX.Element {
  const { school, schoolEmpty, schoolError, schoolLoading, schoolValidating } = useGetSchool(id);
  if (schoolLoading || schoolValidating) {
    return <div>Loading...</div>;
  }

  if (schoolError) {
    return <div>Error: {schoolError.message}</div>;
  }

  if (schoolEmpty) {
    return <div>No school data available.</div>;
  }

  return school ? <SchoolDetailView currentSchool={school} /> : null;
}

interface PageProps {
  params: {
    id: number;
  };
}
