import React, { useCallback } from 'react';
import { useDropzone } from 'react-dropzone';
import { useController, Control } from 'react-hook-form';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faImage } from '@fortawesome/free-solid-svg-icons';

interface FileUploadProps {
label:string;
  name: string;
  control: Control<any>;
  maxSize?: number; // in bytes
  accept?: Record<string, string[]>;
}

const FileUpload = ({ 
  label,
  name, 
  control, 
  maxSize = 10 * 1024 * 1024, // 10MB default
  accept = {
    'image/png': ['.png'],
    'image/jpeg': ['.jpg', '.jpeg'],
    'image/gif': ['.gif'],
  }
}: FileUploadProps) => {
  const {
    field: { onChange, value },
    fieldState: { error }
  } = useController({
    name,
    control,
  });

  const onDrop = useCallback((acceptedFiles: File[]) => {
    onChange(acceptedFiles[0]);
  }, [onChange]);

  const { getRootProps, getInputProps, isDragActive } = useDropzone({
    onDrop,
    maxSize,
    accept,
    multiple: false
  });

  return (
    <div className="col-span-full">
      <label htmlFor="cover-photo" className="block text-sm/6 font-medium text-gray-900 dark:text-light">
        {label}
      </label>
      <div
        {...getRootProps()}
        className={`mt-2 flex justify-center rounded-lg border border-dashed px-6 py-10
          ${isDragActive ? 'border-indigo-600 bg-indigo-50' : 'border-gray-900/25'}
          ${error ? 'border-red-500' : ''}`}
      >
        <div className="text-center">
          <FontAwesomeIcon icon={faImage} className="mx-auto size-12 text-gray-300" />
          <div className="mt-4 flex text-sm/6 text-gray-600">
            <label
              className="relative cursor-pointer rounded-md bg-white font-semibold text-indigo-600 
                focus-within:outline-none focus-within:ring-2 focus-within:ring-indigo-600 
                focus-within:ring-offset-2 hover:text-indigo-500"
            >
              <span>Upload a file</span>
            </label>
            <input {...getInputProps()} className="sr-only" />

            <p className="pl-1">or drag and drop</p>
          </div>
          <p className="text-xs/5 text-gray-600">PNG, JPG, GIF up to 10MB</p>
          {value && (
            <p className="mt-2 text-sm text-gray-600">
              Selected: {value.name}
            </p>
          )}
          {error && (
            <p className="mt-2 text-sm text-red-500">
              {error.message}
            </p>
          )}
        </div>
      </div>
    </div>
  );
};

export default FileUpload;