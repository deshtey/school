import { CONFIG } from 'src/config-global';
import { StudentEditView } from 'src/sections/student/view/student-edit-view';

// ----------------------------------------------------------------------

export const metadata = { title: `Edit student | Dashboard - ${CONFIG.site.name}` };

export default function Page() {
  return <StudentEditView />;
}
