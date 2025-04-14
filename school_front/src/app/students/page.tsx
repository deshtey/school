"use client";
import React from "react";
import { useForm } from "react-hook-form";
import { StudentFormDemo } from "@/components/students/studentcreate";
import Layout from "../dashboard/layout";
const NewMemorial: React.FC = () => {

  return (
    <Layout>
      <StudentFormDemo />
    </Layout>
  );
};

export default NewMemorial;
