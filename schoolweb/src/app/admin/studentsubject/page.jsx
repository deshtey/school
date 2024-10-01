import { CONFIG } from 'src/config-global';

import { StudentsubjectListView } from 'src/sections/studentsubject/view';

// ----------------------------------------------------------------------

export const metadata = { title: `Studentsubject list | Dashboard - ${CONFIG.site.name}` };

export default function Page() {
  return <StudentsubjectListView />;
}
