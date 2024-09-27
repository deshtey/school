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

export function useGetClassrooms(schoolId = 2) {
  const url = `${endpoints.classroom.list}/${schoolId}`;

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);
  const memoizedValue = useMemo(
    () => ({
      classrooms: data ?? [],
      classroomsLoading: isLoading,
      classroomsError: error,
      classroomsValidating: isValidating,
      classroomsEmpty: !isLoading && !data?.length,
    }),
    [data, error, isLoading, isValidating]
  );

  return memoizedValue;
}

// ----------------------------------------------------------------------

export function useGetClassroom(id) {
  const url = `${endpoints.classroom.details}/${id}`;
  // const url = [endpoints.classroom.details, { params: { id } }];

  const { data, isLoading, error, isValidating } = useSWR(url, fetcher, swrOptions);

  const memoizedValue = useMemo(
    () => ({
      classroom: data,
      classroomLoading: isLoading,
      classroomError: error,
      classroomValidating: isValidating,
      classroomEmpty: !isLoading && !data,
    }),
    [data?.classroom, error, isLoading, isValidating]
  );

  return memoizedValue;
}

export const createClassroom = async (classroomData) => {
  const url = endpoints.classroom.create;
  try {
    const response = await axiosInstance.post(url, classroomData);
    return response.data;
  } catch (error) {
    console.error('Error creating classroom:', error);
    throw error;
  }
};
