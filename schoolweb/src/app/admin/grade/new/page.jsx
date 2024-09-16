import { CONFIG } from 'src/config-global';
import { GradeEditView } from 'src/sections/grade/view/grade-edit-view';

// ----------------------------------------------------------------------

export const metadata = { title: `Create a new user | Dashboard - ${CONFIG.site.name}` };

export default function Page() {
  return <GradeEditView />;
}
