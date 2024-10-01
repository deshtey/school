import { CONFIG } from 'src/config-global';

import { SchoolsubjectListView } from 'src/sections/schoolsubject/view';

// ----------------------------------------------------------------------

export const metadata = { title: `Schoolsubject list | Dashboard - ${CONFIG.site.name}` };

export default function Page() {
  return <SchoolsubjectListView />;
}
