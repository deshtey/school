import { CONFIG } from 'src/config-global';
import { RolepermissionsEditView } from 'src/sections/rolepermissions/view/rolepermissions-edit-view';

// ----------------------------------------------------------------------

export const metadata = { title: `Create a new user | Dashboard - ${CONFIG.site.name}` };

export default function Page() {
  return <RolepermissionsEditView />;
}
