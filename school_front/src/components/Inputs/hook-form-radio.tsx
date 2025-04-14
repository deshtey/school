import { useController, Control } from "react-hook-form";
import { RadioGroup, RadioGroupItem } from "../ui";

interface Option {
  value: string;
  label: string;
}

interface FormRadioGroupProps {
  name: string;
  control: Control<any>;
  options: Option[];
  defaultValue?: string;
  label?: string;
  required?: boolean;
  horizontal:boolean;
}

export const FormRadioGroup = ({
  name,
  control,
  options,
  defaultValue = "",
  label,
  horizontal = false,
  required = false
}: FormRadioGroupProps) => {
  const {
    field: { onChange, value },
    fieldState: { error }
  } = useController({
    name,
    control,
    defaultValue,
    rules: { required: required ? "This field is required" : false }
  });

  return (
    <div className="space-y-3">
      {label && (
        <label className="text-sm font-medium dark:text-light">
          {label}{required && <span className="text-red-500 ml-1 ">*</span>}
        </label>
      )}
      
      <RadioGroup 
        value={value} 
        onValueChange={onChange}
        className={`flex flex-col space-y-1.5 ${horizontal ? "flex-row" : ""}`}
      >
        {options.map((option) => (
          <div key={option.value} className="flex items-center space-x-2">
            <RadioGroupItem value={option.value} id={`${name}-${option.value}`} />
            <label 
              htmlFor={`${name}-${option.value}`}
              className="text-sm font-normal cursor-pointer dark:text-light"
            >
              {option.label}
            </label>
          </div>
        ))}
      </RadioGroup>
      
      {error && <p className="text-sm text-red-500">{error.message}</p>}
    </div>
  );
};