import { CONFIG } from 'src/config-global';

import { RolepermissionsListView } from 'src/sections/rolepermissions/view';

// ----------------------------------------------------------------------

export const metadata = { title: `Rolepermissions list | Dashboard - ${CONFIG.site.name}` };

export default function Page() {
  return <RolepermissionsListView />;
}
