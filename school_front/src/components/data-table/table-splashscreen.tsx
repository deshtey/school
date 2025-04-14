
import React from "react";
import { Skeleton } from "@/components/ui/skeleton";

interface TableSplashScreenProps {
  columnCount: number;
  rowCount?: number;
}

export const TableSplashScreen = ({
  columnCount,
  rowCount = 5,
}: TableSplashScreenProps) => {
  return (
    <div className="space-y-4 w-full">
      <div className="flex justify-between">
        <Skeleton className="h-10 w-64" />
        <Skeleton className="h-10 w-32" />
      </div>
      
      <div className="rounded-md border">
        <div className="grid">
          {/* Table Header */}
          <div className="grid grid-cols-12 border-b">
            {Array.from({ length: columnCount }).map((_, index) => (
              <div 
                key={`header-${index}`} 
                className={`col-span-${Math.floor(12 / columnCount)} p-4`}
              >
                <Skeleton className="h-4 w-24" />
              </div>
            ))}
          </div>
          
          {/* Table Rows */}
          {Array.from({ length: rowCount }).map((_, rowIndex) => (
            <div 
              key={`row-${rowIndex}`} 
              className="grid grid-cols-12 border-b last:border-b-0"
            >
              {Array.from({ length: columnCount }).map((_, colIndex) => (
                <div 
                  key={`cell-${rowIndex}-${colIndex}`} 
                  className={`col-span-${Math.floor(12 / columnCount)} p-4`}
                >
                  <Skeleton className="h-4 w-full" />
                </div>
              ))}
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};