import { CONFIG } from 'src/config-global';

import { TeacherListView } from 'src/sections/teacher/view';

// ----------------------------------------------------------------------

export const metadata = { title: `Teacher list | Dashboard - ${CONFIG.site.name}` };

export default function Page() {
  return <TeacherListView />;
}
