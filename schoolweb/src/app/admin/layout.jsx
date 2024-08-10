import { CONFIG } from 'src/config-global';
import { AdminLayout } from 'src/layouts/admin';

import { AuthGuard } from 'src/auth/guard';

// ----------------------------------------------------------------------

export default function Layout({ children }) {
  if (CONFIG.auth.skip) {
    return <AdminLayout>{children}</AdminLayout>;
  }

  return (
    <AuthGuard>
      <AdminLayout>{children}</AdminLayout>
    </AuthGuard>
  );
}
