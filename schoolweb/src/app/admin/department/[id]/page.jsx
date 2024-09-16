'use client';
import { useGetDepartment } from 'src/actions/department';
import { CONFIG } from 'src/config-global';

import { DepartmentEditView } from 'src/sections/department/view/department-edit-view';

// ----------------------------------------------------------------------

export default function Page({ params }) {
  const { id } = params;
  const { department, departmentEmpty, departmentError, departmentLoading, departmentValidating } =
    useGetDepartment(id);

  return <DepartmentEditView department={department} />;
}
