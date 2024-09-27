import useSWR from 'swr';
import { useMemo } from 'react';

import axiosInstance, { fetcher, endpoints, fetcherPost } from 'src/utils/axios';

// ----------------------------------------------------------------------

const swrOptions = {
  revalidateIfStale: false,
  revalidateOnFocus: false,
  revalidateOnReconnect: false,
};

export function useGetStudents(studentId = 2) {
  const url = `${endpoints.student.list}/${studentId}`;

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);
  const memoizedValue = useMemo(
    () => ({
      students: data ?? [],
      studentsLoading: isLoading,
      studentsError: error,
      studentsValidating: isValidating,
      studentsEmpty: !isLoading && !data?.length,
    }),
    [data, error, isLoading, isValidating]
  );

  return memoizedValue;
}

// ----------------------------------------------------------------------

export function useGetStudent(schoolId, id) {
  const url = `${endpoints.student.details}/${schoolId}/${id}`;
  debugger;
  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);

  const memoizedValue = useMemo(
    () => ({
      student: data,
      studentLoading: isLoading,
      studentError: error,
      studentValidating: isValidating,
      studentEmpty: !isLoading && !data,
    }),
    [data?.student, error, isLoading, isValidating]
  );

  return memoizedValue;
}
