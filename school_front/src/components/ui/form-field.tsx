import React from "react";
import { Control, Controller } from "react-hook-form";

interface FormFieldProps extends React.InputHTMLAttributes<HTMLInputElement> {
  label: string;
  name: string;
  control: Control<any>; 
  error?: string;
}

const FormField = React.forwardRef<HTMLInputElement, FormFieldProps>(
  ({ type ,label, name, control, error, className, disabled, ...props }, ref) => {
    return (
      <Controller
        name={name}
        control={control}
        render={({ field }) => (
          <div className='sm:col-span-6'>
            <label htmlFor={name} className='form-label'>
              {label}
            </label>
            <div className='mt-1'>
              <input
              type={type}
              disabled={disabled}
                id={name}
                {...field} 
                ref={ref}
                className='form-input'
                {...props}
              />
            </div>
            {error && <p className='mt-1 text-sm text-red-500'>{error}</p>}
          </div>
        )}
      />
    );
  }
);

FormField.displayName = "FormField";

export { FormField };
