import useSWR from 'swr';
import { useMemo } from 'react';

import { fetcher, endpoints } from 'src/utils/axios';

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
  console.log(data);
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

// ----------------------------------------------------------------------

export function useGetSchool(title) {
  const url = title ? [endpoints.school.details, { params: { title } }] : '';

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);

  const memoizedValue = useMemo(
    () => ({
      school: data?.school,
      schoolLoading: isLoading,
      schoolError: error,
      schoolValidating: isValidating,
    }),
    [data?.school, error, isLoading, isValidating]
  );

  return memoizedValue;
}

// ----------------------------------------------------------------------

export function useGetLatestSchools(title) {
  const url = title ? [endpoints.school.latest, { params: { title } }] : '';

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);

  const memoizedValue = useMemo(
    () => ({
      latestSchools: data?.latestSchools || [],
      latestSchoolsLoading: isLoading,
      latestSchoolsError: error,
      latestSchoolsValidating: isValidating,
      latestSchoolsEmpty: !isLoading && !data?.latestSchools.length,
    }),
    [data?.latestSchools, error, isLoading, isValidating]
  );

  return memoizedValue;
}

// ----------------------------------------------------------------------

export function useSearchSchools(query) {
  const url = query ? [endpoints.school.search, { params: { query } }] : '';

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
