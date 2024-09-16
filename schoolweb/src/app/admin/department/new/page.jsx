import { CONFIG } from 'src/config-global';
import { DepartmentEditView } from 'src/sections/department/view/department-edit-view';

// ----------------------------------------------------------------------

export const metadata = { title: `Create a new user | Dashboard - ${CONFIG.site.name}` };

export default function Page() {
  return <DepartmentEditView />;
}
