"use client";
import { useToast } from "@/components/Toast/ToastContext";
import axiosInstance from "@/lib/axios";
import Link from "next/link";
import React from "react";
import { useForm } from "react-hook-form";
interface IFormInput {
  firstname: string;
    lastname: string;
    phone: string;
  message: string;
  privacyAgree: boolean;
  email: string;

}
const ContactForm = () => {
  const { addToast } = useToast();

  const { control, register, handleSubmit } = useForm<IFormInput>({
    defaultValues: {
      firstname: "",
      lastname: "",
      phone: "",
      message: "",
      privacyAgree: false,
      email: "",
    },
  });
  const onSubmit = async (data: IFormInput) => {
    var res= await axiosInstance.post("/contactus", data);
    if(res.status === 200 || res.status === 201) {
      addToast("Message sent successfully", "success", 3000);
    }else{
      addToast("Message sent failed", "error", 3000);
    }
    
  };
  return (
    <form onSubmit={handleSubmit(onSubmit)} className='mt-2 space-y-4'>
      <div className='mt-2 grid grid-cols-1 gap-x-6 gap-y-4 sm:grid-cols-6'>
        <div className='sm:col-span-3'>
          <label htmlFor='first-name' className='block text-sm/6 font-medium '>
            First name
          </label>
          <div>
            <input
              type='text'
              {...register("firstname", {required: "The first name is required"})}
              id='first-name'
              autoComplete='given-name'
              className='block w-full rounded-md bg-white px-3 py-1.5 text-base  outline outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6'
            />
          </div>
        </div>

        <div className='sm:col-span-3'>
          <label htmlFor='last-name' className='block text-sm/6 font-medium '>
            Last name
          </label>
          <div>
            <input
              type='text'
              {...register("lastname", {required: "The last name is required"})}
              id='last-name'
              autoComplete='family-name'
              className='block w-full rounded-md bg-white px-3 py-1.5 text-base  outline outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6'
            />
          </div>
        </div>

        <div className='sm:col-span-6'>
          <label htmlFor='email' className='block text-sm/6 font-medium '>
            Email address
          </label>
          <div>
            <input
              id='email'
                {...register("email", {required: "The email is required"})}
              type='email'
              autoComplete='email'
              className='block w-full rounded-md bg-white px-3 py-1.5 text-base  outline outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6'
            />
          </div>
        </div>

        <div className='sm:col-span-6'>
          <label htmlFor='phone' className='block text-sm/6 font-medium '>
            Phone Number
          </label>
          <div className='mt-2 grid grid-cols-1'>
            <select
              id='phone'
              {...register("phone")}
              autoComplete='phone number'
              className='col-start-1 row-start-1 w-full appearance-none rounded-md bg-white py-1.5 pl-3 pr-8 text-base  outline outline-1 -outline-offset-1 outline-gray-300 focus:outline focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6'
            >
              <option>United States</option>
              <option>Canada</option>
              <option>Mexico</option>
            </select>
            <svg
              className='pointer-events-none col-start-1 row-start-1 mr-2 size-5 self-center justify-self-end text-gray-500 sm:size-4'
              viewBox='0 0 16 16'
              fill='currentColor'
              aria-hidden='true'
              data-slot='icon'
            >
              <path
                fillRule='evenodd'
                d='M4.22 6.22a.75.75 0 0 1 1.06 0L8 8.94l2.72-2.72a.75.75 0 1 1 1.06 1.06l-3.25 3.25a.75.75 0 0 1-1.06 0L4.22 7.28a.75.75 0 0 1 0-1.06Z'
                clipRule='evenodd'
              />
            </svg>
          </div>
        </div>

        <div className='col-span-full'>
          <label htmlFor='message' className='block text-sm/6 font-medium '>
            Message
          </label>
          <div>
            <textarea
              {...register("message", {required: "The message is required"})}
              id='message'
              placeholder="Leave us a message"
              rows={3}
              className='block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 dark:text-light outline outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6'
            ></textarea>
          </div>
        </div>

        <div className='col-span-full'>
          <input
            id='privacy-policy'
            {...register("privacyAgree")}
            type='checkbox'
            className='h-4 w-4 text-purple-600 border-gray-300 rounded focus:ring-purple-500'
          />
          <label className='ml-2 text-sm text-gray-600'>
            You agree to our friendly{" "}
            <Link href='#' className='text-purple-600 underline'>
              privacy policy
            </Link>{" "}
            .
          </label>
        </div>
      </div>
      <button
        type='submit'
        className='w-full bg-purple-400 text-white py-2 px-4 rounded-md hover:bg-purple-500 focus:outline-none focus:ring-2 focus:ring-purple-500 focus:ring-offset-2 text-sm'
      >
        Send message
      </button>
    </form>
  );
};

export default ContactForm;
