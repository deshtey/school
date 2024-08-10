'use client';

import { STORAGE_KEY } from './constant';
import { AuthContext } from '../auth-context';
import React, { useCallback, useEffect, useMemo } from 'react';
import { useDispatch, useSelector } from 'react-redux';

export function AuthProvider({ children }) {
  const dispatch = useDispatch();
  const { user, loading } = useSelector((state) => state.auth);

  const checkUserSession = useCallback(async () => {
    try {
      //dispatch(setLoading(true));
      const accessToken = sessionStorage.getItem(STORAGE_KEY);

      if (accessToken) {
        // Fetch user data using the access token
        // const userData = await fetchUserData(accessToken);
        // dispatch(setUser(userData));
      } else {
        dispatch(setUser(null));
      }
    } catch (error) {
      console.error(error);
      // dispatch(setUser(null));
    } finally {
      //dispatch(setLoading(false));
    }
  }, [dispatch]);

  useEffect(() => {
    checkUserSession();
  }, [checkUserSession]);

  const checkAuthenticated = user ? 'authenticated' : 'unauthenticated';
  const status = loading ? 'loading' : checkAuthenticated;

  const memoizedValue = useMemo(
    () => ({
      user: user
        ? {
            ...user,
            role: user?.role ?? 'admin',
          }
        : null,
      checkUserSession,
      loading: status === 'loading',
      authenticated: status === 'authenticated',
      unauthenticated: status === 'unauthenticated',
    }),
    [checkUserSession, user, status]
  );

  return <AuthContext.Provider value={memoizedValue}>{children}</AuthContext.Provider>;
}
