import { CONFIG } from 'src/config-global';
import { TeacherEditView } from 'src/sections/teacher/view/teacher-edit-view';

// ----------------------------------------------------------------------

export const metadata = { title: `Create a new user | Dashboard - ${CONFIG.site.name}` };

export default function Page() {
  return <TeacherEditView />;
}
