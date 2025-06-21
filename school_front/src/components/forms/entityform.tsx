
import { useState } from "react";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import * as z from "zod";
import { 
  Dialog,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
} from "@/components/ui/dialog";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import { Textarea } from "@/components/ui/textarea";
import { 
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { toast } from "sonner";

// Define types for the form fields
export type FieldConfig = {
  name: string;
  label: string;
  type: "text" | "email" | "tel" | "date" | "select" | "textarea";
  placeholder?: string;
  required?: boolean;
  options?: { value: string; label: string }[];
};

export type EntityFormProps = {
  entityType: string;
  isOpen: boolean;
  onClose: () => void;
  onSubmit: (data: any) => void;
  defaultValues?: Record<string, any>;
  fields: FieldConfig[];
  isEditing?: boolean;
};

export const EntityForm = ({
  entityType,
  isOpen,
  onClose,
  onSubmit,
  defaultValues = {},
  fields,
  isEditing = false,
}: EntityFormProps) => {
  const [isSubmitting, setIsSubmitting] = useState(false);

  // Generate Zod schema dynamically based on fields
  const generateSchema = () => {
    const schema: Record<string, any> = {};
    
    fields.forEach((field) => {
      let fieldSchema = z.string();
      
      if (field.required) {
        fieldSchema = fieldSchema.min(1, `${field.label} is required`);
      } 
    //   else {
    //     fieldSchema = fieldSchema.optional();
    //   }
      
      if (field.type === "email") {
        fieldSchema = z.string().email("Invalid email address");
        if (field.required) fieldSchema = fieldSchema.min(1, `${field.label} is required`);
      }
      
      if (field.type === "tel") {
        fieldSchema = z.string().regex(/^\d{10}$/, "Phone number must be 10 digits");
        if (field.required) fieldSchema = fieldSchema.min(1, `${field.label} is required`);
      }
      
      schema[field.name] = fieldSchema;
    });
    
    return z.object(schema);
  };

  const formSchema = generateSchema();

  const form = useForm({
    resolver: zodResolver(formSchema),
    defaultValues,
  });

  const handleSubmit = async (data: z.infer<typeof formSchema>) => {
    setIsSubmitting(true);
    try {
      await onSubmit(data);
      toast.success(`${entityType} ${isEditing ? "updated" : "created"} successfully`);
      onClose();
    } catch (error) {
      console.error("Form submission error:", error);
      toast.error(`Failed to ${isEditing ? "update" : "create"} ${entityType.toLowerCase()}`);
    } finally {
      setIsSubmitting(false);
    }
  };

  return (
    <Dialog open={isOpen} onOpenChange={onClose}>
      <DialogContent >
        <DialogHeader>
          <DialogTitle>{isEditing ? `Edit ${entityType}` : `Add New ${entityType}`}</DialogTitle>
          <DialogDescription>
            {isEditing 
              ? `Update the ${entityType.toLowerCase()} information below.` 
              : `Fill in the details to create a new ${entityType.toLowerCase()}.`}
          </DialogDescription>
        </DialogHeader>
        
        <Form {...form}>
          <form onSubmit={form.handleSubmit(handleSubmit)} className="space-y-6">
            <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
              {fields.map((field) => (
                <FormField
                  key={field.name}
                  control={form.control}
                  name={field.name}
                  render={({ field: formField }) => (
                    <FormItem className={field.type === "textarea" ? "md:col-span-2" : ""}>
                      <FormLabel>{field.label}</FormLabel>
                      <FormControl>
                        {field.type === "select" ? (
                          <Select
                            value={formField.value}
                            onValueChange={formField.onChange}
                          >
                            <SelectTrigger>
                              <SelectValue placeholder={field.placeholder} />
                            </SelectTrigger>
                            <SelectContent>
                              {field.options?.map((option) => (
                                <SelectItem key={option.value} value={option.value}>
                                  {option.label}
                                </SelectItem>
                              ))}
                            </SelectContent>
                          </Select>
                        ) : field.type === "textarea" ? (
                          <Textarea 
                            {...formField} 
                            placeholder={field.placeholder} 
                            rows={4}
                          />
                        ) : (
                          <Input 
                            {...formField} 
                            type={field.type} 
                            placeholder={field.placeholder} 
                          />
                        )}
                      </FormControl>
                      <FormMessage />
                    </FormItem>
                  )}
                />
              ))}
            </div>
            
            <DialogFooter>
              <Button 
                type="button" 
                variant="outline" 
                onClick={onClose}
                disabled={isSubmitting}
              >
                Cancel
              </Button>
              <Button type="submit" disabled={isSubmitting}>
                {isSubmitting 
                  ? "Processing..." 
                  : isEditing 
                    ? "Update" 
                    : "Create"
                }
              </Button>
            </DialogFooter>
          </form>
        </Form>
      </DialogContent>
    </Dialog>
  );
};
