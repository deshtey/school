import { useState, useEffect } from "react";
import { useController, Control } from "react-hook-form";
import { Button } from "@/components/ui/button";
import { Popover, PopoverContent, PopoverTrigger } from "@/components/ui/popover";
import { cn } from "@/lib/utils";
import { CalendarIcon, ChevronLeft, ChevronRight } from "lucide-react";
import { format, setYear, setMonth } from "date-fns";
import { Calendar } from "../ui/calendar";

interface FormDatePickerProps {
  name: string;
  control: Control<any>;
  label?: string;
  placeholder?: string;
  defaultValue?: Date;
  yearRange?: number;
  startYear?: number;
}

type ViewState = "year" | "month" | "day";

export const HookFormDatePicker = ({
  name,
  control,
  label,
  placeholder = "Select date",
  defaultValue,
  yearRange = 100,
  startYear,
}: FormDatePickerProps) => {
  const [open, setOpen] = useState(false);
  const [viewState, setViewState] = useState<ViewState>("year");
  
  const {
    field: { onChange, value },
    fieldState: { error }
  } = useController({
    name,
    control,
    defaultValue
  });

  // Working date used during the selection process
  const [workingDate, setWorkingDate] = useState<Date>(
    value || new Date()
  );

  // Reset view state when opening
  useEffect(() => {
    if (open) {
      setViewState("year");
    }
  }, [open]);

  // Calculate year range
  const currentYear = new Date().getFullYear();
  const calculatedStartYear = startYear || (currentYear - yearRange + 1);
  const yearOptions = Array.from(
    { length: currentYear - 1900 + 1 }, // Total number of years
    (_, i) => 1900 + i // Start from 1900 and increment
  );

  // Handle year selection
  const handleYearSelect = (year: number) => {
    const newDate = setYear(workingDate, year);
    setWorkingDate(newDate);
    setViewState("month");
  };

  // Handle month selection
  const handleMonthSelect = (month: number) => {
    const newDate = setMonth(workingDate, month);
    setWorkingDate(newDate);
    setViewState("day");
  };

  // Handle final date selection
  const handleDateSelect = (date: Date | undefined) => {
    if (date) {
      onChange(date);
      setOpen(false);
    }
  };

  // Month names for selection
  const monthNames = [
    "January", "February", "March", "April", "May", "June",
    "July", "August", "September", "October", "November", "December"
  ];

  // Render content based on current view state
  const renderContent = () => {
    switch (viewState) {
      case "year":
        return (
          <div className="p-3">
            <div className="flex justify-between items-center mb-3">
              <h3 className="text-sm font-medium">Select Year</h3>
              <div className="flex gap-1">
                <Button
                  variant="outline"
                  size="icon"
                  className="h-7 w-7 p-0"
                  onClick={() => {
                    const newStartYear = calculatedStartYear - yearRange;
                    yearOptions.unshift(...Array.from(
                      { length: yearRange }, 
                      (_, i) => newStartYear + i
                    ));
                  }}
                >
                  <ChevronLeft className="h-4 w-4" />
                </Button>
                <Button
                  variant="outline"
                  size="icon"
                  className="h-7 w-7 p-0"
                  onClick={() => {
                    const newStartYear = calculatedStartYear + yearRange;
                    yearOptions.push(...Array.from(
                      { length: yearRange }, 
                      (_, i) => newStartYear + i
                    ));
                  }}
                >
                  <ChevronRight className="h-4 w-4" />
                </Button>
              </div>
            </div>
            <div className="grid grid-cols-4 gap-2 max-h-[220px] overflow-y-auto">
              {yearOptions.map((year) => (
                <Button
                  key={year}
                  variant="outline"
                  size="sm"
                  onClick={() => handleYearSelect(year)}
                  className={cn(
                    "h-9",
                    workingDate.getFullYear() === year && "bg-primary text-primary-foreground"
                  )}
                >
                  {year}
                </Button>
              ))}
            </div>
          </div>
        );
      case "month":
        return (
          <div className="p-3">
            <div className="flex justify-between items-center mb-3">
              <h3 className="text-sm font-medium">
                {workingDate.getFullYear()} - Select Month
              </h3>
              <Button
                variant="ghost"
                size="sm"
                onClick={() => setViewState("year")}
              >
                Back
              </Button>
            </div>
            <div className="grid grid-cols-3 gap-2">
              {monthNames.map((month, index) => (
                <Button
                  key={month}
                  variant="outline"
                  size="sm"
                  onClick={() => handleMonthSelect(index)}
                  className={cn(
                    "h-9",
                    workingDate.getMonth() === index && "bg-primary text-primary-foreground"
                  )}
                >
                  {month}
                </Button>
              ))}
            </div>
          </div>
        );
      case "day":
        return (
          <div>
            <div className="flex justify-between items-center px-3 pt-3">
              <h3 className="text-sm font-medium">
                {format(workingDate, "MMMM yyyy")}
              </h3>
              <Button
                variant="ghost"
                size="sm"
                onClick={() => setViewState("month")}
              >
                Back
              </Button>
            </div>
            <Calendar
              mode="single"
              selected={value}
              onSelect={handleDateSelect}
              defaultMonth={workingDate}
              autoFocus
            />
          </div>
        );
    }
  };

  return (
    <div className="space-y-2">
      {label && <label className="text-sm font-medium dark:text-light">{label}</label>}
      
      <Popover open={open} onOpenChange={setOpen}>
        <PopoverTrigger asChild>
          <Button
            variant="outline"
            className={cn(
              "w-full justify-start text-left font-normal",
              !value && "text-muted-foreground"
            )}
          >
            <CalendarIcon className="mr-2 h-4 w-4" />
            {value ? format(value, "PPP") : placeholder}
          </Button>
        </PopoverTrigger>
        <PopoverContent className="w-auto p-0" align="start">
          {renderContent()}
        </PopoverContent>
      </Popover>
      
      {error && <p className="text-sm text-red-500">{error.message}</p>}
    </div>
  );
};