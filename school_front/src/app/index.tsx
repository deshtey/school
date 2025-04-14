// app/page.tsx

import { Button } from "@/components/ui/button";
import RootLayout from "./layout";
import Link from "next/link";
import { Text } from "lucide-react";
import { Img } from "@/components/ui/Img/Index";
export default function Home() {
  return (
    <RootLayout>
      <div className='pt-3 w-full'>
        <div className=' py-6 lg:px-16 sm:px-6 md:px-8'>
          <h1 className='text-5xl font-bold mb-3'>
            <span className='text-gray-800 dark:text-memorial-400'>Honoring the </span>
            <span className='text-memories dark:text-memorial-400'>Memories </span>
            <span className='text-gray-800 dark:text-memorial-400'>
              of Those <br /> We Love{" "}
            </span>
          </h1>

          <p className='text-gray-600 dark:text-memorial-400 text-lg max-w-3xl mx-auto mb-2'>
            A peaceful place to celebrate the lives of our beloved companions, sharing cherished memories and honoring
            their lasting impact on our hearts
          </p>
    
        <Button className='bg-purple-400  text-white px-8 py-2 rounded-[50px] hover:bg-purple-500 transition-colors text-lg'>
          <Link href='memorials/new' className='cursor-pointer'>
            <Text >Create a memorial </Text>
          </Link>
        </Button>
        </div>
        <div className='mt-10 py-2 lg:px-16 sm:px-6 md:px-8'>
          {/* <ImageCollage /> */}
        </div>
        {/* What we offer */}
        <div className='bg-gradient-to-b from-white to-purple-100 dark:from-gray-700 dark:to-gray-900 py-6 lg:px-16 sm:px-6 md:px-8 w-full '>
          <div className='text-center mb-12'>
            <p className='text-purple-500 font-medium'>Features</p>
            <h2 className='text-2xl md:text-4xl font-bold text-gray-800 dark:text-light'>What we offer</h2>
          </div>

          <div className='max-w-5xl mx-auto grid grid-cols-1 md:grid-cols-3 gap-8 pb-16'>
            <div className='text-center'>
              <div className='flex justify-center items-center w-20 h-20 mx-auto rounded-full border-2 border-dashed border-purple-300'>
                <svg
                  className='w-10 h-10 text-purple-700'
                  xmlns='http://www.w3.org/2000/svg'
                  fill='currentColor'
                  viewBox='0 0 24 24'
                >
                  <path d='M12 21.35l-1.45-1.32C5.4 15.36 2 12.28 2 8.5 2 5.42 4.42 3 7.5 3c1.74 0 3.41.81 4.5 2.09C13.09 3.81 14.76 3 16.5 3 19.58 3 22 5.42 22 8.5c0 3.78-3.4 6.86-8.55 11.54L12 21.35z' />
                </svg>
              </div>
              <h3 className='mt-6 text-lg font-semibold text-gray-800'>Personalized Memorials</h3>
              <p className='mt-2 text-sm text-gray-600 dark:text-purple-200'>
                Create unique memorial pages that celebrate the lives of those you cherish.
              </p>
            </div>

            <div className='text-center'>
              <div className='flex justify-center items-center w-20 h-20 mx-auto rounded-full border-2 border-dashed border-purple-300'>
                <svg
                  className='w-10 h-10 text-purple-700'
                  xmlns='http://www.w3.org/2000/svg'
                  fill='currentColor'
                  viewBox='0 0 24 24'
                >
                  <path d='M3 4v16c0 1.1.9 2 2 2h14c1.1 0 2-.9 2-2V4H3zm14 14H7v-2h10v2zm0-4H7v-2h10v2zm0-4H7V8h10v2z' />
                </svg>
              </div>
              <h3 className='mt-6 text-lg font-semibold text-gray-800'>Tribute Sharing</h3>
              <p className='mt-2 text-sm text-gray-600 dark:text-purple-200'>
                Share stories, photos, and memories with others, keeping their spirit alive.
              </p>
            </div>

            <div className='text-center'>
              <div className='flex justify-center items-center w-20 h-20 mx-auto rounded-full border-2 border-dashed border-purple-300'>
                <svg
                  className='w-10 h-10 text-purple-700'
                  xmlns='http://www.w3.org/2000/svg'
                  fill='currentColor'
                  viewBox='0 0 24 24'
                >
                  <path d='M22 12h-4l-3 9-5-18-3 9H2' />
                </svg>
              </div>
              <h3 className='mt-6 text-lg font-semibold text-gray-800'>Community Support</h3>
              <p className='mt-2 text-sm text-gray-600 dark:text-purple-200'>
                Connect with others who understand your loss and offer mutual support.
              </p>
            </div>
          </div>
        </div>

        {/* Remembering Our loved ones section with search */}

        <div className='bg-gray-50 dark:bg-gray-800 min-h-screenpy-6 py-20 lg:px-16 sm:px-6 md:px-8 max-w-7xl mx-auto '>
          <header className='text-center mb-8'>
            <h1 className='text-purple-600 text-sm font-medium'>Memorials</h1>
            <h2 className='text-2xl md:text-4xl font-bold text-gray-800'>Remembering our loved ones</h2>
          </header>

          <div className='flex justify-center mb-6 w-full'>
            <input
              type='text'
              placeholder='Search memorial'
              className='w-full  px-4 py-2 border border-gray-300 rounded-[50px] focus:outline-none focus:ring-2 focus:ring-purple-500'
            />
            <Button className='px-12 py-2 bg-purple-400 text-white rounded-[50px] ml-[-72px] hover:bg-purple-600 focus:outline-none'>
              Search
            </Button>
          </div>

          <div className='flex justify-center gap-4 mb-16'>
            <Button className='px-4 py-2 bg-purple-400 text-white rounded-[50px] hover:bg-purple-500'>
              For our loved ones
            </Button>
            <Button className='px-4 py-2 text-memories  rounded-[50px] hover:bg-purple-200'>
              For Our beloved pets
            </Button>
          </div>

          <div className='grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-6 '>
            <div className=' shadow-md rounded-lg overflow-hidden'>
              <Img
                src='memory-dog2.png'
                width={250}
                height={252}
                alt='Ariel Wamuyu'
                className='w-full h-48 object-cover'
              />

              <div className='p-4 bg-gradient-to-t from-purple-200 via-purple-100 to-transparent'>
                <h3 className='text-gray-800 text-lg font-semibold'>Ariel Wamuyu</h3>
                <p className='text-gray-600 text-sm'>7/2/1990 - 10/5/2024</p>
                <a href='#' className='text-purple-600 text-sm mt-2 inline-flex items-center hover:underline'>
                  View memorial
                  <span className='ml-1'>→</span>
                </a>
              </div>
            </div>

            <div className=' shadow-md rounded-lg overflow-hidden'>
              <Img
                src='memory-cat1.png'
                width={250}
                height={252}
                alt='Ariel Wamuyu'
                className='w-full h-48 object-cover'
              />

              <div className='p-4 bg-gradient-to-t from-purple-200 via-purple-100 to-transparent'>
                <h3 className='text-gray-800 text-lg font-semibold'>Ariel Wamuyu</h3>
                <p className='text-gray-600 text-sm'>7/2/1990 - 10/5/2024</p>
                <a href='#' className='text-purple-600 text-sm mt-2 inline-flex items-center hover:underline'>
                  View memorial
                  <span className='ml-1'>→</span>
                </a>
              </div>
            </div>
            <div className=' shadow-md rounded-lg overflow-hidden'>
              <Img
                src='memory-dog1.png'
                width={250}
                height={252}
                alt='Ariel Wamuyu'
                className='w-full h-48 object-cover'
              />

              <div className='p-4 bg-gradient-to-t from-purple-200 via-purple-100 to-transparent'>
                <h3 className='text-gray-800 text-lg font-semibold'>Ariel Wamuyu</h3>
                <p className='text-gray-600 text-sm'>7/2/1990 - 10/5/2024</p>
                <a href='#' className='text-purple-600 text-sm mt-2 inline-flex items-center hover:underline'>
                  View memorial
                  <span className='ml-1'>→</span>
                </a>
              </div>
            </div>
          </div>
          <div className='grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-6 mt-6'>
            <div className=' shadow-md rounded-lg overflow-hidden'>
              <Img
                src='memory-dog2.png'
                width={250}
                height={252}
                alt='Ariel Wamuyu'
                className='w-full h-48 object-cover'
              />

              <div className='p-4 bg-gradient-to-t from-purple-200 via-purple-100 to-transparent'>
                <h3 className='text-gray-800 text-lg font-semibold'>Ariel Wamuyu</h3>
                <p className='text-gray-600 text-sm'>7/2/1990 - 10/5/2024</p>
                <a href='#' className='text-purple-600 text-sm mt-2 inline-flex items-center hover:underline'>
                  View memorial
                  <span className='ml-1'>→</span>
                </a>
              </div>
            </div>

            <div className=' shadow-md rounded-lg overflow-hidden'>
              <Img
                src='memory-cat1.png'
                width={250}
                height={252}
                alt='Ariel Wamuyu'
                className='w-full h-48 object-cover'
              />

              <div className='p-4 bg-gradient-to-t from-purple-200 via-purple-100 to-transparent'>
                <h3 className='text-gray-800 text-lg font-semibold'>Ariel Wamuyu</h3>
                <p className='text-gray-600 text-sm'>7/2/1990 - 10/5/2024</p>
                <a href='#' className='text-purple-600 text-sm mt-2 inline-flex items-center hover:underline'>
                  View memorial
                  <span className='ml-1'>→</span>
                </a>
              </div>
            </div>
            <div className=' shadow-md rounded-lg overflow-hidden'>
              <Img
                src='memory-dog1.png'
                width={250}
                height={252}
                alt='Ariel Wamuyu'
                className='w-full h-48 object-cover'
              />

              <div className='p-4 bg-gradient-to-t from-purple-200 via-purple-100 to-transparent'>
                <h3 className='text-gray-800 text-lg font-semibold'>Ariel Wamuyu</h3>
                <p className='text-gray-600 text-sm'>7/2/1990 - 10/5/2024</p>
                <a href='#' className='text-purple-600 text-sm mt-2 inline-flex items-center hover:underline'>
                  View memorial
                  <span className='ml-1'>→</span>
                </a>
              </div>
            </div>
          </div>

          <div className='flex justify-center mt-16'>
            <Button className='px-8 py-3 bg-purple-400 text-white rounded-[50px]  hover:bg-purple-600'>
              View more
            </Button>
          </div>
        </div>

        {/* What Our Users Say About Us, Testimonials */}

        <div className='bg-gray-100 dark:bg-gray-800 py-16 lg:px-16 sm:px-6 md:px-8 w-full'>
          <div className='container mx-auto text-center'>
            <h2 className='text-3xl font-bold text-gray-800 dark:text-gray-200'>What Our Users Say About Us</h2>
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

        <div className='bg-purple-50 dark:bg-gray-800 py-16 lg:px-16 sm:px-6 md:px-8 w-full'>
          <div className='container mx-auto text-center'>
            <h2 className='text-3xl font-bold text-gray-800 dark:text-gray-200'>Honor your loved ones today</h2>
            <p className='text-gray-600 mt-4 dark:text-gray-400'>
              Create a lasting tribute and share memories that will be cherished forever
            </p>

            <Button className='mt-6 bg-purple-400 text-white py-2 px-6 rounded-full hover:bg-purple-500 transition'> Create a memorial</Button>
          </div>

          {/* <div className="absolute top-0 left-0 w-32 h-32 bg-purple-200 rounded-full opacity-50 transform -translate-x-16 -translate-y-16"></div>
          <div className="absolute bottom-0 right-0 w-40 h-40 bg-purple-200 rounded-full opacity-50 transform translate-x-16 translate-y-16"></div> */}
        </div>
      </div>
    </RootLayout>
  );
}
