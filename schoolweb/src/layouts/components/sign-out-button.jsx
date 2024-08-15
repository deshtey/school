import { useCallback } from 'react';

import Button from '@mui/material/Button';

import { useRouter } from 'src/routes/hooks';

import { useAuthContext } from 'src/auth/hooks';
import { signOut } from 'src/auth/context/jwt/action';
import { useDispatch } from 'react-redux';
import { logout, signIn } from 'src/lib/authSlice';

// ----------------------------------------------------------------------

export function SignOutButton({ onClose, ...other }) {
  const router = useRouter();
  const dispatch = useDispatch();
  const { checkUserSession } = useAuthContext();

  const handleLogout = useCallback(async () => {
    try {
      dispatch(logout());
      await checkUserSession?.();

      onClose?.();
      router.refresh();
    } catch (error) {
      console.error(error);
    }
  }, [checkUserSession, onClose, router]);

  return (
    <Button fullWidth variant="soft" size="large" color="error" onClick={handleLogout} {...other}>
      Logout
    </Button>
  );
}
