'use client';
import { useGetSupportStaff } from 'src/actions/supportStaff';
import { CONFIG } from 'src/config-global';

import { SupportStaffEditView } from 'src/sections/supportStaff/view/supportStaff-edit-view';

// ----------------------------------------------------------------------

export default function Page({ params }) {
  const { id } = params;
  const {
    supportStaff,
    supportStaffEmpty,
    supportStaffError,
    supportStaffLoading,
    supportStaffValidating,
  } = useGetSupportStaff(id);
  return <SupportStaffEditView supportStaff={supportStaff} />;
}
