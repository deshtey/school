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
import Switch from '@mui/material/Switch';
import Grid from '@mui/material/Unstable_Grid2';
import Typography from '@mui/material/Typography';
import LoadingButton from '@mui/lab/LoadingButton';
import FormControlLabel from '@mui/material/FormControlLabel';

import { useRouter } from 'src/routes/hooks';

import { fData } from 'src/utils/format-number';

import { Label } from 'src/components/label';
import { toast } from 'src/components/snackbar';
import { Form, Field, schemaHelper } from 'src/components/hook-form';
import { createGrade, usePostGrade, usePostGrades, usePostGrades1 } from 'src/actions/grade';
import { useSelector } from 'react-redux';

// ----------------------------------------------------------------------

export const NewGradeSchema = zod.object({
  name: zod.string().min(1, { message: 'Name is required!' }),
  desc: zod.string(),
  schoolId: zod.number(),
});

// ----------------------------------------------------------------------

export function GradeEditView({ grade: currentGrade }) {
  const school = useSelector((state) => state.school);

  const router = useRouter();
  const defaultValues = useMemo(
    () => ({
      name: currentGrade?.name || '',
      desc: currentGrade?.desc || '',
      schoolId: currentGrade?.schoolId || school.id,
    }),
    [currentGrade]
  );

  const methods = useForm({
    mode: 'onSubmit',
    resolver: zodResolver(NewGradeSchema),
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
    if (currentGrade) {
      reset(defaultValues);
    }
  }, [currentGrade, defaultValues, reset]);

  const onSubmit = handleSubmit(async (data) => {
    try {
      await createGrade({ ...data });
      toast.success(currentGrade ? 'Update success!' : 'Create success!');
      router.push(paths.admin.grade.list);
    } catch (error) {
      console.error(error);
      toast.error('An error occured');
    }
  });
  return (
    <DashboardContent>
      <CustomBreadcrumbs
        heading="Create a new grade"
        links={[
          { name: 'Dashboard', href: paths.admin.root },
          { name: 'Grade', href: paths.admin.grade.root },
          { name: 'New Grade' },
        ]}
        sx={{ mb: { xs: 3, md: 5 } }}
      />

      <Form methods={methods} onSubmit={onSubmit}>
        <Grid container spacing={3}>
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
                <Field.Text name="name" label="Grade name" />
                <Field.Text name="desc" label="Grade Description" />
              </Box>

              <Stack alignItems="flex-end" sx={{ mt: 3 }}>
                <LoadingButton type="submit" variant="contained" loading={isSubmitting}>
                  {!currentGrade ? 'Create grades' : 'Save changes'}
                </LoadingButton>
              </Stack>
            </Card>
          </Grid>
        </Grid>
      </Form>
    </DashboardContent>
  );
}
