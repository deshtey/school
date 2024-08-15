import { _students } from 'src/_mock/_student';
import { CONFIG } from 'src/config-global';

import { StudentDetailsView } from 'src/sections/student/view';

// ----------------------------------------------------------------------

export const metadata = { title: `Student details | Dashboard - ${CONFIG.site.name}` };

export default function Page({ params }) {
  const { id } = params;
  const currentStudent = {}; //_students.find((student) => student.id === id);

  return <StudentDetailsView student={currentStudent} />;
}

// ----------------------------------------------------------------------

/**
 * [1] Default
 * Remove [1] and [2] if not using [2]
 */
const dynamic = CONFIG.isStaticExport ? 'auto' : 'force-dynamic';

export { dynamic };

/**
 * [2] Static exports
 * https://nextjs.org/docs/app/building-your-application/deploying/static-exports
 */
export async function generateStaticParams() {
  if (CONFIG.isStaticExport) {
    return _students.map((student) => ({ id: student.id }));
  }
  return [];
}
