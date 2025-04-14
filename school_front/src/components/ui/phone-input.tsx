import * as React from "react";
import { Check, ChevronsUpDown } from "lucide-react";
import { cn } from "@/lib/utils";
import { Button } from "@/components/ui/button";
import {
  Command,
  CommandEmpty,
  CommandGroup,
  CommandInput,
  CommandItem,
} from "@/components/ui/command";
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from "@/components/ui/popover";
import { Input } from "@/components/ui/input";
import { countries, Country } from "@/lib/Countries";
interface PhoneInputProps extends React.InputHTMLAttributes<HTMLInputElement> {
  country: Country | undefined;
  onCountryChange: (country: Country) => void;
}
const PhoneInput = React.forwardRef<HTMLInputElement, PhoneInputProps>(
  ({ country, onCountryChange, className, ...props }, ref) => {
    const [open, setOpen] = React.useState(false);
    return (
      <div className="flex gap-2">
        <Popover open={open} onOpenChange={setOpen}>
          <PopoverTrigger asChild>
            <Button
              variant="outline"
              role="combobox"
              aria-expanded={open}
              className={cn("w-[120px] justify-between", className)}
            >
              {country ? (
                <>
                  <span className="mr-1">{country.flag}</span>
                  {country.dialCode}
                </>
              ) : (
                "Select..."
              )}
              <ChevronsUpDown className="ml-2 h-4 w-4 shrink-0 opacity-50" />
            </Button>
          </PopoverTrigger>
          <PopoverContent className="w-[200px] p-0">
            <Command>
              <CommandInput placeholder="Search country..." />
              <CommandEmpty>No country found.</CommandEmpty>
              <CommandGroup>
                {countries.map((c) => (
                  <CommandItem
                    key={c.code}
                    value={c.name}
                    onSelect={() => {
                      onCountryChange(c);
                      setOpen(false);
                    }}
                  >
                    <Check
                      className={cn(
                        "mr-2 h-4 w-4",
                        country?.code === c.code ? "opacity-100" : "opacity-0"
                      )}
                    />
                    <span className="mr-2">{c.flag}</span>
                    {c.name}
                    <span className="ml-auto text-muted-foreground">
                      {c.dialCode}
                    </span>
                  </CommandItem>
                ))}
              </CommandGroup>
            </Command>
          </PopoverContent>
        </Popover>
        <Input
          ref={ref}
          className={cn("flex-1", className)}
          placeholder="Phone number"
          {...props}
        />
      </div>
    );
  }
);
PhoneInput.displayName = "PhoneInput";
export { PhoneInput, type Country };