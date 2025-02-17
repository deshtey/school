"use client";
import React from "react";

import { SubmitHandler, useForm } from "react-hook-form";
import dayjs from "dayjs";
import MemorialForm from "@/components/dashboard/memorialform";
interface IFormInput {
  title: string;
  dob: Date | null;
  dod: Date | null;
  description: string;
  privacy: boolean;
  email: string;
  slug: string;
}
const Manage: React.FC = () => {
  const { control, register, handleSubmit } = useForm<IFormInput>({
    defaultValues: {
      title: "",
      dob: null,
      dod: null,
      description: "",
      privacy: true,
      email: "",
      slug: "",
    },
  });

  const onSubmit: SubmitHandler<IFormInput> = (data) => {
    console.log(data);
  };
  const currentYear = dayjs();
  return (
      <MemorialForm />
  );
};
export default Manage;
