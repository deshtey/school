"use client";
import { FormField } from "@/components/ui/form-field";
import React from "react";
import { SubmitHandler, useForm } from "react-hook-form";

interface IFormInput {
  password: string;
  oldpassword: string;
  newpassword: string;
}

const Settings: React.FC = () => {
  const { control, register, handleSubmit } = useForm<IFormInput>({
    defaultValues: {
      password: "",
      oldpassword: "",
      newpassword: "",
    },
  });
  const onSubmit: SubmitHandler<IFormInput> = (data) => {
    console.log(data);
  };
  return (
    <div className='overflow-hidden rounded-2xl border border-[#d6b6d7] mx-2 px-8 py-4 flex flex-col gap-4 '>
      <form onSubmit={handleSubmit(onSubmit)} className="max-w-md ">
        <FormField type="password" name='oldpassword' label='Old Password' control={control} ></FormField>

        <FormField type="password" name='newpassword' label='New Password' control={control} ></FormField>

        <button
          type='submit'
          className='rounded-md mt-4 bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600'
        >
          Update Password
        </button>
        </form>
        <div >
          <div className='flex flex-col gap-8 items-start relative w-[855px] bg-transparent'>
            <div className='rounded-lg p-2 flex flex-col gap-4 items-start relative w-[839px] h-[120px] '>
              <small className='tracking-[0.1px] font-medium leading-5 text-sm text-[#1c1c1c] dark:text-light'>
                Two-step verification options
              </small>
              <small className='tracking-[0.014399999999999998em] text-center font-semibold leading-5 underline text-xs text-[#e5352b]'>
                Change Email
              </small>
            </div>
            <div className='flex flex-col gap-1 items-start relative w-[349px] bg-transparent'>
              <div className='flex flex-col gap-1 items-start self-stretch relative w-full bg-transparent'>
                <p className='tracking-[0.2px] font-medium leading-6 text-base text-[#1c1c1c] dark:text-light' >Need help? Contact us</p>
                <small className='tracking-[0.2px] text-center leading-5 text-sm text-[#1c1c1c] dark:text-light'>
                  We’d love to hear your thoughts on this platform
                </small>
                <button className='rounded-lg flex gap-2 justify-center items-center relative bg-transparent'>
                  <span className='tracking-[0.016800000000000002em] text-center font-semibold leading-5 underline text-sm text-[#a892bf]'>
                    CONTACT US
                  </span>
                </button>
              </div>
              <div className='flex flex-col gap-4 items-start relative bg-transparent'>
                <button className='rounded-lg flex gap-2 justify-center items-center relative bg-transparent'>
                  <span className='tracking-[0.016800000000000002em] text-center font-semibold leading-5 underline text-sm text-[#a892bf]'>
                    PRIVACY POLICY
                  </span>
                </button>
                <button className='rounded-lg flex gap-2 justify-center items-center relative bg-transparent'>
                  <span className='tracking-[0.016800000000000002em] text-center font-semibold leading-5 underline text-sm text-[#a892bf]'>
                    TERMS AND CONDITIONS
                  </span>
                </button>
              </div>
            </div>
          </div>
        </div>

    </div>
  );
};
export default Settings;
