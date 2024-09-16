import { CONFIG } from 'src/config-global';

import { RolesListView } from 'src/sections/roles/view';

// ----------------------------------------------------------------------

export const metadata = { title: `Roles list | Dashboard - ${CONFIG.site.name}` };

export default function Page() {
  return <RolesListView />;
}
