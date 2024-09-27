'use client';
import React from 'react';
import { useGetGrade } from 'src/actions/grade';
import { GradeDetailView } from 'src/sections/grade/view/grade-detail-view';

/**
 * Page for editing a grade, given an ID.
 * @param {PageProps} props - Props for the page, including the ID of the grade to edit.
 * @returns {JSX.Element} The page component.
 */
export default function GradeEditPage({ params: { id } }: PageProps): JSX.Element {
  const { grade, gradeEmpty, gradeError, gradeLoading, gradeValidating } = useGetGrade(id);
  if (gradeLoading || gradeValidating) {
    return <div>Loading...</div>;
  }

  if (gradeError) {
    return <div>Error: {gradeError.message}</div>;
  }

  if (gradeEmpty) {
    return <div>No grade data available.</div>;
  }

  return grade ? <GradeDetailView currentGrade={grade} /> : null;

  // return <GradeEditView grade={grade} />;
}

interface PageProps {
  params: {
    id: number;
  };
}
