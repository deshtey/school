import { CONFIG } from 'src/config-global';

import { DepartmentListView } from 'src/sections/department/view';

// ----------------------------------------------------------------------

export const metadata = { title: `Department list | Dashboard - ${CONFIG.site.name}` };

export default function Page() {
  return <DepartmentListView />;
}
