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

export function useGetRoles() {
  const url = endpoints.roles.list;

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);
  const memoizedValue = useMemo(
    () => ({
      roles: data ?? [],
      rolesLoading: isLoading,
      rolesError: error,
      rolesValidating: isValidating,
      rolesEmpty: !isLoading && !data?.length,
    }),
    [data, error, isLoading, isValidating]
  );

  return memoizedValue;
}

// ----------------------------------------------------------------------

export function useGetRole(id) {
  const url = `${endpoints.roles.details}/${id}`;
  // const url = [endpoints.roles.details, { params: { id } }];

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);

  const memoizedValue = useMemo(
    () => ({
      roles: data,
      rolesLoading: isLoading,
      rolesError: error,
      rolesValidating: isValidating,
      rolesEmpty: !isLoading && !data,
    }),
    [data?.roles, error, isLoading, isValidating]
  );

  return memoizedValue;
}

export const createRole = async (roleData) => {
  const url = endpoints.roles.create;
  try {
    const response = await axiosInstance.post(url, roleData, {
      headers: {
        'Content-Type': 'application/json',
      },
    });
    return response.data;
  } catch (error) {
    console.error('Error creating role:', error);
    throw error;
  }
};

export const deleteRole = async (roleId) => {
  const url = endpoints.roles.list;
  try {
    const response = await axiosInstance.delete(`${url}/${roleId}`);
    return response.data;
  } catch (error) {
    console.error('Error creating role:', error);
    throw error;
  }
};
