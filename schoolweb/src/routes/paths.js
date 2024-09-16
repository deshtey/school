// ----------------------------------------------------------------------

const ROOTS = {
  AUTH: '/auth',
  DASHBOARD: '/dashboard',
  ADMIN: '/admin',
};

// ----------------------------------------------------------------------

export const paths = {
  faqs: '/faqs',
  minimalStore: 'https://mui.com/store/items/minimal-dashboard/',
  // AUTH
  auth: {
    amplify: {
      signIn: `${ROOTS.AUTH}/amplify/sign-in`,
      verify: `${ROOTS.AUTH}/amplify/verify`,
      signUp: `${ROOTS.AUTH}/amplify/sign-up`,
      updatePassword: `${ROOTS.AUTH}/amplify/update-password`,
      resetPassword: `${ROOTS.AUTH}/amplify/reset-password`,
    },
    jwt: {
      signIn: `${ROOTS.AUTH}/jwt/sign-in`,
      signUp: `${ROOTS.AUTH}/jwt/sign-up`,
    },
    firebase: {
      signIn: `${ROOTS.AUTH}/firebase/sign-in`,
      verify: `${ROOTS.AUTH}/firebase/verify`,
      signUp: `${ROOTS.AUTH}/firebase/sign-up`,
      resetPassword: `${ROOTS.AUTH}/firebase/reset-password`,
    },
    auth0: {
      signIn: `${ROOTS.AUTH}/auth0/sign-in`,
    },
    supabase: {
      signIn: `${ROOTS.AUTH}/supabase/sign-in`,
      verify: `${ROOTS.AUTH}/supabase/verify`,
      signUp: `${ROOTS.AUTH}/supabase/sign-up`,
      updatePassword: `${ROOTS.AUTH}/supabase/update-password`,
      resetPassword: `${ROOTS.AUTH}/supabase/reset-password`,
    },
  },
  admin: {
    root: ROOTS.ADMIN,
    //school: `${ROOTS.ADMIN}/school`,

    school: {
      root: `${ROOTS.ADMIN}/school`,
      new: `${ROOTS.ADMIN}/school/new`,
      list: `${ROOTS.ADMIN}/school/list`,
      cards: `${ROOTS.ADMIN}/school/cards`,
      details: (id) => `${ROOTS.ADMIN}/school/${id}`,
      edit: (id) => `${ROOTS.ADMIN}/school/${id}/edit`,
    },
    student: {
      root: `${ROOTS.ADMIN}/student`,
      new: `${ROOTS.ADMIN}/student/new`,
      list: `${ROOTS.ADMIN}/student/list`,
      cards: `${ROOTS.ADMIN}/student/cards`,
      profile: `${ROOTS.ADMIN}/student/profile`,
      account: `${ROOTS.ADMIN}/student/account`,
      edit: (id) => `${ROOTS.ADMIN}/student/${id}/edit`,
    },
    teacher: {
      root: `${ROOTS.ADMIN}/teacher`,
      new: `${ROOTS.ADMIN}/teacher/new`,
      list: `${ROOTS.ADMIN}/teacher/list`,
      cards: `${ROOTS.ADMIN}/teacher/cards`,
      details: (id) => `${ROOTS.ADMIN}/teacher/${id}`,
      edit: (id) => `${ROOTS.ADMIN}/teacher/${id}/edit`,
    },
    supportStaff: {
      root: `${ROOTS.ADMIN}/supportStaff`,
      new: `${ROOTS.ADMIN}/supportStaff/new`,
      list: `${ROOTS.ADMIN}/supportStaff/list`,
      cards: `${ROOTS.ADMIN}/supportStaff/cards`,
      details: (id) => `${ROOTS.ADMIN}/supportStaff/${id}`,
      edit: (id) => `${ROOTS.ADMIN}/supportStaff/${id}/edit`,
    },
    department: {
      root: `${ROOTS.ADMIN}/department`,
      new: `${ROOTS.ADMIN}/department/new`,
      list: `${ROOTS.ADMIN}/department/list`,
      details: (id) => `${ROOTS.ADMIN}/department/${id}`,
      edit: (id) => `${ROOTS.ADMIN}/department/${id}/edit`,
    },
    grade: {
      root: `${ROOTS.ADMIN}/grade`,
      new: `${ROOTS.ADMIN}/grade/new`,
      list: `${ROOTS.ADMIN}/grade/list`,
      details: (id) => `${ROOTS.ADMIN}/grade/${id}`,
      edit: (id) => `${ROOTS.ADMIN}/grade/${id}/edit`,
    },
    permissions: {
      root: `${ROOTS.ADMIN}/permissions`,
      new: `${ROOTS.ADMIN}/permissions/new`,
      list: `${ROOTS.ADMIN}/permissions/list`,
      details: (id) => `${ROOTS.ADMIN}/permissions/${id}`,
      edit: (id) => `${ROOTS.ADMIN}/permissions/${id}/edit`,
    },
    rolepermissions: {
      root: `${ROOTS.ADMIN}/rolepermissions`,
      new: `${ROOTS.ADMIN}/rolepermissions/new`,
      list: `${ROOTS.ADMIN}/rolepermissions/list`,
      details: (id) => `${ROOTS.ADMIN}/rolepermissions/${id}`,
      edit: (id) => `${ROOTS.ADMIN}/rolepermissions/${id}/edit`,
    },
    roles: {
      root: `${ROOTS.ADMIN}/roles`,
      new: `${ROOTS.ADMIN}/roles/new`,
      list: `${ROOTS.ADMIN}/roles/list`,
      details: (id) => `${ROOTS.ADMIN}/roles/${id}`,
      edit: (id) => `${ROOTS.ADMIN}/roles/${id}/edit`,
    },
    three: `${ROOTS.ADMIN}/three`,

    group: {
      root: `${ROOTS.ADMIN}/group`,
      five: `${ROOTS.ADMIN}/group/five`,
      six: `${ROOTS.ADMIN}/group/six`,
    },
  },
  // DASHBOARD
  dashboard: {
    root: ROOTS.DASHBOARD,
    two: `${ROOTS.DASHBOARD}/two`,
    three: `${ROOTS.DASHBOARD}/three`,
    group: {
      root: `${ROOTS.DASHBOARD}/group`,
      five: `${ROOTS.DASHBOARD}/group/five`,
      six: `${ROOTS.DASHBOARD}/group/six`,
    },
  },
};
