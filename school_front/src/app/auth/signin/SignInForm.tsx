"use client"
import { useState } from 'react';
import { Eye, EyeOff } from 'lucide-react';
import { useAppDispatch, useAppSelector } from '@/lib/features/store';
import { SubmitHandler, useForm } from 'react-hook-form';
import { useRouter } from 'next/navigation';
import { signIn, SignInCredentials } from '@/lib/features/authSlice';
import { paths } from '@/lib/paths';
import Link from 'next/link';
import { useToast } from '@/components/ui/toast-content';
import { Progress } from '@/components/ui/progress';

const SignInForm = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [showPassword, setShowPassword] = useState(false);
  const { addToast } = useToast();
  const dispatch = useAppDispatch();
  const authState:any = useAppSelector((state) => state.auth);
  const { register, handleSubmit } = useForm<SignInCredentials>();
  const router = useRouter();
  const onSubmit: SubmitHandler<SignInCredentials> = async (data) => {
    try {
      const result = await dispatch(signIn(data)).unwrap();
      console.log(result);
      router.replace(paths.dashboard.root);
    } catch (error) {
      console.log("eee", error);
      addToast("Sign in failed", "error", 3000);

    }
  };

  return (
    <div className="min-h-screen flex items-center justify-center p-4">
      <div className="w-full max-w-md space-y-8 animate-fade-in">
        <div className="text-center">
        <img
            src='/images/logo.webp'
            alt='Evercherish logo'
            className='w-24 h-24 mx-auto mb-6 rounded-full'
          />
          <h1 className="text-3xl font-bold mb-2">Sign in to your account</h1>
        </div>

        <form onSubmit={handleSubmit(onSubmit)} className="space-y-6">
          <div>
            <label htmlFor="email" className="form-label">
              Email
            </label>
            <input
              id="email"
              {...register("email", { required: "The email field is required" })}
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              className="form-input"
              placeholder="test@gmail.com"
              disabled={authState.loading}
            />
          </div>

          <div className="relative">
            <label htmlFor="password" className="form-label">
              Password
            </label>
            <div className="relative">
              <input
                {...register("password", { required: "Password is required" })}
                type={showPassword ? 'text' : 'password'}
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                className="form-input pr-12"
                placeholder="@Demo123"
                disabled={authState.loading}
              />
              <button
                type="button"
                onClick={() => setShowPassword(!showPassword)}
                className="absolute right-3 top-1/2 -translate-y-1/2 text-gray-400 
                  hover:text-gray-300 transition-colors"
                disabled={authState.loading}
              >
                {showPassword ? (
                  <EyeOff className="w-5 h-5" />
                ) : (
                  <Eye className="w-5 h-5" />
                )}
              </button>
            </div>
          </div>

          <button
            type="submit"
            className="btn-primary w-full flex items-center justify-center"
            disabled={authState.loading}
          >
            {authState.loading ? (
             <Progress className='w-6 h-6' />
            ) : (
              'Sign in'
            )}
          </button>
        </form>

        <div className="text-center text-sm text-gray-400">
          By creating an account you agree to our{' '}
          <a href="/terms" className="link">Terms of service</a>
          {' & '}
          <a href="/privacy" className="link">Privacy policy</a>
        </div>

        <div className="text-center text-gray-400">
          Already have an account?{' '}
          <Link href='/auth/signup' className='font-semibold text-indigo-600 hover:text-indigo-500'>
              Sign up
            </Link>
        </div>
      </div>
    </div>
  );
};

export default SignInForm;