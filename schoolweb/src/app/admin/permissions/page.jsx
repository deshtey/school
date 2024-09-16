import { CONFIG } from 'src/config-global';

import { PermissionsListView } from 'src/sections/permissions/view';

// ----------------------------------------------------------------------

export const metadata = { title: `Permissions list | Dashboard - ${CONFIG.site.name}` };

export default function Page() {
  return <PermissionsListView />;
}
