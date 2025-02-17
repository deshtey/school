"use client";
import Link from 'next/link';
import { usePathname } from 'next/navigation';

export default function Header() {
  const pathname = usePathname();

  const navItems = [
    { href: '/', label: 'Home' },
    { href: '/memorials', label: 'Memorials' },
    { href: '/plans', label: 'Plans and features' },
    { href: '/contact', label: 'Contact us' }
  ];

  return (
    <header className="px-4 py-6 lg:px-16 md:px-8 sm:px-6">
      <nav className="container mx-auto">
        <div className="flex flex-col md:flex-row justify-between items-center space-y-4 md:space-y-0">
          {/* Logo Section */}
          <div className="text-center">
            <h1 className="text-3xl text-logotext font-semibold dark:text-light">EverCherish</h1>
          </div>

          {/* Navigation Links */}
          <div className="w-full md:w-auto">
            <ul className="flex flex-wrap justify-center md:justify-start gap-4 lg:gap-8">
              {navItems.map(({ href, label }) => (
                <li key={href}>
                  <Link href={href} className="cursor-pointer group">

                  </Link>
                </li>
              ))}
            </ul>
          </div>

          {/* Auth Links */}
          <div className="flex items-center space-x-4  justify-end">
          <Link
                href="/auth/signin"
                className="text-[16px] whitespace-nowrap tracking-[0.50px] mx-2 text-memories font-semibold font-roboto3 text-button-0 cursor-pointer dark:text-light" 
              >
                Log In{" "}
              </Link>
              <Link
                href="/auth/signup"
                className="text-[16px] whitespace-nowrap tracking-[0.50px] mx-2 text-memories font-semibold font-roboto3 text-button-0 cursor-pointer dark:text-light"
              >
                Sign up{" "}
              </Link>
          </div>
        </div>
      </nav>
    </header>
  );
}