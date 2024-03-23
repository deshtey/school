// ----------------------------------------------------------------------

const ROOTS = {
  AUTH: '/auth',
  DASHBOARD: '/dashboard',
};

// ----------------------------------------------------------------------

export const paths = {
  minimalUI: 'https://mui.com/store/items/minimal-dashboard/',
  // AUTH
  auth: {
    jwt: {
      login: `${ROOTS.AUTH}/jwt/login`,
      register: `${ROOTS.AUTH}/jwt/register`,
    },
  },
  // DASHBOARD
  dashboard: {
    root: ROOTS.DASHBOARD,
    one: `${ROOTS.DASHBOARD}/one`,
    two: `${ROOTS.DASHBOARD}/two`,
    three: `${ROOTS.DASHBOARD}/three`,
    group: {
      root: `${ROOTS.DASHBOARD}/group`,
      five: `${ROOTS.DASHBOARD}/group/five`,
      six: `${ROOTS.DASHBOARD}/group/six`,
    },
    schools: {
      list: `${ROOTS.DASHBOARD}/schools`,
      create: `${ROOTS.DASHBOARD}/schools/new`,
    },
    students: {
      list: `${ROOTS.DASHBOARD}/students`,
      create: `${ROOTS.DASHBOARD}/students/new`,
    },
    teachers: {
      list: `${ROOTS.DASHBOARD}/teachers`,
      create: `${ROOTS.DASHBOARD}/teachers/new`,
    },
    staff: {
      list: `${ROOTS.DASHBOARD}/staff`,
      create: `${ROOTS.DASHBOARD}/staff/new`,
    },
  },
};
