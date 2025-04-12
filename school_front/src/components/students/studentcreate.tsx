
import { useState } from "react";
import { Button } from "@/components/ui/button";
import { UserPlus, Edit } from "lucide-react";
import { EntityForm, FieldConfig } from "../forms/entityform";

// Example student form fields
const studentFields: FieldConfig[] = [
  {
    name: "firstName",
    label: "First Name",
    type: "text",
    placeholder: "Enter first name",
    required: true,
  },
  {
    name: "lastName",
    label: "Last Name",
    type: "text",
    placeholder: "Enter last name",
    required: true,
  },
  {
    name: "email",
    label: "Email",
    type: "email",
    placeholder: "student@example.com",
    required: true,
  },
  {
    name: "phone",
    label: "Phone Number",
    type: "tel",
    placeholder: "1234567890",
  },
  {
    name: "dateOfBirth",
    label: "Date of Birth",
    type: "date",
    required: true,
  },
  {
    name: "gender",
    label: "Gender",
    type: "select",
    options: [
      { value: "male", label: "Male" },
      { value: "female", label: "Female" },
      { value: "other", label: "Other" },
    ],
    required: true,
  },
  {
    name: "grade",
    label: "Grade/Class",
    type: "select",
    options: [
      { value: "1", label: "Grade 1" },
      { value: "2", label: "Grade 2" },
      { value: "3", label: "Grade 3" },
      { value: "4", label: "Grade 4" },
      { value: "5", label: "Grade 5" },
      { value: "6", label: "Grade 6" },
      { value: "7", label: "Grade 7" },
      { value: "8", label: "Grade 8" },
      { value: "9", label: "Grade 9" },
      { value: "10", label: "Grade 10" },
      { value: "11", label: "Grade 11" },
      { value: "12", label: "Grade 12" },
    ],
    required: true,
  },
  {
    name: "parentName",
    label: "Parent/Guardian Name",
    type: "text",
    placeholder: "Enter parent name",
    required: true,
  },
  {
    name: "parentContact",
    label: "Parent/Guardian Contact",
    type: "tel",
    placeholder: "1234567890",
    required: true,
  },
  {
    name: "address",
    label: "Address",
    type: "textarea",
    placeholder: "Enter full address",
    required: true,
  },
];

// Example student default values
const emptyStudentValues = {
  firstName: "",
  lastName: "",
  email: "",
  phone: "",
  dateOfBirth: "",
  gender: "",
  grade: "",
  parentName: "",
  parentContact: "",
  address: "",
};

interface StudentFormProps {
  student?: Record<string, any>;
  isEditing?: boolean;
}

export const StudentFormDemo = ({ student, isEditing = false }: StudentFormProps) => {
  const [isOpen, setIsOpen] = useState(false);

  const handleSubmit = (data: any) => {
    // Here you would typically save the data to your backend
    console.log("Student data submitted:", data);
    
    // For demo purposes, we're just logging and returning a resolved promise
    return Promise.resolve();
  };

  return (
    <>
      <Button 
        onClick={() => setIsOpen(true)}
        className="flex items-center gap-2"
      >
        {isEditing ? (
          <>
            <Edit className="h-4 w-4" />
            Edit Student
          </>
        ) : (
          <>
            <UserPlus className="h-4 w-4" />
            Add Student
          </>
        )}
      </Button>

      <EntityForm
        entityType="Student"
        isOpen={isOpen}
        onClose={() => setIsOpen(false)}
        onSubmit={handleSubmit}
        defaultValues={student || emptyStudentValues}
        fields={studentFields}
        isEditing={isEditing}
      />
    </>
  );
};
