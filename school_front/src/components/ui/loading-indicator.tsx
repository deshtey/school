
import React from "react";
import { Loader2 } from "lucide-react";

interface LoadingIndicatorProps {
  size?: "sm" | "md" | "lg";
  fullPage?: boolean;
  text?: string;
}

export const LoadingIndicator = ({
  size = "md",
  fullPage = false,
  text = "Loading...",
}: LoadingIndicatorProps) => {
  const sizeMap = {
    sm: "h-4 w-4",
    md: "h-8 w-8",
    lg: "h-12 w-12",
  };

  if (fullPage) {
    return (
      <div className="fixed inset-0 flex flex-col items-center justify-center bg-white bg-opacity-80 z-50">
        <Loader2 className={`${sizeMap[size]} animate-spin text-school-purple`} />
        {text && <p className="mt-4 text-school-darkPurple font-medium">{text}</p>}
      </div>
    );
  }

  return (
    <div className="flex flex-col items-center justify-center py-8">
      <Loader2 className={`${sizeMap[size]} animate-spin text-school-purple`} />
      {text && <p className="mt-2 text-school-darkPurple font-medium">{text}</p>}
    </div>
  );
};