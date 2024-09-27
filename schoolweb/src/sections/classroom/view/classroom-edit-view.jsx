'use client';

import { paths } from 'src/routes/paths';

import { DashboardContent } from 'src/layouts/dashboard';

import { CustomBreadcrumbs } from 'src/components/custom-breadcrumbs';

import { z as zod } from 'zod';
import { useEffect, useMemo } from 'react';
import { useForm } from 'react-hook-form';
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
import { usePostClassrooms } from 'src/actions/classroom';
import { useSelector } from 'react-redux';
import { zodResolver } from '@hookform/resolvers/zod';
import { createClassroom } from 'src/actions/classroom';
import { useGetGrades } from 'src/actions/grade';
import { transformArray } from 'src/utils/transformarrays';
import { MenuItem } from '@mui/material';

export const NewClassroomSchema = zod.object({
  classroomName: zod.string().min(1, { message: 'Name is required!' }),
  schoolId: zod.number(),
  year: zod.number(),
  gradeId: zod.number().min(1, { message: 'Grade is required!' }),
});

// ----------------------------------------------------------------------

export function ClassroomEditView({ classroom: currentClassroom }) {
  const school = useSelector((state) => state.school);
  const { grades, gradesEmpty, gradesError, gradesLoading } = useGetGrades(school.id);

  const router = useRouter();
  const defaultValues = useMemo(
    () => ({
      classroomName: currentClassroom?.classroomName || '',
      year: currentClassroom?.year || new Date().getFullYear(),
      schoolId: currentClassroom?.schoolId || school.id,
      teacherId: currentClassroom?.teacherId || null,
      gradeId: currentClassroom?.gradeId || 0,
    }),
    [currentClassroom]
  );

  const methods = useForm({
    mode: 'onSubmit',
    resolver: zodResolver(NewClassroomSchema),
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
    if (currentClassroom) {
      reset(defaultValues);
    }
  }, [currentClassroom, defaultValues, reset]);
  const onSubmit = handleSubmit(async (data) => {
    try {
      console.log(data);
      await createClassroom({ ...data });
      toast.success(currentClassroom ? 'Update success!' : 'Create success!');
      router.push(paths.admin.classroom.root);
    } catch (error) {
      console.error(error);
      toast.error('An error occured');
    }
  });
  return (
    <DashboardContent>
      <CustomBreadcrumbs
        heading="Create a new classroom"
        links={[
          { name: 'Dashboard', href: paths.admin.root },
          { name: 'Classroom', href: paths.admin.classroom.root },
          { name: 'New Classroom' },
        ]}
        sx={{ mb: { xs: 3, md: 5 } }}
      />

      <Form methods={methods} onSubmit={onSubmit}>
        <Grid container spacing={3}>
          <Grid xs={12} md={12}>
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
                <Field.Text name="classroomName" label="Classroom name" />
                <Field.Text name="year" label="Year" />
                <Field.Select name="gradeId" label="Grade">
                  <MenuItem value={0}>
                    <em>Select</em>
                  </MenuItem>
                  {grades.map((grade) => (
                    <MenuItem key={grade.id} value={grade.id}>
                      {grade.name}
                    </MenuItem>
                  ))}
                </Field.Select>
              </Box>

              <Stack alignItems="flex-end" sx={{ mt: 3 }}>
                <LoadingButton type="submit" variant="contained" loading={isSubmitting}>
                  {!currentClassroom ? 'Create classrooms' : 'Save changes'}
                </LoadingButton>
              </Stack>
            </Card>
          </Grid>
        </Grid>
      </Form>
    </DashboardContent>
  );
}
