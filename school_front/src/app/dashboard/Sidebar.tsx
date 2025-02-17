"use client"
import React, { useState } from "react";
import Link from "next/link";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCog, faCreditCard, faLayerGroup, faList } from "@fortawesome/free-solid-svg-icons";

const UserSidebar: React.FC = () => {
  const [selectedMenu, setSelectedMenu] = useState("overview");

  return (
    <div className='h-screen w-64  p-6 border-r border-gray-200 flex flex-col'>
      <Link href="/">
        <h2 className='text-2xl font-bold text-purple-800 dark:text-light mb-8'>EverCherish</h2>
      </Link>
      <nav className='flex flex-col gap-4'>
        <Link 
          onClick={() => setSelectedMenu('overview')} 
          href='/dashboard' 
          className={`font-semibold transition flex gap-2 items-center ${
            selectedMenu === 'overview' 
              ? 'text-purple-700 bg-purple-50  dark:text-light dark:bg-purple-700 p-2 rounded-lg' 
              : 'text-gray-700 hover:text-purple-700 dark:text-light p-2 '
          }`}
        >
          <FontAwesomeIcon icon={faLayerGroup} className='h-4 w-4 text-dark_blue' />
          Overview
        </Link>
        <Link
          onClick={() => setSelectedMenu('manage')}
          href='/dashboard/manage'
          className={`font-semibold transition flex gap-2 items-center ${
            selectedMenu === 'manage' 
              ? 'text-purple-700 bg-purple-50  rounded-lg  dark:text-light dark:bg-purple-700 p-2 ' 
              : 'text-gray-700 hover:text-purple-700 dark:text-light p-2 '
          }`}
        >
          <FontAwesomeIcon icon={faList} className='h-4 w-4 text-dark_blue' />
          Manage Memorial
        </Link>
        <Link
          onClick={() => setSelectedMenu('subscriptions')}
          href='/dashboard/subscriptions'
          className={`font-bold transition flex gap-2 items-center ${
            selectedMenu === 'subscriptions' 
              ? 'text-purple-700 bg-purple-50 rounded-lg  dark:text-light dark:bg-purple-700 p-2 ' 
              : 'text-gray-700 hover:text-purple-700 dark:text-light p-2 '
          }`}
        >
          <FontAwesomeIcon icon={faCreditCard} className='h-4 w-4 text-dark_blue' />
          Subscriptions
        </Link>
        <Link
          onClick={() => setSelectedMenu('settings')}
          href='/dashboard/settings'
          className={`font-bold transition flex gap-2 items-center ${
            selectedMenu === 'settings' 
              ? 'text-purple-800 bg-purple-50  rounded-lg  dark:text-light dark:bg-purple-700 p-2 ' 
              : 'text-gray-700 hover:text-purple-700 dark:text-light p-2 '
          }`}
        >
          <FontAwesomeIcon icon={faCog} className='h-4 w-4 text-dark_blue' />
          Settings
        </Link>
      </nav>
      <button className='mt-auto text-gray-600 hover:text-purple-700 transition'>Logout</button>
    </div>
  );
};

export default UserSidebar;
