import React from 'react';
import { Controller, Control } from 'react-hook-form';

type FormSwitchProps<T> = {
  name: string;
  control: Control<any>;
  label?: string;
};

export const FormSwitch = <T,>({
  name,
  control,
  label,
}: FormSwitchProps<T>) => {
  return (
    <Controller
      name={name}
      control={control}
      render={({ field, fieldState }) => (
        <div className="flex items-center space-x-4">
          {label && <label htmlFor={name} className="text-gray-700 dark:text-light">{label}</label>}
          <button
            id={name}
            type="button"
            className={`${
              field.value
                ? 'bg-blue-600'
                : 'bg-gray-300'
            } relative inline-flex h-6 w-11 items-center rounded-full transition-colors focus:outline-none`}
            onClick={() => field.onChange(!field.value)}
          >
            <span
              className={`${
                field.value ? 'translate-x-6' : 'translate-x-1'
              } inline-block h-4 w-4 transform rounded-full bg-white transition-transform`}
            />
          </button>
          {fieldState.error && (
            <span className="text-sm text-red-500">{fieldState.error.message}</span>
          )}
        </div>
      )}
    />
  );
};
