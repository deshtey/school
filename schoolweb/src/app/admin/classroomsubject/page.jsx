import { CONFIG } from 'src/config-global';

import { ClassroomsubjectListView } from 'src/sections/classroomsubject/view';

// ----------------------------------------------------------------------

export const metadata = { title: `Classroomsubject list | Dashboard - ${CONFIG.site.name}` };

export default function Page() {
  return <ClassroomsubjectListView />;
}
