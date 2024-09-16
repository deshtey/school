'use client';

import { paths } from 'src/routes/paths';

import { DashboardContent } from 'src/layouts/dashboard';

import { CustomBreadcrumbs } from 'src/components/custom-breadcrumbs';

import { z as zod } from 'zod';
import { useEffect, useMemo } from 'react';
import { zodResolver } from '@hookform/resolvers/zod';
import { useForm, Controller } from 'react-hook-form';
import { isValidPhoneNumber } from 'react-phone-number-input/input';

import Box from '@mui/material/Box';
import Card from '@mui/material/Card';
import Stack from '@mui/material/Stack';
import Button from '@mui/material/Button';
import Grid from '@mui/material/Unstable_Grid2';
import Typography from '@mui/material/Typography';
import LoadingButton from '@mui/lab/LoadingButton';

import { useRouter } from 'src/routes/hooks';

import { fData } from 'src/utils/format-number';

import { Label } from 'src/components/label';
import { toast } from 'src/components/snackbar';
import { Form, Field, schemaHelper } from 'src/components/hook-form';
import { usePostRoless } from 'src/actions/roles';
import { createRole } from 'src/actions/roles';
import { CardHeader, Divider } from '@mui/material';
import { name } from 'dayjs/locale/en';

// ----------------------------------------------------------------------

export const NewRolesSchema = zod.object({
  name: zod.string().min(1, { message: 'Name is required!' }),
});

// ----------------------------------------------------------------------

export function RolesEditView({ roles: currentRole }) {
  const router = useRouter();
  const defaultValues = useMemo(
    () => ({
      name: currentRole?.name || '',
      id: currentRole?.id || '',
    }),
    [currentRole]
  );

  const methods = useForm({
    mode: 'onSubmit',
    resolver: zodResolver(NewRolesSchema),
    defaultValues,
  });

  const {
    reset,
    watch,
    setValue,
    handleSubmit,
    formState: { isSubmitting },
  } = methods;

  const values = watch();

  useEffect(() => {
    if (currentRole) {
      reset(defaultValues);
    }
  }, [currentRole, defaultValues, reset]);

  const onSubmit = handleSubmit(async (data) => {
    try {
      const res = await createRole(data.name);
      console.log(res);
      toast.success(currentRole ? 'Update success!' : 'Create success!');
      router.push(paths.admin.roles.list);
    } catch (error) {
      console.error(error);
      toast.error('An error occured');
    }
  });

  return (
    <DashboardContent>
      <CustomBreadcrumbs
        heading="Create a new roles"
        links={[
          { name: 'Dashboard', href: paths.admin.root },
          { name: 'Roles', href: paths.admin.roles.root },
          { name: 'New Roles' },
        ]}
        sx={{ mb: { xs: 3, md: 5 } }}
      />

      <Form methods={methods} onSubmit={onSubmit}>
        <Stack spacing={{ xs: 3, md: 5 }} sx={{ mx: 'auto', maxWidth: { xs: 720, xl: 880 } }}>
          <Card>
            <CardHeader title="Details" sx={{ mb: 3 }} />
            <Divider />
            <Stack spacing={3} sx={{ p: 3 }}>
              <Stack spacing={1.5}>
                <Typography variant="subtitle2">Name</Typography>
                <Field.Text name="name" placeholder="Role Name" />
              </Stack>
            </Stack>
            <Stack alignItems="flex-end" sx={{ mt: 3, mr: 3 }}>
              <LoadingButton type="submit" variant="contained" loading={isSubmitting}>
                {!currentRole ? 'Create role' : 'Save changes'}
              </LoadingButton>
            </Stack>
          </Card>
        </Stack>
      </Form>
    </DashboardContent>
  );
}
