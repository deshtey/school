import { CONFIG } from 'src/config-global';

import { SupportStaffListView } from 'src/sections/supportStaff/view';

// ----------------------------------------------------------------------

export const metadata = { title: `SupportStaff list | Dashboard - ${CONFIG.site.name}` };

export default function Page() {
  return <SupportStaffListView />;
}
