// app/page.tsx
import Header from "@/layouts/header";

export default function IndexLayout({ children }: { children: React.ReactNode }) {
  return (
    <div className="w-full flex  flex-col  text-dark shadow-sm">
    <Header />

      {/* Hero Section */}
      <main className="w-[90%] min-h-screen mx-auto flex flex-col ">
        {children}
      </main>

      <footer className="bg-footer text-white py-12 lg:px-16 sm:px-6 md:px-8">
        <div className="text-center">
          <h1 className="text-5xl font-semibold  dark:text-light">EverCherish</h1>
        </div>
        <div className="mt-4 border-t border-white/30"></div>
        <div className="flex flex-col items-center mt-4 space-y-2 md:flex-row md:justify-between md:space-y-0">
          <div className="flex space-x-4">
            <a href="#" className="text-white hover:text-indigo-300">
            <svg xmlns="http://www.w3.org/2000/svg" width="2em" height="2em" viewBox="0 0 24 24"><path fill="currentColor" d="M22 12c0-5.52-4.48-10-10-10S2 6.48 2 12c0 4.84 3.44 8.87 8 9.8V15H8v-3h2V9.5C10 7.57 11.57 6 13.5 6H16v3h-2c-.55 0-1 .45-1 1v2h3v3h-3v6.95c5.05-.5 9-4.76 9-9.95"/></svg>
            </a>
            <a href="#" className="text-white hover:text-indigo-300">
            <svg xmlns="http://www.w3.org/2000/svg" width="2em" height="1.8em" viewBox="0 0 14 14"><g fill="none"><g clipPath="url(#primeTwitter0)"><path fill="currentColor" d="M11.025.656h2.147L8.482 6.03L14 13.344H9.68L6.294 8.909l-3.87 4.435H.275l5.016-5.75L0 .657h4.43L7.486 4.71zm-.755 11.4h1.19L3.78 1.877H2.504z"/></g><defs><clipPath id="primeTwitter0"><path fill="#fff" d="M0 0h14v14H0z"/></clipPath></defs></g></svg>
            </a>
            <a href="#" className="text-white hover:text-indigo-300">
            <svg xmlns="http://www.w3.org/2000/svg" width="2em" height="2em" viewBox="0 0 24 24"><path fill="currentColor" d="M7.8 2h8.4C19.4 2 22 4.6 22 7.8v8.4a5.8 5.8 0 0 1-5.8 5.8H7.8C4.6 22 2 19.4 2 16.2V7.8A5.8 5.8 0 0 1 7.8 2m-.2 2A3.6 3.6 0 0 0 4 7.6v8.8C4 18.39 5.61 20 7.6 20h8.8a3.6 3.6 0 0 0 3.6-3.6V7.6C20 5.61 18.39 4 16.4 4zm9.65 1.5a1.25 1.25 0 0 1 1.25 1.25A1.25 1.25 0 0 1 17.25 8A1.25 1.25 0 0 1 16 6.75a1.25 1.25 0 0 1 1.25-1.25M12 7a5 5 0 0 1 5 5a5 5 0 0 1-5 5a5 5 0 0 1-5-5a5 5 0 0 1 5-5m0 2a3 3 0 0 0-3 3a3 3 0 0 0 3 3a3 3 0 0 0 3-3a3 3 0 0 0-3-3"/></svg>
            </a>
            <a href="#" className="text-white hover:text-indigo-300">
            <svg xmlns="http://www.w3.org/2000/svg" width="2.2em" height="2.2em" viewBox="0 0 24 24"><path fill="currentColor" d="M19 3a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2zm-.5 15.5v-5.3a3.26 3.26 0 0 0-3.26-3.26c-.85 0-1.84.52-2.32 1.3v-1.11h-2.79v8.37h2.79v-4.93c0-.77.62-1.4 1.39-1.4a1.4 1.4 0 0 1 1.4 1.4v4.93zM6.88 8.56a1.68 1.68 0 0 0 1.68-1.68c0-.93-.75-1.69-1.68-1.69a1.69 1.69 0 0 0-1.69 1.69c0 .93.76 1.68 1.69 1.68m1.39 9.94v-8.37H5.5v8.37z"/></svg>
            </a>
          </div>

          <div className="text-sm text-center">
            © {new Date().getFullYear()} <span className="font-semibold">EverCherish</span>
          </div>

          <div className="flex space-x-6">
            <a href="#" className="text-white hover:text-indigo-300">
              Terms of Service
            </a>
            <a href="#" className="text-white hover:text-indigo-300">
              Privacy Policy
            </a>
          </div>
        </div>
      </footer>
    </div>
  );
}
