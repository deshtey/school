import React from "react";
import { Controller, Control, Path } from "react-hook-form";
import { DatePicker, DatePickerProps } from "@mui/x-date-pickers/DatePicker";
import dayjs from "dayjs";

interface DatePickerFieldProps {
  name: any;
  control: Control<any>;
  label: string;
  required?: boolean;
  disabled?: boolean;
  minDate?: Date | null;
  maxDate?: Date | null;
  error?: boolean;
  helperText?: string;
}
export function FormDatePicker({
  name,
  control,
  label,
  required = false,
  disabled = false,
  minDate = null,
  maxDate,
  error = false,
  helperText,
}: DatePickerFieldProps) {
  return (
    <Controller
      name={name}
      control={control}
      render={({ field: { onChange, value, ref }, fieldState: { error: fieldError } }) => (
        <DatePicker
          label={helperText}
          value={dayjs(value || null)}
          onChange={(newValue) => onChange(dayjs(newValue).format())}
          disabled={disabled}
          minDate={dayjs(minDate)}
          maxDate={dayjs(maxDate)}
          openTo='year'
          views={["year", "month", "day"]}
          yearsOrder='desc'
          slotProps={{
            textField: {
              required,
              error: !!fieldError || error,
              helperText: fieldError?.message || helperText,
              inputRef: ref,
              sx: {
                "& .MuiInputBase-root": {
                  height: "40px", // Adjust the height as needed
                },
              },
            },
          }}
          className=" text-white font-medium py-2 px-4 rounded-md dark:text-memorial-200 dark:bg-gray-700 "

        />
      )}
    />
  );
}
