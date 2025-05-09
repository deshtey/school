'use client';
import React, { useEffect, useCallback, useMemo } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { STORAGE_KEY } from './constant';
import { isValidToken, setSession } from './utils';
import { AuthContext } from '../auth-context';
import { setAuthenticated, setLoading, setUser } from 'src/lib/authSlice';

export function AuthProvider({ children }) {
  const dispatch = useDispatch();
  const { user, loading, isAuthenticated } = useSelector((state) => state.auth);

  const checkUserSession = useCallback(async () => {
    try {
      dispatch(setLoading(true));
      const accessToken = sessionStorage.getItem(STORAGE_KEY);
      let user = {};
      if (accessToken && isValidToken(accessToken)) {
        dispatch(setAuthenticated(true));

        const userData = localStorage.getItem('user');
        try {
          user = JSON.parse(userData);
          //const res = await axios.get(endpoints.auth.me);
          dispatch(setUser({ ...user, accessToken }));
        } catch (error) {
          console.log(error);
        }
        setSession(accessToken, user);
      } else {
        //dispatch(setUser(null));
        //dispatch(setAuthenticated(false));
      }
    } catch (error) {
      console.error('Error checking user session:', error);
      dispatch(setUser(null));
      dispatch(setAuthenticated(false));
    } finally {
      dispatch(setLoading(false));
    }
  }, [dispatch]);

  useEffect(() => {
    checkUserSession();
  }, [checkUserSession]);

  const status = loading ? 'loading' : isAuthenticated ? 'authenticated' : 'unauthenticated';
  const memoizedValue = useMemo(
    () => ({
      user: user ? { ...user, role: user?.role ?? 'admin' } : null,
      checkUserSession,
      loading: status === 'loading',
      authenticated: status === 'authenticated',
      unauthenticated: status === 'unauthenticated',
    }),
    [checkUserSession, user, status]
  );

  return <AuthContext.Provider value={memoizedValue}>{children}</AuthContext.Provider>;
}
