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

export function usePostSchools1(params) {
  const url = endpoints.school.list;

  const [data, setData] = useState(null);
  const [error, setError] = useState(null);
  const [isLoading, setIsLoading] = useState(false);

  const { mutate } = useSWR(
    [url, params],
    async () => {
      setIsLoading(true);
      try {
        const result = await fetcherPost(url, 'POST', params);
        setData(result);
        setIsLoading(false);
        return result;
      } catch (err) {
        setError(err);
        setIsLoading(false);
        throw err;
      }
    },
    { revalidateOnFocus: false, revalidateOnReconnect: false }
  );

  const post = async () => {
    try {
      await mutate();
    } catch (err) {
      console.error('Error posting data:', err);
    }
  };

  return { data, error, isLoading, post };
}
export function usePostSchools() {
  const url = endpoints.school.list;

  const { data, isLoading, error, isValidating } = useSWR(url, fetcherPost, swrOptions);

  const createSchool = async (schoolData) => {
    try {
      const response = await axiosInstance.post(url, schoolData);
      // Revalidate the cache to update the list of schools
      mutate(url);
      return response.data;
    } catch (error) {
      console.error('Error creating school:', error);
      throw error;
    }
  };

  const updateSchool = async (schoolId, schoolData) => {
    const updateUrl = `${url}/${schoolId}`;
    try {
      const response = await axios.put(updateUrl, schoolData);
      // Revalidate the cache to update the list of schools
      mutate(url);
      return response.data;
    } catch (error) {
      console.error('Error updating school:', error);
      throw error;
    }
  };

  const memoizedValue = useMemo(
    () => ({
      schools: data ?? [],
      schoolsLoading: isLoading,
      schoolsError: error,
      schoolsValidating: isValidating,
      schoolsEmpty: !isLoading && !data?.length,
      createSchool,
      updateSchool,
    }),
    [data, error, isLoading, isValidating]
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
