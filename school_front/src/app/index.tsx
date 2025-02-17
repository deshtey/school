// app/page.tsx

import Link from "next/link";
import IndexLayout from "./IndexLayout";
export default function Home() {
  return (
    <IndexLayout>
 
        {/* What Our Users Say About Us, Testimonials */}

        <div className='bg-gray-100 py-16 lg:px-16 sm:px-6 md:px-8 w-full'>
          <div className='container mx-auto text-center'>
            <h2 className='text-3xl font-bold text-gray-800'>What Our Users Say About Us</h2>
            <p className='text-purple-500 text-sm mt-2'>Testimonials</p>
            <div className='grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6 mt-10'>
              <div className=' p-6 rounded-lg shadow-md'>
                <blockquote className='text-gray-600 italic'>
                  “Lorem ipsum dolor sit amet consectetur. Rhoncus integer cras venenatis diam.”
                </blockquote>
                <div className='flex items-center justify-between mt-4'>
                  <span className='text-sm font-medium text-gray-700'>@Jane Doe</span>
                  <img src='https://via.placeholder.com/24' alt='User Avatar' className='w-6 h-6 rounded-full' />
                </div>
              </div>
              <div className=' p-6 rounded-lg shadow-md'>
                <blockquote className='text-gray-600 italic'>
                  “Lorem ipsum dolor sit amet consectetur. Rhoncus integer cras venenatis diam.”
                </blockquote>
                <div className='flex items-center justify-between mt-4'>
                  <span className='text-sm font-medium text-gray-700'>@Jane Doe</span>
                  <img src='https://via.placeholder.com/24' alt='User Avatar' className='w-6 h-6 rounded-full' />
                </div>
              </div>
              <div className=' p-6 rounded-lg shadow-md'>
                <blockquote className='text-gray-600 italic'>
                  “Lorem ipsum dolor sit amet consectetur. Rhoncus integer cras venenatis diam.”
                </blockquote>
                <div className='flex items-center justify-between mt-4'>
                  <span className='text-sm font-medium text-gray-700'>@Jane Doe</span>
                  <img src='https://via.placeholder.com/24' alt='User Avatar' className='w-6 h-6 rounded-full' />
                </div>
              </div>
              <div className=' p-6 rounded-lg shadow-md'>
                <blockquote className='text-gray-600 italic'>
                  “Lorem ipsum dolor sit amet consectetur. Rhoncus integer cras venenatis diam.”
                </blockquote>
                <div className='flex items-center justify-between mt-4'>
                  <span className='text-sm font-medium text-gray-700'>@Jane Doe</span>
                  <img src='https://via.placeholder.com/24' alt='User Avatar' className='w-6 h-6 rounded-full' />
                </div>
              </div>
            </div>
          </div>
        </div>

        {/* Last section before footer - Honor your loved ones today */}

        <div className='bg-purple-50 py-16 lg:px-16 sm:px-6 md:px-8 w-full'>
          <div className='container mx-auto text-center'>
            <h2 className='text-3xl font-bold text-gray-800'>Honor your loved ones today</h2>
            <p className='text-gray-600 mt-4'>
              Create a lasting tribute and share memories that will be cherished forever
            </p>
            <button className='mt-6 bg-purple-400 text-white py-2 px-6 rounded-full hover:bg-purple-500 transition'>
              Create a memorial
            </button>
          </div>

          {/* <div className="absolute top-0 left-0 w-32 h-32 bg-purple-200 rounded-full opacity-50 transform -translate-x-16 -translate-y-16"></div>
          <div className="absolute bottom-0 right-0 w-40 h-40 bg-purple-200 rounded-full opacity-50 transform translate-x-16 translate-y-16"></div> */}
        </div>
   
    </IndexLayout>
  );
}
