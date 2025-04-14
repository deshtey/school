"use client";
import React, { useState } from "react";

import { Button } from "@/components/ui/button";

import { Edit, Trash2 } from "lucide-react";
import { Column, DataTable } from "@/components/data-table/datatable";
import { TeacherFormDemo } from "@/components/teachers/teachercreate";
import Layout from "../layout";
import { LoadingIndicator } from "@/components/ui/loading-indicator";

interface Teacher {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  grade: string;
  parentName: string;
  status: "active" | "inactive";
}

const MOCK_TEACHERS: Teacher[] = [
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

const TeachersTable = () => {
  const [teachers, setTeachers] = useState<Teacher[]>(MOCK_TEACHERS);
  const [isLoading, setIsLoading] = useState(false);

  // Simulating a loading state
  const simulateLoading = () => {
    setIsLoading(true);
    setTimeout(() => setIsLoading(false), 2000);
  };

  const handleDelete = (id: number) => {
    // In a real app, you would call an API
    setTeachers(teachers.filter(teacher => teacher.id !== id));
  };

  const columns: Column<Teacher>[] = [
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
        <span className={`px-2 py-1 rounded-full text-xs font-medium ${
          row.status === 'active' 
            ? 'bg-green-100 text-green-800' 
            : 'bg-red-100 text-red-800'
        }`}>
          {row.status.charAt(0).toUpperCase() + row.status.slice(1)}
        </span>
      ),
      sortable: true,
    },
    {
      header: "Actions",
      accessorKey: "id",
      cell: (row) => (
        <div className="flex space-x-2">
          <TeacherFormDemo teacher={row} isEditing={true} />
          <Button 
            variant="ghost" 
            size="icon"
            onClick={(e) => {
              e.stopPropagation();
              handleDelete(row.id);
            }}
          >
            <Trash2 className="h-4 w-4 text-red-500" />
          </Button>
        </div>
      ),
    },
  ];

  return (
 
      <div>
        <div className="mb-6 flex items-center justify-between">
          <h1 className="text-2xl font-bold text-gray-900">Teachers</h1>
          <div className="flex items-center gap-4">
            <Button onClick={simulateLoading} variant="outline">
              Simulate Loading
            </Button>
            <TeacherFormDemo />
          </div>
        </div>

        {isLoading ? (
          <LoadingIndicator text="Loading teachers..." />
        ) : (
          <DataTable 
            data={teachers} 
            columns={columns}
            detailsPath="/teacher"
            idField="id"
          />
        )}
      </div>
 
  );
};

export default TeachersTable;