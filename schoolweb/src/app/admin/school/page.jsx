import { CONFIG } from 'src/config-global';

import { SchoolListView } from 'src/sections/school/view';

// ----------------------------------------------------------------------

export const metadata = { title: `School list | Dashboard - ${CONFIG.site.name}` };

export default function Page() {
  return <SchoolListView />;
}
