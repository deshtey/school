'use client';

import PropTypes from 'prop-types';

import { AuthGuard } from 'src/auth/guard';
import AdminLayout from 'src/layouts/admin';

// ----------------------------------------------------------------------

export default function Layout({ children }) {
  return (
    <AuthGuard>
      <AdminLayout>{children}</AdminLayout>
    </AuthGuard>
  );
}

Layout.propTypes = {
  children: PropTypes.node,
};
