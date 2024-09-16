'use client';
import { useGetRoles } from 'src/actions/roles';
import { CONFIG } from 'src/config-global';

import { RolesEditView } from 'src/sections/roles/view/roles-edit-view';

// ----------------------------------------------------------------------

export default function Page({ params }) {
  const { id } = params;
  const { roles, rolesEmpty, rolesError, rolesLoading, rolesValidating } = useGetRoles(id);

  return <RolesEditView roles={roles} />;
}
