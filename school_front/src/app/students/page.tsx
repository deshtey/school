"use client";
import React from "react";
import { useForm } from "react-hook-form";
import { StudentFormDemo } from "@/components/students/studentcreate";
import MainLayout from "../mainLayout";
const NewMemorial: React.FC = () => {

  return (
    <MainLayout>
      <StudentFormDemo />
    </MainLayout>
  );
};

export default NewMemorial;
