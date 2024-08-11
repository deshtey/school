import { _schools } from 'src/_mock/_school';
import { CONFIG } from 'src/config-global';

import { SchoolDetailsView } from 'src/sections/school/view';

// ----------------------------------------------------------------------

export const metadata = { title: `School details | Dashboard - ${CONFIG.site.name}` };

export default function Page({ params }) {
  const { id } = params;
  const currentSchool = {}; //_schools.find((school) => school.id === id);

  return <SchoolDetailsView school={currentSchool} />;
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
    return _schools.map((school) => ({ id: school.id }));
  }
  return [];
}
