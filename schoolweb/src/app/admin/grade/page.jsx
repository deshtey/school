import { CONFIG } from 'src/config-global';

import { GradeListView } from 'src/sections/grade/view';

// ----------------------------------------------------------------------

export const metadata = { title: `Grade list | Dashboard - ${CONFIG.site.name}` };

export default function Page() {
  return <GradeListView />;
}
