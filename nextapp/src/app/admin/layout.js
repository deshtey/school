'use client';

import PropTypes from 'prop-types';
import { QueryClient, QueryClientProvider } from 'react-query';
import { AuthGuard } from 'src/auth/guard';
import AdminLayout from 'src/layouts/admin';

// ----------------------------------------------------------------------
const queryClient = new QueryClient();
export default function Layout({ children }) {
  return (
    <QueryClientProvider client={queryClient}>

    <AuthGuard>
      <AdminLayout>{children}</AdminLayout>
    </AuthGuard>
    </QueryClientProvider>
  );
}

Layout.propTypes = {
  children: PropTypes.node,
};
