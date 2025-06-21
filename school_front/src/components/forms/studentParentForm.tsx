import { useState } from 'react';
import { useForm, useFieldArray, Controller } from "react-hook-form";
import { Button } from "@/components/ui/button";
import { Form, FormControl, FormField, FormItem, FormLabel, FormMessage } from "@/components/ui/form";

import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { 
    Dialog,
    DialogContent,
    DialogDescription,
    DialogFooter,
    DialogHeader,
    DialogTitle,
  } from "@/components/ui/dialog";import { Trash2, Plus } from "lucide-react";
import { Input, Textarea } from '../ui';

// Define a proper type for your form values
type StudentFormValues = {
  id: number | null;
  schoolId: number;
  studentDto: {
    status: string;
    imageUrl: string | null;
    regNumber: string | null;
    firstName: string;
    lastName: string;
    otherNames: string;
    email: string;
    phoneNumber: string;
    country: string;
    gender: string | null;
    dob: string | null;
    address: string;
  };
  parentsDto: Array<{
    id: number | null;
    firstName: string;
    lastName: string;
    otherNames: string;
    phone: string;
    email: string;
  }>;
};

// Define field type with proper name typing
type StudentFieldConfig = {
  name: keyof StudentFormValues['studentDto'];
  label: string;
  type: 'text' | 'email' | 'tel' | 'date' | 'select' | 'textarea';
  placeholder: string;
  options?: Array<{ value: string; label: string }>;
  student?: Record<string, any>;
  
};

type StudentParentFormProps = {
  onClose: () => void;
  student?: StudentFormValues | null;
  isEditing?: boolean;
  isOpen?: boolean;
  onSubmit?: (data: StudentFormValues) => void;
  defaultValues?: StudentFormValues;
};

const StudentParentForm : React.FC<StudentParentFormProps> = ({ isOpen, onClose, onSubmit, defaultValues: student, isEditing = false })=> {
  debugger
  const [isSubmitting, setIsSubmitting] = useState(false);

  const defaultValues: StudentFormValues = {
    id: student?.id ?? null,
    schoolId: student?.id ?? 2,
    studentDto: {
      status: student?.studentDto?.status || '',
      imageUrl: student?.studentDto?.imageUrl || null,
      regNumber: student?.studentDto?.regNumber || null,
      firstName: student?.studentDto?.firstName || '',
      lastName: student?.studentDto?.lastName || '',
      otherNames: student?.studentDto?.otherNames || '',
      email: student?.studentDto?.email || '',
      phoneNumber: student?.studentDto?.phoneNumber || '',
      country: student?.studentDto?.country || '',
      gender: student?.studentDto?.gender || null,
      dob: student?.studentDto?.dob || null,
      address: student?.studentDto?.address || '',
    },
    parentsDto: student?.parentsDto?.length ? 
      student.parentsDto : 
      [{
        id: null,
        firstName: '',
        lastName: '',
        otherNames: '',
        phone: '',
        email: '',
      }]
  };

  const form = useForm<StudentFormValues>({
    defaultValues
  });

  const { fields, append, remove } = useFieldArray({
    control: form.control,
    name: "parentsDto"
  });

  const handleSubmit = async (data: StudentFormValues) => {
    setIsSubmitting(true);
    try {
      console.log('Form submitted:', data);
      // Replace with your actual API submission
      await new Promise(resolve => setTimeout(resolve, 1000));
      onClose();
    } catch (error) {
      console.error('Error submitting form:', error);
    } finally {
      setIsSubmitting(false);
    }
  };

  // Properly typed student fields
  const studentFields: Array<StudentFieldConfig> = [
    { name: "firstName", label: "First Name", type: "text", placeholder: "Enter first name" },
    { name: "lastName", label: "Last Name", type: "text", placeholder: "Enter last name" },
    { name: "otherNames", label: "Other Names", type: "text", placeholder: "Enter other names" },
    { name: "email", label: "Email", type: "email", placeholder: "Enter email address" },
    { name: "phoneNumber", label: "Phone Number", type: "tel", placeholder: "Enter phone number" },
    { name: "regNumber", label: "Registration Number", type: "text", placeholder: "Enter registration number" },
    { name: "country", label: "Country", type: "text", placeholder: "Enter country" },
    { name: "gender", label: "Gender", type: "select", placeholder: "Select gender", 
      options: [
        { value: "male", label: "Male" },
        { value: "female", label: "Female" },
        { value: "other", label: "Other" }
      ]
    },
    { name: "dob", label: "Date of Birth", type: "date", placeholder: "Select date of birth" },
    { name: "address", label: "Address", type: "text", placeholder: "Enter address" },
  ];

  return (
        <Dialog open={isOpen} onOpenChange={onClose}>
          <DialogContent className="sm:max-w-xl overflow-y-auto">
            <DialogHeader>
              <DialogTitle>{isEditing ? `Edit student` : `Add New student`}</DialogTitle>
              <DialogDescription>
                {isEditing 
                  ? `Update the student information below.` 
                  : `Fill in the details to create a new student.`}
              </DialogDescription>
            </DialogHeader>
    <Form {...form}>
      <form onSubmit={form.handleSubmit(handleSubmit)} className="space-y-8">
        <Card>
          <CardHeader>
            <CardTitle>Student Information</CardTitle>
          </CardHeader>
          <CardContent>
            <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
              {studentFields.map((field) => (
                <FormField
                  key={field.name}
                  control={form.control}
                  // Use the correct path with proper typing
                  name={`studentDto.${field.name}` as const}
                  render={({ field: formField }) => (
                    <FormItem className={field.type === "textarea" ? "md:col-span-2" : ""}>
                      <FormLabel>{field.label}</FormLabel>
                      <FormControl>
                        {field.type === "select" ? (
                          <Select
                            value={formField.value as string}
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
                    value={formField.value as string}
                    onChange={formField.onChange}
                    //   {...formField }
                      placeholder={field.placeholder}
                      rows={1}
                    />
                  ) : (
                    <Input
                    value={formField.value as string}
                    onChange={formField.onChange}
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
          </CardContent>
        </Card>

        <div className="flex items-center justify-between">
          <CardTitle>Parents/Guardians</CardTitle>
          <Button
            type="button"
            variant="outline"
            size="sm"
            onClick={() => append({
              id: null,
              firstName: '',
              lastName: '',
              otherNames: '',
              phone: '',
              email: '',
            })}
            className="flex items-center gap-1"
          >
            <Plus size={16} /> Add Parent
          </Button>
        </div>

        {fields.map((parent, index) => (
          <Card key={parent.id} >
            <CardHeader className="flex flex-row items-center justify-between pb-2">
              <CardTitle className="text-lg">Parent {index + 1}</CardTitle>
              {fields.length > 1 && (
                <Button
                  type="button"
                  variant="ghost"
                  size="sm"
                  onClick={() => remove(index)}
                  className="h-8 w-8 p-0 text-red-500"
                >
                  <Trash2 size={16} />
                </Button>
              )}
            </CardHeader>
            <CardContent>
              <div className="grid grid-cols-1 md:grid-cols-3 gap-2">
                <FormField
                  control={form.control}
                  name={`parentsDto.${index}.firstName`}
                  render={({ field }) => (
                    <FormItem>
                      <FormLabel>First Name</FormLabel>
                      <FormControl>
                        <Input {...field} placeholder="Enter first name" />
                      </FormControl>
                      <FormMessage />
                    </FormItem>
                  )}
                />
                <FormField
                  control={form.control}
                  name={`parentsDto.${index}.lastName`}
                  render={({ field }) => (
                    <FormItem>
                      <FormLabel>Last Name</FormLabel>
                      <FormControl>
                        <Input {...field} placeholder="Enter last name" />
                      </FormControl>
                      <FormMessage />
                    </FormItem>
                  )}
                />
                <FormField
                  control={form.control}
                  name={`parentsDto.${index}.otherNames`}
                  render={({ field }) => (
                    <FormItem>
                      <FormLabel>Other Names</FormLabel>
                      <FormControl>
                        <Input {...field} placeholder="Enter other names" />
                      </FormControl>
                      <FormMessage />
                    </FormItem>
                  )}
                />
                <FormField
                  control={form.control}
                  name={`parentsDto.${index}.phone`}
                  render={({ field }) => (
                    <FormItem>
                      <FormLabel>Phone</FormLabel>
                      <FormControl>
                        <Input {...field} type="tel" placeholder="Enter phone number" />
                      </FormControl>
                      <FormMessage />
                    </FormItem>
                  )}
                />
                <FormField
                  control={form.control}
                  name={`parentsDto.${index}.email`}
                  render={({ field }) => (
                    <FormItem>
                      <FormLabel>Email</FormLabel>
                      <FormControl>
                        <Input {...field} type="email" placeholder="Enter email address" />
                      </FormControl>
                      <FormMessage />
                    </FormItem>
                  )}
                />
              </div>
            </CardContent>
          </Card>
        ))}

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
}

export default StudentParentForm;