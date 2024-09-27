import { CONFIG } from 'src/config-global';
import { ClassroomEditView } from 'src/sections/classroom/view/classroom-edit-view';

export const metadata = { title: `Create a new classroom - ${CONFIG.site.name}` };

export default function Page() {
  return <ClassroomEditView />;
}
