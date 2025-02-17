"use client"
import { AppDispatch, useAppSelector } from "@/lib/features/store";
import React from "react";
import { useDispatch } from "react-redux";
import SignInForm from "./SignInForm";

const useAppDispatch = () => useDispatch<AppDispatch>();
export default function SignIn() {
  const authState = useAppSelector((state) => state.auth);

  return (
      <SignInForm />
  );
}
