'use client';
import React from 'react';
import { useGetSchool } from 'src/actions/school';

import { SchoolEditView } from 'src/sections/school/view/school-edit-view';

// ----------------------------------------------------------------------

/**
 * Page for editing a school, given an ID.
 * @param {PageProps} props - Props for the page, including the ID of the school to edit.
 * @returns {JSX.Element} The page component.
 */
export default function SchoolEditPage({ params: { id } }: PageProps): JSX.Element {
  const { school, schoolEmpty, schoolError, schoolLoading, schoolValidating } = useGetSchool(id);

  return <SchoolEditView school={school} />;
}

interface PageProps {
  params: {
    id: number;
  };
}
