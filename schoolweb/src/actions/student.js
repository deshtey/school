import useSWR from 'swr';
import { useMemo, useState } from 'react';

import axiosInstance, { fetcher, endpoints, fetcherPost } from 'src/utils/axios';

// ----------------------------------------------------------------------

const swrOptions = {
  revalidateIfStale: false,
  revalidateOnFocus: false,
  revalidateOnReconnect: false,
};

// ----------------------------------------------------------------------

export function useGetStudents(schoolId = 2) {
  const url = `${endpoints.student.list}/${schoolId}`;

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

export function useGetStudent(title) {
  const url = title ? [endpoints.student.details, { params: { title } }] : '';

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);

  const memoizedValue = useMemo(
    () => ({
      student: data?.student,
      studentLoading: isLoading,
      studentError: error,
      studentValidating: isValidating,
    }),
    [data?.student, error, isLoading, isValidating]
  );

  return memoizedValue;
}

export function usePostStudent(parameters) {
  const url = endpoints.student.list;

  const key = `${url}-${JSON.stringify(parameters)}`;

  const { student, error, mutate } = useSWR(key, () => fetcherPost(url, parameters));

  return {
    student,
    error,
    mutate,
    isLoading: !data && !error,
  };
}
export const usePostData = () => {
  const url = endpoints.student.list;

  const { trigger, data, error, isValidating } = useSWR(url, fetcherPost, {
    revalidateOnFocus: false,
    revalidateOnReconnect: false,
    shouldRetryOnError: false,
  });

  return {
    postData: trigger,
    data,
    isLoading: isValidating,
    error,
  };
};
// ----------------------------------------------------------------------

export function useGetLatestStudents(title) {
  const url = title ? [endpoints.student.latest, { params: { title } }] : '';

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);

  const memoizedValue = useMemo(
    () => ({
      latestStudents: data?.latestStudents || [],
      latestStudentsLoading: isLoading,
      latestStudentsError: error,
      latestStudentsValidating: isValidating,
      latestStudentsEmpty: !isLoading && !data?.latestStudents.length,
    }),
    [data?.latestStudents, error, isLoading, isValidating]
  );

  return memoizedValue;
}

// ----------------------------------------------------------------------

export function useSearchStudents(query) {
  const url = query ? [endpoints.student.search, { params: { query } }] : '';

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, {
    ...swrOptions,
    keepPreviousData: true,
  });

  const memoizedValue = useMemo(
    () => ({
      searchResults: data?.results || [],
      searchLoading: isLoading,
      searchError: error,
      searchValidating: isValidating,
      searchEmpty: !isLoading && !data?.results.length,
    }),
    [data?.results, error, isLoading, isValidating]
  );

  return memoizedValue;
}
