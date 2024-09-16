'use client';
import { useGetRolepermissions } from 'src/actions/rolepermissions';
import { CONFIG } from 'src/config-global';

import { RolepermissionsEditView } from 'src/sections/rolepermissions/view/rolepermissions-edit-view';

// ----------------------------------------------------------------------

export default function Page({ params }) {
  const { id } = params;
  const {
    rolepermissions,
    rolepermissionsEmpty,
    rolepermissionsError,
    rolepermissionsLoading,
    rolepermissionsValidating,
  } = useGetRolepermissions(id);

  return <RolepermissionsEditView rolepermissions={rolepermissions} />;
}
