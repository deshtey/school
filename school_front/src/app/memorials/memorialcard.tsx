import React from "react";
import { Img } from "../../components/Img/Index";
import Link from "next/link";

export const MemorialCard = () => {
  return (
    <div className="w-full min-h-screenpy-6 py-6 lg:px-16 sm:px-6 md:px-8 max-w-7xl mx-auto ">
      <div className="flex justify-center mb-6 w-full">
        <input
          type="text"
          placeholder="Search memorial"
          className="w-[55%]  px-4 py-2 border border-gray-300 rounded-[50px] focus:outline-none focus:ring-2 focus:ring-purple-500"
        />
        <button className="px-12 py-2 bg-purple-400 text-white rounded-[50px] ml-[-72px] hover:bg-purple-600 focus:outline-none">
          Search
        </button>
      </div>

      <div className="flex justify-center gap-4 mb-10 mt-10">
        <button className="px-4 py-2 bg-purple-400 text-white rounded-[50px] hover:bg-purple-500">
          For our loved ones
        </button>
        <button className="px-4 py-2 text-memories  rounded-[50px] hover:bg-purple-200">
          For Our beloved pets
        </button>
      </div>

      <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-6 ">
        <div className=" shadow-md rounded-lg overflow-hidden">
          <Img src="memory-dog2.png" width={250} height={252} alt="Ariel Wamuyu" className="w-full h-48 object-cover" />

          <div className="p-4 bg-gradient-to-t from-purple-200 via-purple-100 to-transparent">
            <h3 className="text-gray-800 text-lg font-semibold">Ariel Wamuyu</h3>
            <p className="text-gray-600 text-sm">7/2/1990 - 10/5/2024</p>
            <a href="#" className="text-purple-600 text-sm mt-2 inline-flex items-center hover:underline">
              View memorial
              <span className="ml-1">→</span>
            </a>
          </div>
        </div>

        <div className=" shadow-md rounded-lg overflow-hidden">
          <Img src="memory-cat1.png" width={250} height={252} alt="Ariel Wamuyu" className="w-full h-48 object-cover" />

          <div className="p-4 bg-gradient-to-t from-purple-200 via-purple-100 to-transparent">
            <h3 className="text-gray-800 text-lg font-semibold">Ariel Wamuyu</h3>
            <p className="text-gray-600 text-sm">7/2/1990 - 10/5/2024</p>
            <a href="#" className="text-purple-600 text-sm mt-2 inline-flex items-center hover:underline">
              View memorial
              <span className="ml-1">→</span>
            </a>
          </div>
        </div>
        <div className=" shadow-md rounded-lg overflow-hidden">
          <Img src="memory-dog1.png" width={250} height={252} alt="Ariel Wamuyu" className="w-full h-48 object-cover" />

          <div className="p-4 bg-gradient-to-t from-purple-200 via-purple-100 to-transparent">
            <h3 className="text-gray-800 text-lg font-semibold">Ariel Wamuyu</h3>
            <p className="text-gray-600 text-sm">7/2/1990 - 10/5/2024</p>
            <a href="#" className="text-purple-600 text-sm mt-2 inline-flex items-center hover:underline">
              View memorial
              <span className="ml-1">→</span>
            </a>
          </div>
        </div>
      </div>
      <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-6 mt-6">
        <div className=" shadow-md rounded-lg overflow-hidden">
          <Img src="memory-dog2.png" width={250} height={252} alt="Ariel Wamuyu" className="w-full h-48 object-cover" />

          <div className="p-4 bg-gradient-to-t from-purple-200 via-purple-100 to-transparent">
            <h3 className="text-gray-800 text-lg font-semibold">Ariel Wamuyu</h3>
            <p className="text-gray-600 text-sm">7/2/1990 - 10/5/2024</p>
            <a href="#" className="text-purple-600 text-sm mt-2 inline-flex items-center hover:underline">
              View memorial
              <span className="ml-1">→</span>
            </a>
          </div>
        </div>

        <div className=" shadow-md rounded-lg overflow-hidden">
          <Img src="memory-cat1.png" width={250} height={252} alt="Ariel Wamuyu" className="w-full h-48 object-cover" />

          <div className="p-4 bg-gradient-to-t from-purple-200 via-purple-100 to-transparent">
            <h3 className="text-gray-800 text-lg font-semibold">Ariel Wamuyu</h3>
            <p className="text-gray-600 text-sm">7/2/1990 - 10/5/2024</p>
            <a href="#" className="text-purple-600 text-sm mt-2 inline-flex items-center hover:underline">
              View memorial
              <span className="ml-1">→</span>
            </a>
          </div>
        </div>
        <div className=" shadow-md rounded-lg overflow-hidden">
          <Img src="memory-dog1.png" width={250} height={252} alt="Ariel Wamuyu" className="w-full h-48 object-cover" />

          <div className="p-4 bg-gradient-to-t from-purple-200 via-purple-100 to-transparent">
            <h3 className="text-gray-800 text-lg font-semibold">Ariel Wamuyu</h3>
            <p className="text-gray-600 text-sm">7/2/1990 - 10/5/2024</p>
            <a href="#" className="text-purple-600 text-sm mt-2 inline-flex items-center hover:underline">
              View memorial
              <span className="ml-1">→</span>
            </a>
          </div>
        </div>
      </div>

      <div className="flex justify-center mt-16">
        <button className="px-8 py-3 bg-purple-400 text-white rounded-[50px]  hover:bg-purple-600">Load more</button>
      </div>

      {/* Recently Added Memories */}

      <div className="text-left mt-16">
        <h1 className="text-4xl font-bold mb-3">
          <span className="text-gray-800">Recently added memorials </span>
        </h1>
        <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-6 mt-6">
          <div className=" shadow-md rounded-lg overflow-hidden">
            <Img
              src="memory-dog2.png"
              width={250}
              height={252}
              alt="Ariel Wamuyu"
              className="w-full h-48 object-cover"
            />

            <div className="p-4 bg-gradient-to-t from-purple-200 via-purple-100 to-transparent">
              <h3 className="text-gray-800 text-lg font-semibold">Ariel Wamuyu</h3>
              <p className="text-gray-600 text-sm">7/2/1990 - 10/5/2024</p>
              <a href="#" className="text-purple-600 text-sm mt-2 inline-flex items-center hover:underline">
                View memorial
                <span className="ml-1">→</span>
              </a>
            </div>
          </div>

          <div className=" shadow-md rounded-lg overflow-hidden">
            <Img
              src="memory-cat1.png"
              width={250}
              height={252}
              alt="Ariel Wamuyu"
              className="w-full h-48 object-cover"
            />

            <div className="p-4 bg-gradient-to-t from-purple-200 via-purple-100 to-transparent">
              <h3 className="text-gray-800 text-lg font-semibold">Ariel Wamuyu</h3>
              <p className="text-gray-600 text-sm">7/2/1990 - 10/5/2024</p>
              <a href="#" className="text-purple-600 text-sm mt-2 inline-flex items-center hover:underline">
                View memorial
                <span className="ml-1">→</span>
              </a>
            </div>
          </div>
          <div className=" shadow-md rounded-lg overflow-hidden">
            <Img
              src="memory-dog1.png"
              width={250}
              height={252}
              alt="Ariel Wamuyu"
              className="w-full h-48 object-cover"
            />

            <div className="p-4 bg-gradient-to-t from-purple-200 via-purple-100 to-transparent">
              <h3 className="text-gray-800 text-lg font-semibold">Ariel Wamuyu</h3>
              <p className="text-gray-600 text-sm">7/2/1990 - 10/5/2024</p>
              <a href="#" className="text-purple-600 text-sm mt-2 inline-flex items-center hover:underline">
                View memorial
                <span className="ml-1">→</span>
              </a>
            </div>
          </div>
        </div>
      </div>
      {/* Last section before footer - Honor your loved ones today */}
      <div className="bg-purple-50 py-16 lg:px-16 sm:px-6 md:px-8 w-full max-w-7xl mx-auto">
        <div className="container mx-auto text-center">
          <h2 className="text-3xl font-bold text-gray-800">Honor your loved ones today</h2>
          <p className="text-gray-600 mt-4">
            Create a lasting tribute and share memories that will be cherished forever
          </p>

        </div>
        <div className=" mt-4">
        <Link href="/memorials/new" className=" bg-purple-400 text-white py-2 px-6 rounded-full hover:bg-purple-500 transition">
            Create a memorial
          </Link>
          </div>
        {/* <div className="absolute top-0 left-0 w-32 h-32 bg-purple-200 rounded-full opacity-50 transform -translate-x-16 -translate-y-16"></div>
          <div className="absolute bottom-0 right-0 w-40 h-40 bg-purple-200 rounded-full opacity-50 transform translate-x-16 translate-y-16"></div> */}
      </div>
    </div>
    
  );
};
