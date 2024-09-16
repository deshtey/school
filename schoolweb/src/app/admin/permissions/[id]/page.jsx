'use client';
import { useGetPermissions } from 'src/actions/permissions';
import { CONFIG } from 'src/config-global';

import { PermissionsEditView } from 'src/sections/permissions/view/permissions-edit-view';

// ----------------------------------------------------------------------

export default function Page({ params }) {
  const { id } = params;
  const {
    permissions,
    permissionsEmpty,
    permissionsError,
    permissionsLoading,
    permissionsValidating,
  } = useGetPermissions(id);

  return <PermissionsEditView permissions={permissions} />;
}
