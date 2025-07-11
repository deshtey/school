"use client";
import React, { useState } from "react";

import { Button } from "@/components/ui/button";

import { Edit, Trash2 } from "lucide-react";
import { Column, DataTable } from "@/components/data-table/datatable";
import { StudentFormDemo } from "@/components/students/studentcreate";
import Layout from "../layout";
import { LoadingIndicator } from "@/components/ui/loading-indicator";
import StudentParentForm from "@/components/forms/studentParentForm";
import { studentFields } from "@/lib/interfaces/student";

interface Student {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  grade: string;
  parentName: string;
  status: "active" | "inactive";
}

const MOCK_STUDENTS: Student[] = [
  {
    id: 1,
    firstName: "John",
    lastName: "Doe",
    email: "john.doe@example.com",
    grade: "Grade 10",
    parentName: "James Doe",
    status: "active",
  },
  {
    id: 2,
    firstName: "Jane",
    lastName: "Smith",
    email: "jane.smith@example.com",
    grade: "Grade 9",
    parentName: "Julia Smith",
    status: "active",
  },
  {
    id: 3,
    firstName: "Michael",
    lastName: "Johnson",
    email: "michael.j@example.com",
    grade: "Grade 11",
    parentName: "Mark Johnson",
    status: "inactive",
  },
  {
    id: 4,
    firstName: "Emma",
    lastName: "Williams",
    email: "emma.w@example.com",
    grade: "Grade 10",
    parentName: "Elizabeth Williams",
    status: "active",
  },
  {
    id: 5,
    firstName: "William",
    lastName: "Brown",
    email: "william.b@example.com",
    grade: "Grade 12",
    parentName: "Walter Brown",
    status: "active",
  },
];

const StudentsTable = () => {
  const [students, setStudents] = useState<Student[]>(MOCK_STUDENTS);
  const [isLoading, setIsLoading] = useState(false);
  const [isEditFormOpen, setIsEditFormOpen] = useState(false);
  const [editingStudent, setEditingStudent] = useState<Student | null>(null);
  // Simulating a loading state
  const simulateLoading = () => {
    setIsLoading(true);
    setTimeout(() => setIsLoading(false), 2000);
  };

  const handleDelete = (id: number) => {
    // In a real app, you would call an API
    setStudents(students.filter((student) => student.id !== id));
  };
  const handleEdit = (student: Student) => {
    setEditingStudent(student);
    setIsEditFormOpen(true);
  };
  const handleSubmit = (data: any) => {
    // Here you would typically save the data to your backend
    console.log("Student data submitted:", data);
    
    // For demo purposes, we're just logging and returning a resolved promise
    return Promise.resolve();
  };
  const columns: Column<Student>[] = [
    {
      header: "ID",
      accessorKey: "id",
      sortable: true,
    },
    {
      header: "First Name",
      accessorKey: "firstName",
      sortable: true,
    },
    {
      header: "Last Name",
      accessorKey: "lastName",
      sortable: true,
    },
    {
      header: "Email",
      accessorKey: "email",
      sortable: true,
    },
    {
      header: "Grade",
      accessorKey: "grade",
      sortable: true,
    },
    {
      header: "Parent",
      accessorKey: "parentName",
      sortable: true,
    },
    {
      header: "Status",
      accessorKey: "status",
      cell: (row) => (
        <span
          className={`px-2 py-1 rounded-full text-xs font-medium ${
            row.status === "active" ? "bg-green-100 text-green-800" : "bg-red-100 text-red-800"
          }`}
        >
          {row.status.charAt(0).toUpperCase() + row.status.slice(1)}
        </span>
      ),
      sortable: true,
    },
    {
      header: "Actions",
      accessorKey: "id",
      cell: (row) => (
        <div className='flex space-x-2'>
          <Button
            onClick={(e) => {
              e.stopPropagation();
              handleEdit(row);
            }}
            className='flex items-center gap-2'
          >
            <Edit className='h-4 w-4' />
            Edit Student
          </Button>
          <Button
            variant='ghost'
            size='icon'
            onClick={(e) => {
              e.stopPropagation();
              handleDelete(row.id);
            }}
          >
            <Trash2 className='h-4 w-4 text-red-500' />
          </Button>
        </div>
      ),
    },
  ];

  return (
    <div>
      <div className='mb-6 flex items-center justify-between'>
        <h1 className='text-2xl font-bold text-gray-900'>Students</h1>
        <div className='flex items-center gap-4'>
          <Button onClick={simulateLoading} variant='outline'>
            Simulate Loading
          </Button>
          <StudentFormDemo />
        </div>
      </div>

      {isEditFormOpen && editingStudent ? (
      <StudentParentForm
      isOpen={isEditFormOpen}

onClose={() => setIsEditFormOpen(false)}
onSubmit={handleSubmit}
defaultValues={editingStudent}
fields={studentFields}
isEditing={true}
/>
      )  :    isLoading ? (
        <LoadingIndicator text='Loading students...' />
      ) : (
        <DataTable data={students} columns={columns} detailsPath='/student' idField='id' />
      )}
    </div>
  );
};

export default StudentsTable;
