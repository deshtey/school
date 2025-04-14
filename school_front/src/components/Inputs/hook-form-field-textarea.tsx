import { useController, Control } from "react-hook-form";
import { Input, Label, Textarea } from "../ui";

interface FormInputProps {
  name: string;
  control: Control<any>;
  label?: string;
  placeholder?: string;
  type?: React.HTMLInputTypeAttribute;
  defaultValue?: string;
  required?: boolean;
  helperText?: string;
  className?: string;
  disabled?: boolean;
}

export const HookFormTextArea = ({
  name,
  control,
  label,
  placeholder,
  type = "text",
  defaultValue = "",
  required = false,
  helperText,
  className= 'dark:text-memorial-200 dark:bg-gray-700 ',
  disabled=false,
}: FormInputProps) => {
  const {
    field,
    fieldState: { error }
  } = useController({
    name,
    control,
    defaultValue,
    rules: { required: required ? "This field is required" : false }
  });
  return (
    <div className="space-y-2">
      {label && (
        <Label htmlFor={name} className="text-sm font-medium dark:text-light">
          {label}
          {required && <span className="text-red-500 ml-1">*</span>}
        </Label>
      )}
      
      <Textarea
        id={name}
        placeholder={placeholder}
        {...field}
        className={className}
        aria-invalid={!!error}
        aria-describedby={`${name}-error`}
        disabled={disabled}
      />
      
      {helperText && !error && (
        <p className="text-xs text-muted-foreground">{helperText}</p>
      )}
      
      {error && (
        <p 
          className="text-sm text-red-500" 
          id={`${name}-error`}
        >
          {error.message}
        </p>
      )}
    </div>
  );
};