import React from "react";
import IndexLayout from "../IndexLayout";
import { MemorialCard } from "@/components/memorials";

const Memorials: React.FC = () => {
  return (
    <IndexLayout>
      <div className="pt-3 w-full">
        <div className="py-6 lg:px-16 sm:px-6 md:px-8 w-full">
          <h1 className="text-5xl font-bold mb-3">
            <span className="text-gray-800">Honoring the </span>
            <span className="text-memories">Loved Ones </span>
          </h1>

          <p className="text-gray-600 text-lg max-w-3xl mx-auto mb-6">
            Explore heartfelt tributes to cherished loved ones. These memorials keep their memories alive, offering a
            place for family and friends to come together, share stories, and find comfort.
          </p>

          <div className="mt-4 flex justify-start">
            <MemorialCard />
          </div>
        </div>
      </div>
    </IndexLayout>
  );
};

export default Memorials;
