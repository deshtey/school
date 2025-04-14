'use client';

import { CONFIG } from '@/config-global';
import { useAppSelector } from '@/lib/features/store';
import { paths } from '@/routes/routes';
import { usePathname, useRouter, useSearchParams } from 'next/navigation';
import { useState, useEffect, useCallback } from 'react';
import { useSelector } from 'react-redux';

// ----------------------------------------------------------------------

export function AuthGuard({ children }: { children: React.ReactNode }) {
  const router = useRouter();

  const pathname = usePathname();

  const searchParams = useSearchParams();

  const { user, loading, isAuthenticated } = useAppSelector((state) => state.auth);

  const [isChecking, setIsChecking] = useState(true);

  const createQueryString = useCallback(
    (name: string, value:any) => {
      const params = new URLSearchParams(searchParams?.toString());
      params.set(name, value);

      return params.toString();
    },
    [searchParams]
  );

  const checkPermissions = async () => {
    console.log(loading);
    console.log(isAuthenticated);
    if (loading) {
      return;
    }

    if (!isAuthenticated) {
      const { method } = CONFIG.auth;

      const signInPath = {
        jwt: paths.auth.jwt.signIn,
        auth0: paths.auth.auth0.signIn,
        amplify: paths.auth.amplify.signIn,
        firebase: paths.auth.firebase.signIn,
        supabase: paths.auth.supabase.signIn,
      }[method];

      const href = `${signInPath}?${createQueryString('returnTo', pathname)}`;

      router.replace(href);
      return;
    }

    setIsChecking(false);
  };

  useEffect(() => {
    checkPermissions();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [isAuthenticated, loading]);

  if (isChecking) {
    return <div className="flex items-center justify-center w-full h-screen bg-white dark:bg-dark-800">
      <svg className="animate-spin -ml-1 mr-3 h-12 w-12 text-memorial-400" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
        <circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle>
        <path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
      </svg>
    </div>;
  }

  return <>{children}</>;
}
