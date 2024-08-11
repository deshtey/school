import { CONFIG } from 'src/config-global';
import { SchoolEditView } from 'src/sections/school/view/school-edit-view';

// ----------------------------------------------------------------------

export const metadata = { title: `Create a new user | Dashboard - ${CONFIG.site.name}` };

export default function Page() {
  return <SchoolEditView />;
}
