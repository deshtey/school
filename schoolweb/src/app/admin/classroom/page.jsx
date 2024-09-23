import { CONFIG } from 'src/config-global';

import { ClassroomListView } from 'src/sections/classroom/view';

// ----------------------------------------------------------------------

export const metadata = { title: `Classroom list | Dashboard - ${CONFIG.site.name}` };

export default function Page() {
  return <ClassroomListView />;
}
