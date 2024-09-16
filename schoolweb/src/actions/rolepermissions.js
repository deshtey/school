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

export function useGetRolepermissions() {
  const url = endpoints.rolepermissions.list;

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);
  const memoizedValue = useMemo(
    () => ({
      rolepermissions: data ?? [],
      rolepermissionsLoading: isLoading,
      rolepermissionsError: error,
      rolepermissionsValidating: isValidating,
      rolepermissionsEmpty: !isLoading && !data?.length,
    }),
    [data, error, isLoading, isValidating]
  );

  return memoizedValue;
}

// ----------------------------------------------------------------------

export function useGetRolepermission(id) {
  const url = `${endpoints.rolepermissions.details}/${id}`;
  // const url = [endpoints.rolepermissions.details, { params: { id } }];

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);

  const memoizedValue = useMemo(
    () => ({
      rolepermissions: data,
      rolepermissionsLoading: isLoading,
      rolepermissionsError: error,
      rolepermissionsValidating: isValidating,
      rolepermissionsEmpty: !isLoading && !data,
    }),
    [data?.rolepermissions, error, isLoading, isValidating]
  );

  return memoizedValue;
}
