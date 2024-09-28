import useSWR from 'swr';
import { useMemo } from 'react';

import axiosInstance, { fetcher, endpoints, fetcherPost } from 'src/utils/axios';

// ----------------------------------------------------------------------

const swrOptions = {
  revalidateIfStale: false,
  revalidateOnFocus: false,
  revalidateOnReconnect: false,
};

// ----------------------------------------------------------------------

export function useGetGrades(schoolId) {
  const url = `${endpoints.grade.list}/${schoolId}`;

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);
  const memoizedValue = useMemo(
    () => ({
      grades: data ?? [],
      gradesLoading: isLoading,
      gradesError: error,
      gradesValidating: isValidating,
      gradesEmpty: !isLoading && !data?.length,
    }),
    [data, error, isLoading, isValidating]
  );

  return memoizedValue;
}

// ----------------------------------------------------------------------

export function useGetGrade(id) {
  const url = `${endpoints.grade.details}/${id}`;
  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);

  const memoizedValue = useMemo(
    () => ({
      grade: data,
      gradeLoading: isLoading,
      gradeError: error,
      gradeValidating: isValidating,
      gradeEmpty: !isLoading && !data,
    }),
    [data?.grade, error, isLoading, isValidating]
  );

  return memoizedValue;
}

export const createGrade = async (gradeData) => {
  const url = endpoints.grade.create;
  try {
    const response = await axiosInstance.post(url, gradeData);
    return response.data;
  } catch (error) {
    console.error('Error creating school:', error);
    throw error;
  }
};
