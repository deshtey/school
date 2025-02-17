"use client";
import { useState } from "react";
import { Eye, EyeOff } from "lucide-react";
import { SubmitHandler, useForm } from "react-hook-form";
import { redirect } from "next/navigation";
import Link from "next/link";
import axiosInstance from "@/lib/axios";
import { FormField } from "@/components/ui/form-field";
import { paths } from "@/lib/paths";
import { useRouter } from "next/navigation";
import { useToast } from "@/components/ui/toast-content";
import { Progress } from "@/components/ui/progress";
interface SignUpCreds {
  email: string;
  password: string;
  confirmpassword: string;
  firstname: string;
  lastname: string;
  phone: string;
}
const SignUpForm = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [showPassword, setShowPassword] = useState(false);
  const { addToast } = useToast();
    const router = useRouter();
  
  const [isLoading, setIsLoading] = useState(false);
  const methods = useForm<SignUpCreds>({
    defaultValues: {
      firstname: "",
      lastname: "",
      email: "",
      password: "",
      confirmpassword: "",
      phone: "",
    },
  });
  const { control, register, handleSubmit } = methods;

  const onSubmit: SubmitHandler<SignUpCreds> = async (data) => {
    setIsLoading(true);
    try {
      const res = await axiosInstance.post("/auth/register", data);
      setIsLoading(false);
      if (res.status === 200) {
              router.replace(paths.auth.signIn);
        //redirect("/auth/signin");
      } else {
        console.log(res.data);
        addToast("Sign up failed", "error", 3000);
      }
    } catch (error) {
      setIsLoading(false);
      console.log(error);
      addToast("Sign up failed", "error", 3000);
    }
  };

  return (
    <div className='min-h-screen flex items-center justify-center p-4'>
      <div className='w-full max-w-md space-y-8 animate-fade-in'>
        <div className='text-center'>
          <img src='/images/logo.webp' alt='Evercherish logo' className='w-24 h-24 mx-auto mb-6 rounded-full' />
          <h1 className='text-3xl font-bold mb-2'>Create a free account</h1>
        </div>

        <form onSubmit={handleSubmit(onSubmit)} className='space-y-6'>
          <div>
            <FormField
              type='email'
              name='email'
              label='Email'
              placeholder='Enter your email'
              control={control}
              disabled={isLoading}
            />
          </div>
          <div className='grid md:grid-cols-2 md:gap-6'>
            <div className='grid md:grid-cols-1 md:gap-6'>
              <FormField
                type='text'
                name='firstname'
                label='First Name'
                placeholder='Enter your first name'
                control={control}
                disabled={isLoading}
              />
            </div>
            <div className='grid md:grid-cols-1 md:gap-6'>
              <FormField
                type='text'
                name='lastname'
                label='Last Name'
                placeholder='Enter your last name'
                control={control}
                disabled={isLoading}
              />
            </div>
          </div>
          <div className='relative'>
            <label htmlFor='password' className='form-label'>
              Password
            </label>
            <div className='relative'>
              <input
                {...register("password", { required: "Password is required" })}
                type={showPassword ? "text" : "password"}
                className='form-input pr-12'
                placeholder='Enter your password'
                autoComplete='new password'
                disabled={isLoading}
              />
              <button
                type='button'
                onClick={() => setShowPassword(!showPassword)}
                className='absolute right-3 top-1/2 -translate-y-1/2 text-gray-400 
                  hover:text-gray-300 transition-colors'
                disabled={isLoading}
              >
                {showPassword ? <EyeOff className='w-5 h-5' /> : <Eye className='w-5 h-5' />}
              </button>
            </div>
          </div>

          <div className='relative'>
            <label htmlFor='confirmpassword' className='form-label'>
              Confirm Password
            </label>
            <div className='relative'>
              <input
                {...register("confirmpassword", { required: "Password is required" })}
                type={showPassword ? "text" : "password"}
                className='form-input pr-12'
                placeholder='Confirm password'
                autoComplete='confirm password'
                disabled={isLoading}
              />
              <button
                type='button'
                onClick={() => setShowPassword(!showPassword)}
                className='absolute right-3 top-1/2 -translate-y-1/2 text-gray-400 
                  hover:text-gray-300 transition-colors'
                disabled={isLoading}
              >
                {showPassword ? <EyeOff className='w-5 h-5' /> : <Eye className='w-5 h-5' />}
              </button>
            </div>
          </div>

          <button type='submit' className='btn-primary w-full flex items-center justify-center' disabled={isLoading}>
            {isLoading ? <Progress className='w-6 h-6' /> : "Sign up"}
          </button>
        </form>

        <div className='text-center text-sm text-gray-400'>
          By creating an account you agree to our{" "}
          <a href='/terms' className='link'>
            Terms of service
          </a>
          {" & "}
          <a href='/privacy' className='link'>
            Privacy policy
          </a>
        </div>

        <div className='text-center text-gray-400'>
          Already have an account?{" "}
          <Link href='/auth/signin' className='font-semibold text-indigo-600 hover:text-indigo-500'>
            Sign in
          </Link>
        </div>
      </div>
    </div>
  );
};

export default SignUpForm;
