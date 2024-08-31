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

export function useGetGrades(schoolId = 2) {
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
  // const url = [endpoints.grade.details, { params: { id } }];

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

export function usePostGrade(parameters) {
  const url = endpoints.grade.list;

  const key = `${url}-${JSON.stringify(parameters)}`;

  const { grade, error, mutate } = useSWR(key, () => fetcherPost(url, parameters));

  return {
    grade,
    error,
    mutate,
    isLoading: !data && !error,
  };
}

export function usePostGrades1(params) {
  const url = endpoints.grade.list;

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
export function usePostGrades() {
  const url = endpoints.grade.list;

  const { data, isLoading, error, isValidating } = useSWR(url, fetcherPost, swrOptions);

  const createGrade = async (gradeData) => {
    try {
      const response = await axiosInstance.post(url, gradeData);
      // Revalidate the cache to update the list of grades
      mutate(url);
      return response.data;
    } catch (error) {
      console.error('Error creating grade:', error);
      throw error;
    }
  };

  const updateGrade = async (gradeId, gradeData) => {
    const updateUrl = `${url}/${gradeId}`;
    try {
      const response = await axios.put(updateUrl, gradeData);
      // Revalidate the cache to update the list of grades
      mutate(url);
      return response.data;
    } catch (error) {
      console.error('Error updating grade:', error);
      throw error;
    }
  };

  const memoizedValue = useMemo(
    () => ({
      grades: data ?? [],
      gradesLoading: isLoading,
      gradesError: error,
      gradesValidating: isValidating,
      gradesEmpty: !isLoading && !data?.length,
      createGrade,
      updateGrade,
    }),
    [data, error, isLoading, isValidating]
  );

  return memoizedValue;
}
// ----------------------------------------------------------------------

export function useGetLatestGrades(title) {
  const url = title ? [endpoints.grade.latest, { params: { title } }] : '';

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);

  const memoizedValue = useMemo(
    () => ({
      latestGrades: data?.latestGrades || [],
      latestGradesLoading: isLoading,
      latestGradesError: error,
      latestGradesValidating: isValidating,
      latestGradesEmpty: !isLoading && !data?.latestGrades.length,
    }),
    [data?.latestGrades, error, isLoading, isValidating]
  );

  return memoizedValue;
}

// ----------------------------------------------------------------------

export function useSearchGrades(query) {
  const url = query ? [endpoints.grade.search, { params: { query } }] : '';

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
