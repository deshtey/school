'use client';

import { useState, useCallback } from 'react';

import Stack from '@mui/material/Stack';
import Grid from '@mui/material/Unstable_Grid2';

import { paths } from 'src/routes/paths';

import { ORDER_STATUS_OPTIONS } from 'src/_mock';
import { AdminContent } from 'src/layouts/admin';

import { SchoolDetailsInfo } from '../school-details-info';
import { SchoolDetailsItems } from '../school-details-item';
import { SchoolDetailsToolbar } from '../school-details-toolbar';
import { SchoolDetailsHistory } from '../school-details-history';

// ----------------------------------------------------------------------

export function SchoolDetailsView({ school }) {
  const [status, setStatus] = useState(school?.status);

  const handleChangeStatus = useCallback((newValue) => {
    setStatus(newValue);
  }, []);

  return (
    <AdminContent>
      <SchoolDetailsToolbar
        backLink={paths.admin.school.root}
        schoolNumber={school?.schoolNumber}
        createdAt={school?.createdAt}
        status={status}
        onChangeStatus={handleChangeStatus}
        statusOptions={ORDER_STATUS_OPTIONS}
      />

      <Grid container spacing={3}>
        <Grid xs={12} md={8}>
          <Stack spacing={3} direction={{ xs: 'column-reverse', md: 'column' }}>
            <SchoolDetailsItems
              items={school?.items}
              taxes={school?.taxes}
              shipping={school?.shipping}
              discount={school?.discount}
              subtotal={school?.subtotal}
              totalAmount={school?.totalAmount}
            />

            <SchoolDetailsHistory history={school?.history} />
          </Stack>
        </Grid>

        <Grid xs={12} md={4}>
          <SchoolDetailsInfo
            customer={school?.customer}
            delivery={school?.delivery}
            payment={school?.payment}
            shippingAddress={school?.shippingAddress}
          />
        </Grid>
      </Grid>
    </AdminContent>
  );
}
