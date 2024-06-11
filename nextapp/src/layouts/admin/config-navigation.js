import { useMemo } from 'react';

import { paths } from 'src/routes/paths';

import { useTranslate } from 'src/locales';

import Label from 'src/components/label';
import Iconify from 'src/components/iconify';
import SvgColor from 'src/components/svg-color';

// ----------------------------------------------------------------------

const icon = (name) => (
  <SvgColor src={`/assets/icons/navbar/${name}.svg`} sx={{ width: 1, height: 1 }} />
  // OR
  // <Iconify icon="fluent:mail-24-filled" />
  // https://icon-sets.iconify.design/solar/
  // https://www.streamlinehq.com/icons
);

const ICONS = {
  job: icon('ic_job'),
  blog: icon('ic_blog'),
  chat: icon('ic_chat'),
  mail: icon('ic_mail'),
  user: icon('ic_user'),
  file: icon('ic_file'),
  lock: icon('ic_lock'),
  tour: icon('ic_tour'),
  order: icon('ic_order'),
  label: icon('ic_label'),
  blank: icon('ic_blank'),
  kanban: icon('ic_kanban'),
  folder: icon('ic_folder'),
  banking: icon('ic_banking'),
  booking: icon('ic_booking'),
  invoice: icon('ic_invoice'),
  product: icon('ic_product'),
  calendar: icon('ic_calendar'),
  disabled: icon('ic_disabled'),
  external: icon('ic_external'),
  menuItem: icon('ic_menu_item'),
  ecommerce: icon('ic_ecommerce'),
  analytics: icon('ic_analytics'),
  admin: icon('ic_admin'),
};

// ----------------------------------------------------------------------

export function useNavData() {
  const { t } = useTranslate();

  const data = useMemo(
    () => [
      // OVERVIEW
      // ----------------------------------------------------------------------
      {
        subheader: t('overview'),
        items: [
          {
            title: t('app'),
            path: paths.admin.root,
            icon: ICONS.admin,
          },
          {
            title: t('ecommerce'),
            path: paths.admin.general.ecommerce,
            icon: ICONS.ecommerce,
          },
          {
            title: t('analytics'),
            path: paths.admin.general.analytics,
            icon: ICONS.analytics,
          },
          {
            title: t('banking'),
            path: paths.admin.general.banking,
            icon: ICONS.banking,
          },
          {
            title: t('booking'),
            path: paths.admin.general.booking,
            icon: ICONS.booking,
          },
          {
            title: t('file'),
            path: paths.admin.general.file,
            icon: ICONS.file,
          },
        ],
      },

      // MANAGEMENT
      // ----------------------------------------------------------------------
      {
        subheader: t('management'),
        items: [
          // USER
          {
            title: t('school'),
            path: paths.admin.school.root,
            icon: ICONS.school,
            children: [
              { title: t('profile'), path: paths.admin.school.root },
              { title: t('cards'), path: paths.admin.school.cards },
              { title: t('list'), path: paths.admin.school.list },
              { title: t('create'), path: paths.admin.school.new },
              { title: t('edit'), path: paths.admin.school.demo.edit },
              { title: t('account'), path: paths.admin.school.account },
            ],
          },

          // PRODUCT
          {
            title: t('product'),
            path: paths.admin.product.root,
            icon: ICONS.product,
            children: [
              { title: t('list'), path: paths.admin.product.root },
              {
                title: t('details'),
                path: paths.admin.product.demo.details,
              },
              { title: t('create'), path: paths.admin.product.new },
              { title: t('edit'), path: paths.admin.product.demo.edit },
            ],
          },

          // ORDER
          {
            title: t('order'),
            path: paths.admin.order.root,
            icon: ICONS.order,
            children: [
              { title: t('list'), path: paths.admin.order.root },
              { title: t('details'), path: paths.admin.order.demo.details },
            ],
          },

          // INVOICE
          {
            title: t('invoice'),
            path: paths.admin.invoice.root,
            icon: ICONS.invoice,
            children: [
              { title: t('list'), path: paths.admin.invoice.root },
              {
                title: t('details'),
                path: paths.admin.invoice.demo.details,
              },
              { title: t('create'), path: paths.admin.invoice.new },
              { title: t('edit'), path: paths.admin.invoice.demo.edit },
            ],
          },

          // BLOG
          {
            title: t('blog'),
            path: paths.admin.post.root,
            icon: ICONS.blog,
            children: [
              { title: t('list'), path: paths.admin.post.root },
              { title: t('details'), path: paths.admin.post.demo.details },
              { title: t('create'), path: paths.admin.post.new },
              { title: t('edit'), path: paths.admin.post.demo.edit },
            ],
          },

          // JOB
          {
            title: t('job'),
            path: paths.admin.job.root,
            icon: ICONS.job,
            children: [
              { title: t('list'), path: paths.admin.job.root },
              { title: t('details'), path: paths.admin.job.demo.details },
              { title: t('create'), path: paths.admin.job.new },
              { title: t('edit'), path: paths.admin.job.demo.edit },
            ],
          },

          // TOUR
          {
            title: t('tour'),
            path: paths.admin.tour.root,
            icon: ICONS.tour,
            children: [
              { title: t('list'), path: paths.admin.tour.root },
              { title: t('details'), path: paths.admin.tour.demo.details },
              { title: t('create'), path: paths.admin.tour.new },
              { title: t('edit'), path: paths.admin.tour.demo.edit },
            ],
          },

          // FILE MANAGER
          {
            title: t('file_manager'),
            path: paths.admin.fileManager,
            icon: ICONS.folder,
          },

          // MAIL
          {
            title: t('mail'),
            path: paths.admin.mail,
            icon: ICONS.mail,
            info: <Label color="error">+32</Label>,
          },

          // CHAT
          {
            title: t('chat'),
            path: paths.admin.chat,
            icon: ICONS.chat,
          },

          // CALENDAR
          {
            title: t('calendar'),
            path: paths.admin.calendar,
            icon: ICONS.calendar,
          },

          // KANBAN
          {
            title: t('kanban'),
            path: paths.admin.kanban,
            icon: ICONS.kanban,
          },
        ],
      },

      // DEMO MENU STATES
      {
        subheader: t(t('other_cases')),
        items: [
          {
            // default roles : All roles can see this entry.
            // roles: ['user'] Only users can see this item.
            // roles: ['admin'] Only admin can see this item.
            // roles: ['admin', 'manager'] Only admin/manager can see this item.
            // Reference from 'src/guards/RoleBasedGuard'.
            title: t('item_by_roles'),
            path: paths.admin.permission,
            icon: ICONS.lock,
            roles: ['admin', 'manager'],
            caption: t('only_admin_can_see_this_item'),
          },
          {
            title: t('menu_level'),
            path: '#/admin/menu_level',
            icon: ICONS.menuItem,
            children: [
              {
                title: t('menu_level_1a'),
                path: '#/admin/menu_level/menu_level_1a',
              },
              {
                title: t('menu_level_1b'),
                path: '#/admin/menu_level/menu_level_1b',
                children: [
                  {
                    title: t('menu_level_2a'),
                    path: '#/admin/menu_level/menu_level_1b/menu_level_2a',
                  },
                  {
                    title: t('menu_level_2b'),
                    path: '#/admin/menu_level/menu_level_1b/menu_level_2b',
                    children: [
                      {
                        title: t('menu_level_3a'),
                        path: '#/admin/menu_level/menu_level_1b/menu_level_2b/menu_level_3a',
                      },
                      {
                        title: t('menu_level_3b'),
                        path: '#/admin/menu_level/menu_level_1b/menu_level_2b/menu_level_3b',
                      },
                    ],
                  },
                ],
              },
            ],
          },
          {
            title: t('item_disabled'),
            path: '#disabled',
            icon: ICONS.disabled,
            disabled: true,
          },
          {
            title: t('item_label'),
            path: '#label',
            icon: ICONS.label,
            info: (
              <Label color="info" startIcon={<Iconify icon="solar:bell-bing-bold-duotone" />}>
                NEW
              </Label>
            ),
          },
          {
            title: t('item_caption'),
            path: '#caption',
            icon: ICONS.menuItem,
            caption:
              'Quisque malesuada placerat nisl. In hac habitasse platea dictumst. Cras id dui. Pellentesque commodo eros a enim. Morbi mollis tellus ac sapien.',
          },
          {
            title: t('item_external_link'),
            path: 'https://www.google.com/',
            icon: ICONS.external,
          },
          {
            title: t('blank'),
            path: paths.admin.blank,
            icon: ICONS.blank,
          },
        ],
      },
    ],
    [t]
  );

  return data;
}
