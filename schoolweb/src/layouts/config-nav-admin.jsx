import { paths } from 'src/routes/paths';

import { CONFIG } from 'src/config-global';

import { SvgColor } from 'src/components/svg-color';

// ----------------------------------------------------------------------

const icon = (name) => <SvgColor src={`${CONFIG.site.basePath}/assets/icons/navbar/${name}.svg`} />;

const ICONS = {
  job: icon('ic-job'),
  blog: icon('ic-blog'),
  chat: icon('ic-chat'),
  mail: icon('ic-mail'),
  user: icon('ic-user'),
  file: icon('ic-file'),
  lock: icon('ic-lock'),
  tour: icon('ic-tour'),
  order: icon('ic-order'),
  label: icon('ic-label'),
  blank: icon('ic-blank'),
  kanban: icon('ic-kanban'),
  folder: icon('ic-folder'),
  course: icon('ic-course'),
  banking: icon('ic-banking'),
  booking: icon('ic-booking'),
  invoice: icon('ic-invoice'),
  product: icon('ic-product'),
  calendar: icon('ic-calendar'),
  disabled: icon('ic-disabled'),
  external: icon('ic-external'),
  menuItem: icon('ic-menu-item'),
  ecommerce: icon('ic-ecommerce'),
  analytics: icon('ic-analytics'),
  admin: icon('ic-admin'),
  parameter: icon('ic-parameter'),
};

// ----------------------------------------------------------------------

export const navData = [
  {
    subheader: 'Management',
    items: [
      {
        title: 'Roles and Permissions',
        path: paths.dashboard.group.root,
        icon: ICONS.user,
        children: [
          { title: 'Roles', path: paths.admin.roles.root },
          { title: 'Permissions', path: paths.admin.permissions.root },
          { title: 'RolePermissions', path: paths.admin.rolepermissions.root },
        ],
      },
    ],
  },
  /**
   * Overview
   */
  {
    subheader: 'Overview 6.0.0',
    items: [
      { title: 'Home', path: paths.admin.root, icon: ICONS.admin },
      { title: 'Schools', path: paths.admin.school.root, icon: ICONS.ecommerce },
      { title: 'Students', path: paths.admin.student.root, icon: ICONS.ecommerce },
      { title: 'Teachers', path: paths.admin.teacher.root, icon: ICONS.analytics },
      { title: 'SupportStaff', path: paths.admin.supportStaff.root, icon: ICONS.analytics },
      { title: 'Grades', path: paths.admin.grade.root, icon: ICONS.analytics },
      { title: 'Classrooms', path: paths.admin.classroom.root, icon: ICONS.analytics },
    ],
  },
];
