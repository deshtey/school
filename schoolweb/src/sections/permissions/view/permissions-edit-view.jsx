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
import { usePostPermissions } from 'src/actions/permissions';

// ----------------------------------------------------------------------

export const NewPermissionschema = zod.object({
  logoUrl: zod.string(),
  permissionsName: zod.string().min(1, { message: 'Name is required!' }),
  email: zod
    .string()
    .min(1, { message: 'Email is required!' })
    .email({ message: 'Email must be a valid email address!' }),
  phone: schemaHelper.phoneNumber({ isValidPhoneNumber }),
  country: schemaHelper.objectOrNull({
    message: { required_error: 'Country is required!' },
  }),
  address: zod.string().min(1, { message: 'Address is required!' }),
  location: zod.string().min(1, { message: 'State is required!' }),
  city: zod.string().min(1, { message: 'City is required!' }),
  homepage: zod.string().min(1, { message: 'Role is required!' }),
  zipCode: zod.string().min(1, { message: 'Zip code is required!' }),
});

// ----------------------------------------------------------------------

export function PermissionsEditView({ permissions: currentPermissions }) {
  const router = useRouter();
  const defaultValues = useMemo(
    () => ({
      permissionsName: currentPermissions?.permissionsName || '',
      status: currentPermissions?.status || '',
      logoUrl: currentPermissions?.logo || '',
      email: currentPermissions?.email || '',
      phone: currentPermissions?.phone || '',
      country: currentPermissions?.country || 'Kenya',
      state: currentPermissions?.state || '',
      city: currentPermissions?.city || '',
      address: currentPermissions?.address || '',
      zipCode: currentPermissions?.zipCode || '',
      homePage: currentPermissions?.homePage || '',
      location: currentPermissions?.location || '',
    }),
    [currentPermissions]
  );

  const methods = useForm({
    mode: 'onSubmit',
    // resolver: zodResolver(NewPermissionschema),
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
    if (currentPermissions) {
      reset(defaultValues);
    }
  }, [currentPermissions, defaultValues, reset]);
  const { createPermissions } = usePostPermissions();

  const onSubmit = handleSubmit(async (data) => {
    try {
      const res = await createPermissions({ ...data });
      console.log(res);
      toast.success(currentPermissions ? 'Update success!' : 'Create success!');
      router.push(paths.admin.permissions.list);
    } catch (error) {
      console.error(error);
      toast.error('An error occured');
    }
  });
  return (
    <DashboardContent>
      <CustomBreadcrumbs
        heading="Create a new permissions"
        links={[
          { name: 'Dashboard', href: paths.admin.root },
          { name: 'Permissions', href: paths.admin.permissions.root },
          { name: 'New Permissions' },
        ]}
        sx={{ mb: { xs: 3, md: 5 } }}
      />

      <Form methods={methods} onSubmit={onSubmit}>
        <Grid container spacing={3}>
          <Grid xs={12} md={4}>
            <Card sx={{ pt: 10, pb: 5, px: 3 }}>
              {currentPermissions && (
                <Label
                  color={
                    (values.status === 'active' && 'success') ||
                    (values.status === 'banned' && 'error') ||
                    'warning'
                  }
                  sx={{ position: 'absolute', top: 24, right: 24 }}
                >
                  {values.status}
                </Label>
              )}
              <Box sx={{ mb: 5 }}>
                <Field.UploadAvatar
                  name="logoUrl"
                  maxSize={3145728}
                  helperText={
                    <Typography
                      variant="caption"
                      sx={{
                        mt: 3,
                        mx: 'auto',
                        display: 'block',
                        textAlign: 'center',
                        color: 'text.disabled',
                      }}
                    >
                      Allowed *.jpeg, *.jpg, *.png, *.gif
                      <br /> max size of {fData(3145728)}
                    </Typography>
                  }
                />
              </Box>

              {/* {currentPermissions && (
                <FormControlLabel
                  labelPlacement="start"
                  control={
                    <Controller
                      name="status"
                      control={control}
                      render={({ field }) => (
                        <Switch
                          {...field}
                          checked={field.value !== 'active'}
                          onChange={(event) =>
                            field.onChange(event.target.checked ? 'banned' : 'active')
                          }
                        />
                      )}
                    />
                  }
                  label={
                    <>
                      <Typography variant="subtitle2" sx={{ mb: 0.5 }}>
                        Banned
                      </Typography>
                      <Typography variant="body2" sx={{ color: 'text.secondary' }}>
                        Apply disable account
                      </Typography>
                    </>
                  }
                  sx={{
                    mx: 0,
                    mb: 3,
                    width: 1,
                    justifyContent: 'space-between',
                  }}
                />
              )} */}

              <Field.Switch
                name="isVerified"
                labelPlacement="start"
                label={
                  <>
                    <Typography variant="subtitle2" sx={{ mb: 0.5 }}>
                      Email verified
                    </Typography>
                    <Typography variant="body2" sx={{ color: 'text.secondary' }}>
                      Disabling this will automatically send the permissions a verification email
                    </Typography>
                  </>
                }
                sx={{ mx: 0, width: 1, justifyContent: 'space-between' }}
              />

              {currentPermissions && (
                <Stack justifyContent="center" alignItems="center" sx={{ mt: 3 }}>
                  <Button variant="soft" color="error">
                    Delete permissions
                  </Button>
                </Stack>
              )}
            </Card>
          </Grid>

          <Grid xs={12} md={8}>
            <Card sx={{ p: 3 }}>
              <Box
                rowGap={3}
                columnGap={2}
                display="grid"
                gridTemplateColumns={{
                  xs: 'repeat(1, 1fr)',
                  sm: 'repeat(2, 1fr)',
                }}
              >
                <Field.Text name="permissionsName" label="Permissions name" />
                <Field.Text name="email" label="Email address" />
                <Field.Phone name="phone" label="Phone number" />

                <Field.CountrySelect
                  fullWidth
                  name="country"
                  label="Country"
                  placeholder="Choose a country"
                />
                <Field.Text name="homePage" label="Permissions Website Url" />

                <Field.Text name="location" label="County/State/region" />
                <Field.Text name="city" label="City/Town" />
                <Field.Text name="address" label="Address" />
                <Field.Text name="zipCode" label="Zip/code" />
              </Box>

              <Stack alignItems="flex-end" sx={{ mt: 3 }}>
                <LoadingButton type="submit" variant="contained" loading={isSubmitting}>
                  {!currentPermissions ? 'Create permissions' : 'Save changes'}
                </LoadingButton>
              </Stack>
            </Card>
          </Grid>
        </Grid>
      </Form>
    </DashboardContent>
  );
}
