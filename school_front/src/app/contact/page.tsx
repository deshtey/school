import React from "react";
import Layout from "../dashboard/layout";
import { Img } from "@/components/Img/Index";
import Link from "next/link";
import { useForm } from "react-hook-form";
import ContactForm from "./ContactForm";

const Contact: React.FC = () => {

  return (
    <Layout>
      <div className="bg-gradient-to-b from-purple-100  to-white  py-10 lg:px-16 sm:px-6 md:px-8 w-full">
      <h1 className="text-4xl font-bold mb-3">
            <span className="text-gray-800">Contact Us </span>
           
          </h1>
         
      </div>
      <div className=" py-12 px-6 lg:px-20">
        <div className="grid grid-cols-1 lg:grid-cols-2 gap-20 max-w-7xl mx-auto text-left">
          <div>
            <h2 className="text-2xl font-bold text-gray-800">Get in touch</h2>
            <p className="text-gray-600 mt-4">Our friendly team would love to hear from you.</p>
           <ContactForm />
          </div>

          <div>
          <Img src="contact-us.png" width={250} height={252} 
              alt="Support team"
              className="w-full h-full object-cover rounded-md shadow-md"
            />
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
    </Layout>
  );
};

export default Contact;
