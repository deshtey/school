'use client';
import { z as zod } from 'zod';
import { useMemo } from 'react';
import { zodResolver } from '@hookform/resolvers/zod';
import { useForm, Controller, useFieldArray } from 'react-hook-form';

import Box from '@mui/material/Box';
import Card from '@mui/material/Card';
import Stack from '@mui/material/Stack';
import Button from '@mui/material/Button';
import Switch from '@mui/material/Switch';
import Grid from '@mui/material/Unstable_Grid2';
import Typography from '@mui/material/Typography';
import LoadingButton from '@mui/lab/LoadingButton';
import FormControlLabel from '@mui/material/FormControlLabel';

import { paths } from 'src/routes/paths';
import { useRouter } from 'src/routes/hooks';

import { fData } from 'src/utils/format-number';

import { Label } from 'src/components/label';
import { toast } from 'src/components/snackbar';
import { Form, Field, schemaHelper } from 'src/components/hook-form';
import { DashboardContent } from 'src/layouts/dashboard';
import { CustomBreadcrumbs } from 'src/components/custom-breadcrumbs';
import { usePostData, usePostStudents } from 'src/actions/student';
import { endpoints, fetcherPost } from 'src/utils/axios';

// ----------------------------------------------------------------------

export const NewStudentSchema = zod.object({
  // imageUrl: schemaHelper.file({
  //   message: { required_error: 'Avatar is required!' },
  // }),
  firstName: zod.string().min(1, { message: 'First Name is required!' }),
  lastName: zod.string().min(1, { message: 'Last Name is required!' }),
  regNumber: zod.string().min(1, { message: 'Reg/Adm Number is required!' }),

  // email: zod
  //   .string()
  //   .min(1, { message: 'Email is required!' })
  //   .email({ message: 'Email must be a valid email address!' }),
  // phoneNumber: schemaHelper.phoneNumber({ isValidPhoneNumber }),
  // country: schemaHelper.objectOrNull({
  //   message: { required_error: 'Country is required!' },
  // }),
  // address: zod.string().min(1, { message: 'Address is required!' }),
  // company: zod.string().min(1, { message: 'Company is required!' }),
  // state: zod.string().min(1, { message: 'State is required!' }),
  // city: zod.string().min(1, { message: 'City is required!' }),
  // role: zod.string().min(1, { message: 'Role is required!' }),
  // zipCode: zod.string().min(1, { message: 'Zip code is required!' }),
  // // Not required
  // status: zod.string(),
  // isVerified: zod.boolean(),
});

// ----------------------------------------------------------------------

export function StudentEditView({ student: currentStudent }) {
  const router = useRouter();

  const defaultValues = useMemo(
    () => ({
      id: currentStudent?.id ?? null,
      schoolId: currentStudent?.id ?? 2,
      studentDto: {
        status: currentStudent?.studentDto?.status || '',
        imageUrl: currentStudent?.studentDto?.imageUrl || null,
        regNumber: currentStudent?.studentDto?.regNumber || null,
        firstName: currentStudent?.studentDto?.firstName || '',
        lastName: currentStudent?.studentDto?.lastName || '',
        otherNames: currentStudent?.studentDto?.otherNames || '',
        email: currentStudent?.studentDto?.email || '',
        phoneNumber: currentStudent?.studentDto?.phoneNumber || '',
        country: currentStudent?.studentDto?.country || '',
        gender: currentStudent?.studentDto?.gender || null,
        dob: currentStudent?.studentDto?.dob || null,
        address: currentStudent?.studentDto?.address || '',
      },
      parentsDto: [
        {
          id: currentStudent?.parentDto?.id || null,
          firstName: currentStudent?.parentDto?.firstName || '',
          lastName: currentStudent?.parentDto?.lastName || '',
          otherNames: currentStudent?.parentDto?.otherNames || '',
          phone: currentStudent?.parentDto?.phone || '',
          email: currentStudent?.parentDto?.email || '',
        },
      ],
    }),
    [currentStudent]
  );

  const methods = useForm({
    mode: 'onSubmit',
    defaultValues,
  });

  const {
    reset,
    watch,
    control,
    handleSubmit,
    formState: { isSubmitting },
  } = methods;

  const { fields, append, remove } = useFieldArray({
    control,
    name: 'parentsDto',
  });
  const values = watch();

  const onSubmit = handleSubmit(async (data) => {
    try {
      const url = endpoints.student.list;
      await fetcherPost(url, 'POST', data);
      toast.success(currentStudent ? 'Update success!' : 'Create success!');
      router.push(paths.admin.student.list);
    } catch (error) {
      console.error(error);
      toast.error('An error occured');
    }
  });

  return (
    <DashboardContent>
      <CustomBreadcrumbs
        heading="Edit"
        links={[
          { name: 'Dashboard', href: paths.admin.root },
          { name: 'Student', href: paths.admin.student.root },
          { name: currentStudent?.name },
        ]}
        sx={{ mb: { xs: 3, md: 5 } }}
      />

      <Form methods={methods} onSubmit={onSubmit}>
        <Grid container spacing={3}>
          <Grid xs={12} md={4}>
            <Card sx={{ pt: 10, pb: 5, px: 3 }}>
              {currentStudent && (
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
                  name="imageUrl"
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

              {currentStudent && (
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
              )}

              {/* <Field.Switch
                name="isVerified"
                labelPlacement="start"
                label={
                  <>
                    <Typography variant="subtitle2" sx={{ mb: 0.5 }}>
                      Email verified
                    </Typography>
                    <Typography variant="body2" sx={{ color: 'text.secondary' }}>
                      Disabling this will automatically send the student a verification email
                    </Typography>
                  </>
                }
                sx={{ mx: 0, width: 1, justifyContent: 'space-between' }}
              /> */}

              {currentStudent && (
                <Stack justifyContent="center" alignItems="center" sx={{ mt: 3 }}>
                  <Button variant="soft" color="error">
                    Delete student
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
                <Field.Text name="studentDto.firstName" label="First name" />
                <Field.Text name="studentDto.lastName" label="Last name" />
                <Field.Text name="studentDto.otherNames" label="Other names" />

                <Field.Text name="studentDto.regNumber" label="Reg/Adm Number" />

                <Field.Text name="studentDto.email" label="Email address" />
                <Field.Phone name="studentDto.phoneNumber" label="Phone number" />

                {/* <Field.CountrySelect
                  fullWidth
                  name="country"
                  label="Country"
                  placeholder="Choose a country"
                /> */}

                <Field.Text name="studentDto.city" label="City" />
                <Field.Text name="studentDto.address" label="Address" />
                <Field.Text name="studentDto.zipCode" label="Zip/code" />
                <Field.DatePicker name="studentDto.dob" label="Date of birth" />
              </Box>
              <Box>
                <h2 className="text-xl font-bold">Parents Information</h2>
                {fields.map((field, index) => (
                  <Box
                    key={field.index}
                    rowGap={3}
                    columnGap={2}
                    display="grid"
                    gridTemplateColumns={{
                      xs: 'repeat(1, 1fr)',
                      sm: 'repeat(2, 1fr)',
                    }}
                  >
                    <Field.Text name={`parentsDto.${index}.firstName`} placeholder="First Name" />
                    <Field.Text name={`parentsDto.${index}.lastName`} placeholder="Last Name" />

                    {/* <Select name={`parentsDto.${index}.gender`}>
                        <option value={0}>Male</option>
                        <option value={1}>Female</option>
                      </Select> */}
                    <Field.Text name={`parentsDto.${index}.phone`} placeholder="Phone" />
                    <Field.Text
                      name={`parentsDto.${index}.email`}
                      type="email"
                      placeholder="Email"
                    />
                    {index > 0 && (
                      <Button type="button" onClick={() => remove(index)} variant="destructive">
                        Remove Parent
                      </Button>
                    )}
                  </Box>
                ))}
                <Button
                  type="button"
                  onClick={() =>
                    append({ id: null, firstName: '', lastName: '', phone: '', email: '' })
                  }
                >
                  Add Parent
                </Button>
              </Box>
              <Stack alignItems="flex-end" sx={{ mt: 3 }}>
                <LoadingButton type="submit" variant="contained" loading={isSubmitting}>
                  {!currentStudent ? 'Create student' : 'Save changes'}
                </LoadingButton>
              </Stack>
            </Card>
          </Grid>
        </Grid>
      </Form>
    </DashboardContent>
  );
}
