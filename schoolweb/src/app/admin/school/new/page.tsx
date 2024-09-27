'use client';
import React from 'react';
import { useGetSchool } from 'src/actions/school';
import { SchoolEditView } from 'src/sections/school/view/school-edit-view';

/**
 * Page for editing a school, given an ID.
 * @param {PageProps} props - Props for the page, including the ID of the school to edit.
 * @returns {JSX.Element} The page component.
 */
export default function SchoolNewPage({ params: { id } }: PageProps): JSX.Element {
  return <SchoolEditView currentSchool={null} />;
}

interface PageProps {
  params: {
    id: number;
  };
}
