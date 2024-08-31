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

export function useGetSupportStaffs() {
  const url = endpoints.supportStaff.list;

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);
  const memoizedValue = useMemo(
    () => ({
      supportStaffs: data ?? [],
      supportStaffsLoading: isLoading,
      supportStaffsError: error,
      supportStaffsValidating: isValidating,
      supportStaffsEmpty: !isLoading && !data?.length,
    }),
    [data, error, isLoading, isValidating]
  );

  return memoizedValue;
}

// ----------------------------------------------------------------------

export function useGetSupportStaff(id) {
  const url = `${endpoints.supportStaff.details}/${id}`;
  // const url = [endpoints.supportStaff.details, { params: { id } }];

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);

  const memoizedValue = useMemo(
    () => ({
      supportStaff: data,
      supportStaffLoading: isLoading,
      supportStaffError: error,
      supportStaffValidating: isValidating,
      supportStaffEmpty: !isLoading && !data,
    }),
    [data?.supportStaff, error, isLoading, isValidating]
  );

  return memoizedValue;
}

export function usePostSupportStaff(parameters) {
  const url = endpoints.supportStaff.list;

  const key = `${url}-${JSON.stringify(parameters)}`;

  const { supportStaff, error, mutate } = useSWR(key, () => fetcherPost(url, parameters));

  return {
    supportStaff,
    error,
    mutate,
    isLoading: !data && !error,
  };
}

export function usePostSupportStaffs1(params) {
  const url = endpoints.supportStaff.list;

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
export function usePostSupportStaffs() {
  const url = endpoints.supportStaff.list;

  const { data, isLoading, error, isValidating } = useSWR(url, fetcherPost, swrOptions);

  const createSupportStaff = async (supportStaffData) => {
    try {
      const response = await axiosInstance.post(url, supportStaffData);
      // Revalidate the cache to update the list of supportStaffs
      mutate(url);
      return response.data;
    } catch (error) {
      console.error('Error creating supportStaff:', error);
      throw error;
    }
  };

  const updateSupportStaff = async (supportStaffId, supportStaffData) => {
    const updateUrl = `${url}/${supportStaffId}`;
    try {
      const response = await axios.put(updateUrl, supportStaffData);
      // Revalidate the cache to update the list of supportStaffs
      mutate(url);
      return response.data;
    } catch (error) {
      console.error('Error updating supportStaff:', error);
      throw error;
    }
  };

  const memoizedValue = useMemo(
    () => ({
      supportStaffs: data ?? [],
      supportStaffsLoading: isLoading,
      supportStaffsError: error,
      supportStaffsValidating: isValidating,
      supportStaffsEmpty: !isLoading && !data?.length,
      createSupportStaff,
      updateSupportStaff,
    }),
    [data, error, isLoading, isValidating]
  );

  return memoizedValue;
}
// ----------------------------------------------------------------------

export function useGetLatestSupportStaffs(title) {
  const url = title ? [endpoints.supportStaff.latest, { params: { title } }] : '';

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);

  const memoizedValue = useMemo(
    () => ({
      latestSupportStaffs: data?.latestSupportStaffs || [],
      latestSupportStaffsLoading: isLoading,
      latestSupportStaffsError: error,
      latestSupportStaffsValidating: isValidating,
      latestSupportStaffsEmpty: !isLoading && !data?.latestSupportStaffs.length,
    }),
    [data?.latestSupportStaffs, error, isLoading, isValidating]
  );

  return memoizedValue;
}

// ----------------------------------------------------------------------

export function useSearchSupportStaffs(query) {
  const url = query ? [endpoints.supportStaff.search, { params: { query } }] : '';

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
