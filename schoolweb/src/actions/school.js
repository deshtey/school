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

export function useGetSchools() {
  const url = endpoints.school.list;

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);
  const memoizedValue = useMemo(
    () => ({
      schools: data ?? [],
      schoolsLoading: isLoading,
      schoolsError: error,
      schoolsValidating: isValidating,
      schoolsEmpty: !isLoading && !data?.length,
    }),
    [data, error, isLoading, isValidating]
  );

  return memoizedValue;
}

export function useGetSchool(id) {
  const url = `${endpoints.school.details}/${id}`;
  // const url = [endpoints.school.details, { params: { id } }];

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);

  const memoizedValue = useMemo(
    () => ({
      school: data,
      schoolLoading: isLoading,
      schoolError: error,
      schoolValidating: isValidating,
      schoolEmpty: !isLoading && !data,
    }),
    [data?.school, error, isLoading, isValidating]
  );

  return memoizedValue;
}

export function usePostSchool(parameters) {
  const url = endpoints.school.list;

  const key = `${url}-${JSON.stringify(parameters)}`;

  const { school, error, mutate } = useSWR(key, () => fetcherPost(url, parameters));

  return {
    school,
    error,
    mutate,
    isLoading: !data && !error,
  };
}

export const createSchool = async (schoolData) => {
  const url = endpoints.school.list;
  try {
    const response = await axiosInstance.post(url, schoolData);
    return response.data;
  } catch (error) {
    console.error('Error creating school:', error);
    throw error;
  }
};

// ----------------------------------------------------------------------
