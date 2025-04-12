import React from "react";
import MainLayout from "../mainLayout";
import Link from "next/link";

const Plans: React.FC = () => {
  return (
    <MainLayout>
      <div className="bg-gradient-to-b from-purple-100  to-white  py-10 lg:px-16 sm:px-6 md:px-8 w-full">
        <div className="container mx-auto text-center">
          <h2 className="text-4xl font-bold text-gray-800">Plans for everyone</h2>
          <div className="grid grid-cols-1 md:grid-cols-3 gap-6 mt-10">
            {/* Basic Plan  */}
            <div className=" p-8 rounded-lg shadow-md">
              <div className="flex justify-center items-center mb-4">
                <div className="w-10 h-10 bg-purple-100 text-purple-600 rounded-full flex items-center justify-center">
                  ⚡
                </div>
              </div>
              <h3 className="text-lg font-semibold text-gray-800">Basic plan</h3>
              <p className="text-4xl font-bold text-gray-800 mt-4">
                $10<span className="text-lg">/mth</span>
              </p>
              <p className="text-gray-500 mt-2">Billed annually.</p>
              <ul className="text-left mt-6 space-y-3">
                <li className="flex items-center text-gray-600">
                  <span className="text-purple-500 mr-2">✔</span> Access to all basic features
                </li>
                <li className="flex items-center text-gray-600">
                  <span className="text-purple-500 mr-2">✔</span> Basic reporting and analytics
                </li>
                <li className="flex items-center text-gray-600">
                  <span className="text-purple-500 mr-2">✔</span> Up to 10 individual users
                </li>
                <li className="flex items-center text-gray-600">
                  <span className="text-purple-500 mr-2">✔</span> 20GB individual data each user
                </li>
                <li className="flex items-center text-gray-600">
                  <span className="text-purple-500 mr-2">✔</span> Basic chat and email support
                </li>
              </ul>
              <button className="mt-6 w-full bg-purple-400 text-white py-2 rounded-full hover:bg-purple-600 transition">
                Get started
              </button>
            </div>
            {/* 
       Advanced Plan  */}
            <div className=" p-8 rounded-lg shadow-md">
              <div className="flex justify-center items-center mb-4">
                <div className="w-10 h-10 bg-purple-100 text-purple-600 rounded-full flex items-center justify-center">
                  📊
                </div>
              </div>
              <h3 className="text-lg font-semibold text-gray-800">Advanced Plan</h3>
              <p className="text-4xl font-bold text-gray-800 mt-4">
                $20<span className="text-lg">/mth</span>
              </p>
              <p className="text-gray-500 mt-2">Billed annually.</p>
              <ul className="text-left mt-6 space-y-3">
                <li className="flex items-center text-gray-600">
                  <span className="text-purple-500 mr-2">✔</span> Access to all basic features
                </li>
                <li className="flex items-center text-gray-600">
                  <span className="text-purple-500 mr-2">✔</span> Basic reporting and analytics
                </li>
                <li className="flex items-center text-gray-600">
                  <span className="text-purple-500 mr-2">✔</span> Up to 10 individual users
                </li>
                <li className="flex items-center text-gray-600">
                  <span className="text-purple-500 mr-2">✔</span> 20GB individual data each user
                </li>
                <li className="flex items-center text-gray-600">
                  <span className="text-purple-500 mr-2">✔</span> Basic chat and email support
                </li>
              </ul>
              <button className="mt-6 w-full bg-purple-400 text-white py-2 rounded-full hover:bg-purple-600 transition">
                Get started
              </button>
            </div>

            {/* Premium Plan  */}
            <div className=" p-8 rounded-lg shadow-md">
              <div className="flex justify-center items-center mb-4">
                <div className="w-10 h-10 bg-purple-100 text-purple-600 rounded-full flex items-center justify-center">
                  🌟
                </div>
              </div>
              <h3 className="text-lg font-semibold text-gray-800">Premium plan</h3>
              <p className="text-4xl font-bold text-gray-800 mt-4">
                $40<span className="text-lg">/mth</span>
              </p>
              <p className="text-gray-500 mt-2">Billed annually.</p>
              <ul className="text-left mt-6 space-y-3">
                <li className="flex items-center text-gray-600">
                  <span className="text-purple-500 mr-2">✔</span> Access to all basic features
                </li>
                <li className="flex items-center text-gray-600">
                  <span className="text-purple-500 mr-2">✔</span> Basic reporting and analytics
                </li>
                <li className="flex items-center text-gray-600">
                  <span className="text-purple-500 mr-2">✔</span> Up to 10 individual users
                </li>
                <li className="flex items-center text-gray-600">
                  <span className="text-purple-500 mr-2">✔</span> 20GB individual data each user
                </li>
                <li className="flex items-center text-gray-600">
                  <span className="text-purple-500 mr-2">✔</span> Basic chat and email support
                </li>
              </ul>
              <button className="mt-6 w-full bg-purple-400 text-white py-2 rounded-full hover:bg-purple-600 transition">
                Get started
              </button>
            </div>
          </div>
        </div>
      </div>

      <div className="bg-gray-50 py-20 px-6 lg:px-20">
        <div className="grid grid-cols-1 md:grid-cols-2 gap-8 max-w-7xl mx-auto">
          {/* Left Section  */}
          <div className="text-left">
            <h2 className="text-2xl font-bold text-gray-800">FAQs</h2>
            <p className="text-gray-600 mt-4">
              Everything you need to know about the product and billing. Can’t find the answer you’re looking for?
              Please &nbsp;
              <Link href="#" className="text-purple-600 underline">
                chat to our friendly team.
              </Link>
            </p>
          </div>

          {/* Right Section  */}
          <div>
            <div className="space-y-6">
              <div id="accordion-collapse" data-accordion="collapse">
                <h2 id="accordion-collapse-heading-1">
                  <button
                    type="button"
                    className="flex items-center justify-between w-full p-5 font-medium rtl:text-right text-gray-500 border border-b-0 border-gray-200 rounded-t-xl focus:ring-4 focus:ring-gray-200 dark:focus:ring-gray-800 dark:border-gray-700 dark:text-gray-400 hover:bg-gray-100 dark:hover:bg-gray-800 gap-3"
                    data-accordion-target="#accordion-collapse-body-1"
                    aria-expanded="true"
                    aria-controls="accordion-collapse-body-1"
                  >
                    <span>Is there a free trial available?</span>
                    <svg
                      data-accordion-icon
                      className="w-3 h-3 rotate-180 shrink-0"
                      aria-hidden="true"
                      xmlns="http://www.w3.org/2000/svg"
                      fill="none"
                      viewBox="0 0 10 6"
                    >
                      <path
                        stroke="currentColor"
                        
                        strokeLinejoin="round"
                        strokeWidth="2"
                        d="M9 5 5 1 1 5"
                      />
                    </svg>
                  </button>
                </h2>
                <div id="accordion-collapse-body-1" className="hidden" aria-labelledby="accordion-collapse-heading-1">
                  <div className="p-5 border border-b-0 border-gray-200 dark:border-gray-700 dark:bg-gray-900">
                    <p className="mb-2 text-gray-500 dark:text-gray-400">
                      {" "}
                      Yes, you can try us for free for 30 days.. If you want, well provide you with a free personalixe
                      30 -minute onboarding call to get you up and running.
                    </p>
                  </div>
                </div>
                <h2 id="accordion-collapse-heading-2">
                  <button
                    type="button"
                    className="flex items-center justify-between w-full p-5 font-medium rtl:text-right text-gray-500 border border-b-0 border-gray-200 focus:ring-4 focus:ring-gray-200 dark:focus:ring-gray-800 dark:border-gray-700 dark:text-gray-400 hover:bg-gray-100 dark:hover:bg-gray-800 gap-3"
                    data-accordion-target="#accordion-collapse-body-2"
                    aria-expanded="false"
                    aria-controls="accordion-collapse-body-2"
                  >
                    <span>Can I change my plan later?</span>
                    <svg
                      data-accordion-icon
                      className="w-3 h-3 rotate-180 shrink-0"
                      aria-hidden="true"
                      xmlns="http://www.w3.org/2000/svg"
                      fill="none"
                      viewBox="0 0 10 6"
                    >
                      <path
                        stroke="currentColor"
                        
                        strokeLinejoin="round"
                        strokeWidth="2"
                        d="M9 5 5 1 1 5"
                      />
                    </svg>
                  </button>
                </h2>
                <div id="accordion-collapse-body-2" className="hidden" aria-labelledby="accordion-collapse-heading-2">
                  <div className="p-5 border border-b-0 border-gray-200 dark:border-gray-700">
                    <p className="mb-2 text-gray-500 dark:text-gray-400">
                      Flowbite is first conceptualized and designed using the Figma software so everything you see in
                      the library has a design equivalent in our Figma file.
                    </p>
                    <p className="text-gray-500 dark:text-gray-400">
                      Check out the{" "}
                      <a
                        href="https://flowbite.com/figma/"
                        className="text-blue-600 dark:text-blue-500 hover:underline"
                      >
                        Figma design system
                      </a>{" "}
                      based on the utility classes from Tailwind CSS and components from Flowbite.
                    </p>
                  </div>
                </div>
                <h2 id="accordion-collapse-heading-3">
                  <button
                    type="button"
                    className="flex items-center justify-between w-full p-5 font-medium rtl:text-right text-gray-500 border border-gray-200 focus:ring-4 focus:ring-gray-200 dark:focus:ring-gray-800 dark:border-gray-700 dark:text-gray-400 hover:bg-gray-100 dark:hover:bg-gray-800 gap-3"
                    data-accordion-target="#accordion-collapse-body-3"
                    aria-expanded="false"
                    aria-controls="accordion-collapse-body-3"
                  >
                    <span>What is your cancellation Policy?</span>
                    <svg
                      data-accordion-icon
                      className="w-3 h-3 rotate-180 shrink-0"
                      aria-hidden="true"
                      xmlns="http://www.w3.org/2000/svg"
                      fill="none"
                      viewBox="0 0 10 6"
                    >
                      <path
                        stroke="currentColor"
                        
                        strokeLinejoin="round"
                        strokeWidth="2"
                        d="M9 5 5 1 1 5"
                      />
                    </svg>
                  </button>
                </h2>
                <div id="accordion-collapse-body-3" className="hidden" aria-labelledby="accordion-collapse-heading-3">
                  <div className="p-5 border border-t-0 border-gray-200 dark:border-gray-700">
                    <p className="mb-2 text-gray-500 dark:text-gray-400">
                      The main difference is that the core components from Flowbite are open source under the MIT
                      license, whereas Tailwind UI is a paid product. Another difference is that Flowbite relies on
                      smaller and standalone components, whereas Tailwind UI offers sections of pages.
                    </p>
                  </div>
                </div>

                <h2 id="accordion-collapse-heading-4">
                  <button
                    type="button"
                    className="flex items-center justify-between w-full p-5 font-medium rtl:text-right text-gray-500 border border-gray-200 focus:ring-4 focus:ring-gray-200 dark:focus:ring-gray-800 dark:border-gray-700 dark:text-gray-400 hover:bg-gray-100 dark:hover:bg-gray-800 gap-3"
                    data-accordion-target="#accordion-collapse-body-3"
                    aria-expanded="false"
                    aria-controls="accordion-collapse-body-4"
                  >
                    <span>Can other info be added to an invoice?</span>
                    <svg
                      data-accordion-icon
                      className="w-3 h-3 rotate-180 shrink-0"
                      aria-hidden="true"
                      xmlns="http://www.w3.org/2000/svg"
                      fill="none"
                      viewBox="0 0 10 6"
                    >
                      <path
                        stroke="currentColor"
                        
                        strokeLinejoin="round"
                        strokeWidth="2"
                        d="M9 5 5 1 1 5"
                      />
                    </svg>
                  </button>
                </h2>
                <div id="accordion-collapse-body-4" className="hidden" aria-labelledby="accordion-collapse-heading-4">
                  <div className="p-5 border border-t-0 border-gray-200 dark:border-gray-700">
                    <p className="mb-2 text-gray-500 dark:text-gray-400">
                      The main difference is that the core components from Flowbite are open source under the MIT
                      license, whereas Tailwind UI is a paid product. Another difference is that Flowbite relies on
                      smaller and standalone components, whereas Tailwind UI offers sections of pages.
                    </p>
                  </div>
                </div>

                <h2 id="accordion-collapse-heading-5">
                  <button
                    type="button"
                    className="flex items-center justify-between w-full p-5 font-medium rtl:text-right text-gray-500 border border-gray-200 focus:ring-4 focus:ring-gray-200 dark:focus:ring-gray-800 dark:border-gray-700 dark:text-gray-400 hover:bg-gray-100 dark:hover:bg-gray-800 gap-3"
                    data-accordion-target="#accordion-collapse-body-3"
                    aria-expanded="false"
                    aria-controls="accordion-collapse-body-5"
                  >
                    <span>How does billing work?</span>
                    <svg
                      data-accordion-icon
                      className="w-3 h-3 rotate-180 shrink-0"
                      aria-hidden="true"
                      xmlns="http://www.w3.org/2000/svg"
                      fill="none"
                      viewBox="0 0 10 6"
                    >
                      <path
                        stroke="currentColor"
                        
                        strokeLinejoin="round"
                        strokeWidth="2"
                        d="M9 5 5 1 1 5"
                      />
                    </svg>
                  </button>
                </h2>
                <div id="accordion-collapse-body-5" className="hidden" aria-labelledby="accordion-collapse-heading-5">
                  <div className="p-5 border border-t-0 border-gray-200 dark:border-gray-700">
                    <p className="mb-2 text-gray-500 dark:text-gray-400">
                      The main difference is that the core components from Flowbite are open source under the MIT
                      license, whereas Tailwind UI is a paid product. Another difference is that Flowbite relies on
                      smaller and standalone components, whereas Tailwind UI offers sections of pages.
                    </p>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

       {/* Last section before footer - Honor your loved ones today */}

       <div className="bg-purple-50 py-16 lg:px-16 sm:px-6 md:px-8 w-full">
          <div className="container mx-auto text-center">
            <h2 className="text-3xl font-bold text-gray-800">Honor your loved ones today</h2>
            <p className="text-gray-600 mt-4">
              Create a lasting tribute and share memories that will be cherished forever
            </p>
            <button className="mt-6 bg-purple-400 text-white py-2 px-6 rounded-full hover:bg-purple-500 transition">
              Create a memorial
            </button>
          </div>

          {/* <div className="absolute top-0 left-0 w-32 h-32 bg-purple-200 rounded-full opacity-50 transform -translate-x-16 -translate-y-16"></div>
          <div className="absolute bottom-0 right-0 w-40 h-40 bg-purple-200 rounded-full opacity-50 transform translate-x-16 translate-y-16"></div> */}
        </div>
    </MainLayout>
  );
};

export default Plans;
