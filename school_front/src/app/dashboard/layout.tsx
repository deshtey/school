import React from "react";
import UserSidebar from "./Sidebar";

type Props = {
  children: React.ReactNode;
};
const Layout: React.FC<Props> = ({ children }) => {
  return (
    <div className='flex flex-col md:flex-row md:overflow-hidden'>
      <div className='w-full flex-none md:w-64'>
        <UserSidebar />
      </div>
      <div className='h-screen flex-grow p-0 md:overflow-y-auto md:p-x-12 '>
        <header className='mb-2 flex flex-row justify-between align-items-start'>
        </header>
        {children}
      </div>
    </div>
  );
};
export default Layout;
