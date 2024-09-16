import { Controller, useFormContext } from 'react-hook-form';

import FormHelperText from '@mui/material/FormHelperText';
import { CldUploadWidget } from 'next-cloudinary';

import { Upload, UploadBox, UploadAvatar } from '../upload';

// ----------------------------------------------------------------------
const CloudinaryUploadAvatar = ({ value, error, onChange, ...other }) => {
  return (
    <CldUploadWidget
      uploadPreset={process.env.NEXT_PUBLIC_CLOUDINARY_UPLOAD_PRESET}
      onSuccess={(result) => {
        console.log('result', result);
        onChange(result.info.secure_url);
      }}
      onError={(error) => {
        console.log(error);
      }}
    >
      {({ open }) => (
        <div
          onClick={() => open()}
          style={{
            width: '144px',
            height: '144px',
            margin: '0 auto',
            padding: '8px',
            border: `1px dashed ${error ? 'red' : 'rgba(145, 158, 171, 0.32)'}`,
            borderRadius: '50%',
            cursor: 'pointer',
            display: 'flex',
            flexDirection: 'column',
            justifyContent: 'center',
            alignItems: 'center',
          }}
          {...other}
        >
          {console.log(value)}
          {value ? (
            <img
              src={value}
              alt="Uploaded avatar"
              style={{ width: '100%', height: '100%', borderRadius: '50%', objectFit: 'cover' }}
            />
          ) : (
            <span>Upload image</span>
          )}
        </div>
      )}
    </CldUploadWidget>
  );
};

export function RHFUploadAvatar({ name, ...other }) {
  const { control, setValue } = useFormContext();

  return (
    <Controller
      name={name}
      control={control}
      render={({ field, fieldState: { error } }) => {
        const handleUpload = (url) => {
          console.log(url);
          setValue(name, url, { shouldValidate: true });
        };

        return (
          <div>
            <CloudinaryUploadAvatar
              value={field.value}
              error={!!error}
              onChange={handleUpload}
              {...other}
            />

            {!!error && (
              <FormHelperText error sx={{ px: 2, textAlign: 'center' }}>
                {error.message}
              </FormHelperText>
            )}
          </div>
        );
      }}
    />
  );
}
export function RHFUploadAvatar_({ name, ...other }) {
  const { control, setValue } = useFormContext();

  return (
    <Controller
      name={name}
      control={control}
      render={({ field, fieldState: { error } }) => {
        const onDrop = (acceptedFiles) => {
          const value = acceptedFiles[0];

          setValue(name, value, { shouldValidate: true });
        };

        return (
          <div>
            <UploadAvatar value={field.value} error={!!error} onDrop={onDrop} {...other} />

            {!!error && (
              <FormHelperText error sx={{ px: 2, textAlign: 'center' }}>
                {error.message}
              </FormHelperText>
            )}
          </div>
        );
      }}
    />
  );
}

// ----------------------------------------------------------------------

export function RHFUploadBox({ name, ...other }) {
  const { control } = useFormContext();

  return (
    <Controller
      name={name}
      control={control}
      render={({ field, fieldState: { error } }) => (
        <UploadBox value={field.value} error={!!error} {...other} />
      )}
    />
  );
}

// ----------------------------------------------------------------------

export function RHFUpload({ name, multiple, helperText, ...other }) {
  const { control, setValue } = useFormContext();

  return (
    <Controller
      name={name}
      control={control}
      render={({ field, fieldState: { error } }) => {
        const uploadProps = {
          multiple,
          accept: { 'image/*': [] },
          error: !!error,
          helperText: error?.message ?? helperText,
        };

        const onDrop = (acceptedFiles) => {
          const value = multiple ? [...field.value, ...acceptedFiles] : acceptedFiles[0];

          setValue(name, value, { shouldValidate: true });
        };

        return <Upload {...uploadProps} value={field.value} onDrop={onDrop} {...other} />;
      }}
    />
  );
}
