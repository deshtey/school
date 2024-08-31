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

export function useGetTeachers() {
  const url = endpoints.teacher.list;

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);
  const memoizedValue = useMemo(
    () => ({
      teachers: data ?? [],
      teachersLoading: isLoading,
      teachersError: error,
      teachersValidating: isValidating,
      teachersEmpty: !isLoading && !data?.length,
    }),
    [data, error, isLoading, isValidating]
  );

  return memoizedValue;
}

// ----------------------------------------------------------------------

export function useGetTeacher(id) {
  const url = `${endpoints.teacher.details}/${id}`;
  // const url = [endpoints.teacher.details, { params: { id } }];

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);

  const memoizedValue = useMemo(
    () => ({
      teacher: data,
      teacherLoading: isLoading,
      teacherError: error,
      teacherValidating: isValidating,
      teacherEmpty: !isLoading && !data,
    }),
    [data?.teacher, error, isLoading, isValidating]
  );

  return memoizedValue;
}

export function usePostTeacher(parameters) {
  const url = endpoints.teacher.list;

  const key = `${url}-${JSON.stringify(parameters)}`;

  const { teacher, error, mutate } = useSWR(key, () => fetcherPost(url, parameters));

  return {
    teacher,
    error,
    mutate,
    isLoading: !data && !error,
  };
}

export function usePostTeachers1(params) {
  const url = endpoints.teacher.list;

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
export function usePostTeachers() {
  const url = endpoints.teacher.list;

  const { data, isLoading, error, isValidating } = useSWR(url, fetcherPost, swrOptions);

  const createTeacher = async (teacherData) => {
    try {
      const response = await axiosInstance.post(url, teacherData);
      // Revalidate the cache to update the list of teachers
      mutate(url);
      return response.data;
    } catch (error) {
      console.error('Error creating teacher:', error);
      throw error;
    }
  };

  const updateTeacher = async (teacherId, teacherData) => {
    const updateUrl = `${url}/${teacherId}`;
    try {
      const response = await axios.put(updateUrl, teacherData);
      // Revalidate the cache to update the list of teachers
      mutate(url);
      return response.data;
    } catch (error) {
      console.error('Error updating teacher:', error);
      throw error;
    }
  };

  const memoizedValue = useMemo(
    () => ({
      teachers: data ?? [],
      teachersLoading: isLoading,
      teachersError: error,
      teachersValidating: isValidating,
      teachersEmpty: !isLoading && !data?.length,
      createTeacher,
      updateTeacher,
    }),
    [data, error, isLoading, isValidating]
  );

  return memoizedValue;
}
// ----------------------------------------------------------------------

export function useGetLatestTeachers(title) {
  const url = title ? [endpoints.teacher.latest, { params: { title } }] : '';

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);

  const memoizedValue = useMemo(
    () => ({
      latestTeachers: data?.latestTeachers || [],
      latestTeachersLoading: isLoading,
      latestTeachersError: error,
      latestTeachersValidating: isValidating,
      latestTeachersEmpty: !isLoading && !data?.latestTeachers.length,
    }),
    [data?.latestTeachers, error, isLoading, isValidating]
  );

  return memoizedValue;
}

// ----------------------------------------------------------------------

export function useSearchTeachers(query) {
  const url = query ? [endpoints.teacher.search, { params: { query } }] : '';

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
