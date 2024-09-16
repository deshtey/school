import { CONFIG } from 'src/config-global';
import { RolesEditView } from 'src/sections/roles/view/roles-edit-view';

// ----------------------------------------------------------------------

export const metadata = { title: `Create a new user | Dashboard - ${CONFIG.site.name}` };

export default function Page() {
  return <RolesEditView />;
}
