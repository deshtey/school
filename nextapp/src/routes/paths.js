import { paramCase } from 'src/utils/change-case';

import { _id, _postTitles } from 'src/_mock/assets';

// ----------------------------------------------------------------------

const MOCK_ID = _id[1];

const MOCK_TITLE = _postTitles[2];

const ROOTS = {
  AUTH: '/auth',
  AUTH_DEMO: '/auth-demo',
  DASHBOARD: '/dashboard',
  ADMIN: '/admin',
};

// ----------------------------------------------------------------------

export const paths = {
  comingSoon: '/coming-soon',
  maintenance: '/maintenance',
  pricing: '/pricing',
  payment: '/payment',
  about: '/about-us',
  contact: '/contact-us',
  faqs: '/faqs',
  page403: '/error/403',
  page404: '/error/404',
  page500: '/error/500',
  components: '/components',
  docs: 'https://docs.minimals.cc',
  changelog: 'https://docs.minimals.cc/changelog',
  zoneUI: 'https://mui.com/store/items/zone-landing-page/',
  minimalUI: 'https://mui.com/store/items/minimal-dashboard/',
  freeUI: 'https://mui.com/store/items/minimal-dashboard-free/',
  figma:
    'https://www.figma.com/file/hjxMnGUJCjY7pX8lQbS7kn/%5BPreview%5D-Minimal-Web.v5.4.0?type=design&node-id=0-1&mode=design&t=2fxnS70DuiTLGzND-0',
  product: {
    root: `/product`,
    checkout: `/product/checkout`,
    details: (id) => `/product/${id}`,
    demo: {
      details: `/product/${MOCK_ID}`,
    },
  },
  post: {
    root: `/post`,
    details: (title) => `/post/${paramCase(title)}`,
    demo: {
      details: `/post/${paramCase(MOCK_TITLE)}`,
    },
  },
  // AUTH
  auth: {
    amplify: {
      login: `${ROOTS.AUTH}/amplify/login`,
      verify: `${ROOTS.AUTH}/amplify/verify`,
      register: `${ROOTS.AUTH}/amplify/register`,
      newPassword: `${ROOTS.AUTH}/amplify/new-password`,
      forgotPassword: `${ROOTS.AUTH}/amplify/forgot-password`,
    },
    jwt: {
      login: `${ROOTS.AUTH}/jwt/login`,
      register: `${ROOTS.AUTH}/jwt/register`,
    },
    firebase: {
      login: `${ROOTS.AUTH}/firebase/login`,
      verify: `${ROOTS.AUTH}/firebase/verify`,
      register: `${ROOTS.AUTH}/firebase/register`,
      forgotPassword: `${ROOTS.AUTH}/firebase/forgot-password`,
    },
    auth0: {
      login: `${ROOTS.AUTH}/auth0/login`,
    },
    supabase: {
      login: `${ROOTS.AUTH}/supabase/login`,
      verify: `${ROOTS.AUTH}/supabase/verify`,
      register: `${ROOTS.AUTH}/supabase/register`,
      newPassword: `${ROOTS.AUTH}/supabase/new-password`,
      forgotPassword: `${ROOTS.AUTH}/supabase/forgot-password`,
    },
  },
  authDemo: {
    classic: {
      login: `${ROOTS.AUTH_DEMO}/classic/login`,
      register: `${ROOTS.AUTH_DEMO}/classic/register`,
      forgotPassword: `${ROOTS.AUTH_DEMO}/classic/forgot-password`,
      newPassword: `${ROOTS.AUTH_DEMO}/classic/new-password`,
      verify: `${ROOTS.AUTH_DEMO}/classic/verify`,
    },
    modern: {
      login: `${ROOTS.AUTH_DEMO}/modern/login`,
      register: `${ROOTS.AUTH_DEMO}/modern/register`,
      forgotPassword: `${ROOTS.AUTH_DEMO}/modern/forgot-password`,
      newPassword: `${ROOTS.AUTH_DEMO}/modern/new-password`,
      verify: `${ROOTS.AUTH_DEMO}/modern/verify`,
    },
  },
  // ADMIN
  admin: {
    root: ROOTS.ADMIN,
    mail: `${ROOTS.ADMIN}/mail`,
    chat: `${ROOTS.ADMIN}/chat`,
    blank: `${ROOTS.ADMIN}/blank`,
    kanban: `${ROOTS.ADMIN}/kanban`,
    calendar: `${ROOTS.ADMIN}/calendar`,
    fileManager: `${ROOTS.ADMIN}/file-manager`,
    permission: `${ROOTS.ADMIN}/permission`,
    general: {
      app: `${ROOTS.ADMIN}/app`,
      ecommerce: `${ROOTS.ADMIN}/ecommerce`,
      analytics: `${ROOTS.ADMIN}/analytics`,
      banking: `${ROOTS.ADMIN}/banking`,
      booking: `${ROOTS.ADMIN}/booking`,
      file: `${ROOTS.ADMIN}/file`,
    },
    user: {
      root: `${ROOTS.ADMIN}/user`,
      new: `${ROOTS.ADMIN}/user/new`,
      list: `${ROOTS.ADMIN}/user/list`,
      cards: `${ROOTS.ADMIN}/user/cards`,
      profile: `${ROOTS.ADMIN}/user/profile`,
      account: `${ROOTS.ADMIN}/user/account`,
      edit: (id) => `${ROOTS.ADMIN}/user/${id}/edit`,
      demo: {
        edit: `${ROOTS.ADMIN}/user/${MOCK_ID}/edit`,
      },
    },
    product: {
      root: `${ROOTS.ADMIN}/product`,
      new: `${ROOTS.ADMIN}/product/new`,
      details: (id) => `${ROOTS.ADMIN}/product/${id}`,
      edit: (id) => `${ROOTS.ADMIN}/product/${id}/edit`,
      demo: {
        details: `${ROOTS.ADMIN}/product/${MOCK_ID}`,
        edit: `${ROOTS.ADMIN}/product/${MOCK_ID}/edit`,
      },
    },
    invoice: {
      root: `${ROOTS.ADMIN}/invoice`,
      new: `${ROOTS.ADMIN}/invoice/new`,
      details: (id) => `${ROOTS.ADMIN}/invoice/${id}`,
      edit: (id) => `${ROOTS.ADMIN}/invoice/${id}/edit`,
      demo: {
        details: `${ROOTS.ADMIN}/invoice/${MOCK_ID}`,
        edit: `${ROOTS.ADMIN}/invoice/${MOCK_ID}/edit`,
      },
    },
    post: {
      root: `${ROOTS.ADMIN}/post`,
      new: `${ROOTS.ADMIN}/post/new`,
      details: (title) => `${ROOTS.ADMIN}/post/${paramCase(title)}`,
      edit: (title) => `${ROOTS.ADMIN}/post/${paramCase(title)}/edit`,
      demo: {
        details: `${ROOTS.ADMIN}/post/${paramCase(MOCK_TITLE)}`,
        edit: `${ROOTS.ADMIN}/post/${paramCase(MOCK_TITLE)}/edit`,
      },
    },
    order: {
      root: `${ROOTS.ADMIN}/order`,
      details: (id) => `${ROOTS.ADMIN}/order/${id}`,
      demo: {
        details: `${ROOTS.ADMIN}/order/${MOCK_ID}`,
      },
    },
    job: {
      root: `${ROOTS.ADMIN}/job`,
      new: `${ROOTS.ADMIN}/job/new`,
      details: (id) => `${ROOTS.ADMIN}/job/${id}`,
      edit: (id) => `${ROOTS.ADMIN}/job/${id}/edit`,
      demo: {
        details: `${ROOTS.ADMIN}/job/${MOCK_ID}`,
        edit: `${ROOTS.ADMIN}/job/${MOCK_ID}/edit`,
      },
    },
    tour: {
      root: `${ROOTS.ADMIN}/tour`,
      new: `${ROOTS.ADMIN}/tour/new`,
      details: (id) => `${ROOTS.ADMIN}/tour/${id}`,
      edit: (id) => `${ROOTS.ADMIN}/tour/${id}/edit`,
      demo: {
        details: `${ROOTS.ADMIN}/tour/${MOCK_ID}`,
        edit: `${ROOTS.ADMIN}/tour/${MOCK_ID}/edit`,
      },
    },
  },
  // DASHBOARD
  dashboard: {
    root: ROOTS.DASHBOARD,
    mail: `${ROOTS.DASHBOARD}/mail`,
    chat: `${ROOTS.DASHBOARD}/chat`,
    blank: `${ROOTS.DASHBOARD}/blank`,
    kanban: `${ROOTS.DASHBOARD}/kanban`,
    calendar: `${ROOTS.DASHBOARD}/calendar`,
    fileManager: `${ROOTS.DASHBOARD}/file-manager`,
    permission: `${ROOTS.DASHBOARD}/permission`,
    general: {
      app: `${ROOTS.DASHBOARD}/app`,
      ecommerce: `${ROOTS.DASHBOARD}/ecommerce`,
      analytics: `${ROOTS.DASHBOARD}/analytics`,
      banking: `${ROOTS.DASHBOARD}/banking`,
      booking: `${ROOTS.DASHBOARD}/booking`,
      file: `${ROOTS.DASHBOARD}/file`,
    },
    user: {
      root: `${ROOTS.DASHBOARD}/user`,
      new: `${ROOTS.DASHBOARD}/user/new`,
      list: `${ROOTS.DASHBOARD}/user/list`,
      cards: `${ROOTS.DASHBOARD}/user/cards`,
      profile: `${ROOTS.DASHBOARD}/user/profile`,
      account: `${ROOTS.DASHBOARD}/user/account`,
      edit: (id) => `${ROOTS.DASHBOARD}/user/${id}/edit`,
      demo: {
        edit: `${ROOTS.DASHBOARD}/user/${MOCK_ID}/edit`,
      },
    },
    product: {
      root: `${ROOTS.DASHBOARD}/product`,
      new: `${ROOTS.DASHBOARD}/product/new`,
      details: (id) => `${ROOTS.DASHBOARD}/product/${id}`,
      edit: (id) => `${ROOTS.DASHBOARD}/product/${id}/edit`,
      demo: {
        details: `${ROOTS.DASHBOARD}/product/${MOCK_ID}`,
        edit: `${ROOTS.DASHBOARD}/product/${MOCK_ID}/edit`,
      },
    },
    invoice: {
      root: `${ROOTS.DASHBOARD}/invoice`,
      new: `${ROOTS.DASHBOARD}/invoice/new`,
      details: (id) => `${ROOTS.DASHBOARD}/invoice/${id}`,
      edit: (id) => `${ROOTS.DASHBOARD}/invoice/${id}/edit`,
      demo: {
        details: `${ROOTS.DASHBOARD}/invoice/${MOCK_ID}`,
        edit: `${ROOTS.DASHBOARD}/invoice/${MOCK_ID}/edit`,
      },
    },
    post: {
      root: `${ROOTS.DASHBOARD}/post`,
      new: `${ROOTS.DASHBOARD}/post/new`,
      details: (title) => `${ROOTS.DASHBOARD}/post/${paramCase(title)}`,
      edit: (title) => `${ROOTS.DASHBOARD}/post/${paramCase(title)}/edit`,
      demo: {
        details: `${ROOTS.DASHBOARD}/post/${paramCase(MOCK_TITLE)}`,
        edit: `${ROOTS.DASHBOARD}/post/${paramCase(MOCK_TITLE)}/edit`,
      },
    },
    order: {
      root: `${ROOTS.DASHBOARD}/order`,
      details: (id) => `${ROOTS.DASHBOARD}/order/${id}`,
      demo: {
        details: `${ROOTS.DASHBOARD}/order/${MOCK_ID}`,
      },
    },
    job: {
      root: `${ROOTS.DASHBOARD}/job`,
      new: `${ROOTS.DASHBOARD}/job/new`,
      details: (id) => `${ROOTS.DASHBOARD}/job/${id}`,
      edit: (id) => `${ROOTS.DASHBOARD}/job/${id}/edit`,
      demo: {
        details: `${ROOTS.DASHBOARD}/job/${MOCK_ID}`,
        edit: `${ROOTS.DASHBOARD}/job/${MOCK_ID}/edit`,
      },
    },
    tour: {
      root: `${ROOTS.DASHBOARD}/tour`,
      new: `${ROOTS.DASHBOARD}/tour/new`,
      details: (id) => `${ROOTS.DASHBOARD}/tour/${id}`,
      edit: (id) => `${ROOTS.DASHBOARD}/tour/${id}/edit`,
      demo: {
        details: `${ROOTS.DASHBOARD}/tour/${MOCK_ID}`,
        edit: `${ROOTS.DASHBOARD}/tour/${MOCK_ID}/edit`,
      },
    },
  },
};
