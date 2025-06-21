
import { useState } from "react";
import { Button } from "@/components/ui/button";
import { UserPlus, Edit } from "lucide-react";
import { EntityForm, FieldConfig } from "../forms/entityform";
import StudentParentForm from "../forms/studentParentForm";
import { studentFields } from "@/lib/interfaces/student";



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

export const StudentFormDemo = ({ student, isEditing = false,  }: StudentFormProps) => {

  const [isOpen, setIsOpen] = useState(isEditing || false);

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

      {/* <EntityForm
        entityType="Student"
        isOpen={isOpen}
        onClose={() => setIsOpen(false)}
        onSubmit={handleSubmit}
        defaultValues={student || emptyStudentValues}
        fields={studentFields}
        isEditing={isEditing}
      /> */}
      <StudentParentForm
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
