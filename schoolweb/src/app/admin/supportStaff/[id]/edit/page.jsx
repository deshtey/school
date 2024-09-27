import { CONFIG } from 'src/config-global';
import { SupportStaffEditView } from 'src/sections/supportStaff/view/supportStaff-edit-view';

// ----------------------------------------------------------------------

export const metadata = { title: `Create a new user | Dashboard - ${CONFIG.site.name}` };

export default function Page() {
  return <SupportStaffEditView />;
}
