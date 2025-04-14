import { useState, useEffect } from "react";
import { useController, Control } from "react-hook-form";
import { Label } from "@/components/ui/label";
import { cn } from "@/lib/utils";
import { countries, Country } from "@/lib/Countries";
import { PhoneInput } from "../ui/phone-input";

interface FormPhoneInputProps {
  name: string;
  control: Control<any>;
  label?: string;
  required?: boolean;
  defaultCountry?: string; // ISO country code
  helperText?: string;
  className?: string;
}

export const HookPhoneInput = ({
  name,
  control,
  label,
  required = false,
  defaultCountry = "KE",
  helperText,
  className = 'dark:text-memorial-200 dark:bg-gray-700'
}: FormPhoneInputProps) => {
  const [selectedCountry, setSelectedCountry] = useState<Country | undefined>(
    countries.find(c => c.code === defaultCountry)
  );

  const {
    field: { ref, value, onChange, onBlur },
    fieldState: { error }
  } = useController({
    name,
    control,
    defaultValue: "",
    rules: { required: required ? "Phone number is required" : false }
  });

  const handlePhoneChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const phoneNumber = e.target.value;
    onChange({
      countryCode: selectedCountry?.code || "",
      dialCode: selectedCountry?.dialCode || "",
      number: phoneNumber,
      fullNumber: `${selectedCountry?.dialCode || ""}${phoneNumber}`
    });
  };

  const handleCountryChange = (country: Country) => {
    setSelectedCountry(country);
    if (value && typeof value === "object") {
      onChange({
        countryCode: country.code,
        dialCode: country.dialCode,
        number: value.number,
        fullNumber: `${country.dialCode}${value.number}`
      });
    } else {
      onChange({
        countryCode: country.code,
        dialCode: country.dialCode,
        number: "",
        fullNumber: country.dialCode
      });
    }
  };

  useEffect(() => {
    if (!value && selectedCountry) {
      onChange({
        countryCode: selectedCountry.code,
        dialCode: selectedCountry.dialCode,
        number: "",
        fullNumber: selectedCountry.dialCode
      });
    }
  }, []);

  return (
    <div className="space-y-2">
      {label && (
        <Label htmlFor={name} className="text-sm font-medium">
          {label}
          {required && <span className="text-red-500 ml-1">*</span>}
        </Label>
      )}

      <PhoneInput
        ref={ref}
        id={name}
        name={name}
        country={selectedCountry}
        onCountryChange={handleCountryChange}
        onChange={handlePhoneChange}
        onBlur={onBlur}
        value={value?.number || ""}
        className={cn(className)}
        aria-invalid={!!error}
        aria-describedby={error ? `${name}-error` : undefined}
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