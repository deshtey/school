'use client';

import { useState, useCallback } from 'react';

import Box from '@mui/material/Box';
import Tab from '@mui/material/Tab';
import Card from '@mui/material/Card';
import Tabs from '@mui/material/Tabs';

import { paths } from 'src/routes/paths';

import { useTabs } from 'src/hooks/use-tabs';

import { DashboardContent } from 'src/layouts/dashboard';

import { Iconify } from 'src/components/iconify';
import { CustomBreadcrumbs } from 'src/components/custom-breadcrumbs';

import { useMockedStudent } from 'src/auth/hooks';

import { ProfileHome } from '../profile-home';
import { ProfileCover } from '../profile-cover';
import { ProfileGallery } from '../profile-gallery';
import { ProfileFollowers } from '../profile-followers';

// ----------------------------------------------------------------------

const TABS = [
  { value: 'profile', label: 'Profile', icon: <Iconify icon="solar:student-id-bold" width={24} /> },
  { value: 'followers', label: 'Followers', icon: <Iconify icon="solar:heart-bold" width={24} /> },
  {
    value: 'friends',
    label: 'Friends',
    icon: <Iconify icon="solar:students-group-rounded-bold" width={24} />,
  },
  {
    value: 'gallery',
    label: 'Gallery',
    icon: <Iconify icon="solar:gallery-wide-bold" width={24} />,
  },
];

// ----------------------------------------------------------------------

export function StudentProfileView() {
  const { student } = useMockedStudent();

  const [searchFriends, setSearchFriends] = useState('');

  const tabs = useTabs('profile');

  const handleSearchFriends = useCallback((event) => {
    setSearchFriends(event.target.value);
  }, []);

  return (
    <DashboardContent>
      <CustomBreadcrumbs
        heading="Profile"
        links={[
          { name: 'Dashboard', href: paths.dashboard.root },
          { name: 'Student', href: paths.dashboard.student.root },
          { name: student?.displayName },
        ]}
        sx={{ mb: { xs: 3, md: 5 } }}
      />

      <Card sx={{ mb: 3, height: 290 }}>
        <ProfileCover
          role={_studentAbout.role}
          name={student?.displayName}
          avatarUrl={student?.photoURL}
          coverUrl={_studentAbout.coverUrl}
        />

        <Box
          display="flex"
          justifyContent={{ xs: 'center', md: 'flex-end' }}
          sx={{
            width: 1,
            bottom: 0,
            zIndex: 9,
            px: { md: 3 },
            position: 'absolute',
            bgcolor: 'background.paper',
          }}
        >
          <Tabs value={tabs.value} onChange={tabs.onChange}>
            {TABS.map((tab) => (
              <Tab key={tab.value} value={tab.value} icon={tab.icon} label={tab.label} />
            ))}
          </Tabs>
        </Box>
      </Card>

      {tabs.value === 'profile' && <ProfileHome info={_studentAbout} posts={_studentFeeds} />}

      {tabs.value === 'followers' && <ProfileFollowers followers={_studentFollowers} />}

      {/* {tabs.value === 'friends' && (
        <ProfileFriends
          friends={_studentFriends}
          searchFriends={searchFriends}
          onSearchFriends={handleSearchFriends}
        />
      )} */}

      {tabs.value === 'gallery' && <ProfileGallery gallery={_studentGallery} />}
    </DashboardContent>
  );
}
