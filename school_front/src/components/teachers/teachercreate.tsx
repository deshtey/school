
import { useState } from "react";
import { Button } from "@/components/ui/button";
import { EntityForm, FieldConfig } from "../forms/entityform";
import { UserPlus, Edit } from "lucide-react";

// Example teacher form fields
const teacherFields: FieldConfig[] = [
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
    placeholder: "teacher@example.com",
    required: true,
  },
  {
    name: "phone",
    label: "Phone Number",
    type: "tel",
    placeholder: "1234567890",
    required: true,
  },
  {
    name: "dateOfBirth",
    label: "Date of Birth",
    type: "date",
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
    name: "subject",
    label: "Main Subject",
    type: "select",
    options: [
      { value: "math", label: "Mathematics" },
      { value: "science", label: "Science" },
      { value: "english", label: "English" },
      { value: "history", label: "History" },
      { value: "geography", label: "Geography" },
      { value: "art", label: "Art" },
      { value: "music", label: "Music" },
      { value: "physical_education", label: "Physical Education" },
      { value: "computer_science", label: "Computer Science" },
      { value: "other", label: "Other" },
    ],
    required: true,
  },
  {
    name: "employmentDate",
    label: "Employment Date",
    type: "date",
    required: true,
  },
  {
    name: "qualification",
    label: "Qualifications",
    type: "textarea",
    placeholder: "Enter educational qualifications and certifications",
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

// Example teacher default values
const emptyTeacherValues = {
  firstName: "",
  lastName: "",
  email: "",
  phone: "",
  dateOfBirth: "",
  gender: "",
  subject: "",
  employmentDate: "",
  qualification: "",
  address: "",
};

interface TeacherFormProps {
  teacher?: Record<string, any>;
  isEditing?: boolean;
}

export const TeacherFormDemo = ({ teacher, isEditing = false }: TeacherFormProps) => {
  const [isOpen, setIsOpen] = useState(false);

  const handleSubmit = (data: any) => {
    // Here you would typically save the data to your backend
    console.log("Teacher data submitted:", data);
    
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
            Edit Teacher
          </>
        ) : (
          <>
            <UserPlus className="h-4 w-4" />
            Add Teacher
          </>
        )}
      </Button>

      <EntityForm
        entityType="Teacher"
        isOpen={isOpen}
        onClose={() => setIsOpen(false)}
        onSubmit={handleSubmit}
        defaultValues={teacher || emptyTeacherValues}
        fields={teacherFields}
        isEditing={isEditing}
      />
    </>
  );
};
