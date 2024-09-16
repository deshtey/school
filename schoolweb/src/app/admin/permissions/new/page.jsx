import { CONFIG } from 'src/config-global';
import { PermissionsEditView } from 'src/sections/permissions/view/permissions-edit-view';

// ----------------------------------------------------------------------

export const metadata = { title: `Create a new user | Dashboard - ${CONFIG.site.name}` };

export default function Page() {
  return <PermissionsEditView />;
}
