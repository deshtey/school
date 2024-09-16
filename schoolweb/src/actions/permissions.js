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

export function useGetPermissions() {
  const url = endpoints.permissions.list;

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);
  const memoizedValue = useMemo(
    () => ({
      permissions: data ?? [],
      permissionsLoading: isLoading,
      permissionsError: error,
      permissionsValidating: isValidating,
      permissionsEmpty: !isLoading && !data?.length,
    }),
    [data, error, isLoading, isValidating]
  );

  return memoizedValue;
}

// ----------------------------------------------------------------------

export function useGetPermission(id) {
  const url = `${endpoints.permissions.details}/${id}`;
  // const url = [endpoints.permissions.details, { params: { id } }];

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);

  const memoizedValue = useMemo(
    () => ({
      permissions: data,
      permissionsLoading: isLoading,
      permissionsError: error,
      permissionsValidating: isValidating,
      permissionsEmpty: !isLoading && !data,
    }),
    [data?.permissions, error, isLoading, isValidating]
  );

  return memoizedValue;
}
