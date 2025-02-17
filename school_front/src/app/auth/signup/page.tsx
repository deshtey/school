"use client";
import React from "react";
import SignUpForm from "./SignUpForm";
type Inputs = {
  email: string;
  password: string;
  confirmpassword: string;
  firstname: string;
  lastname: string;
  phone: string;
  action: string;
};
export default function SignUp() {

  return (
    <SignUpForm />  
  );
}
