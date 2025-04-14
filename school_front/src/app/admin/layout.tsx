"use client";
import { AuthGuard } from "@/auth/guard/auth-guard";
import Sidebar from "@/components/layout/SidebarAdmin";
import Topbar from "@/components/layout/Topbar";
import { CONFIG } from "@/config-global";
import { cn } from "@/lib/utils";
import { useState } from "react";

export default function Layout({ children }: { children: React.ReactNode }) {
  if (CONFIG.auth.skip) {
      // return <AdminLayout>{children}</AdminLayout>;
      return <div>{children}</div>;
  }
 const [sidebarOpen, setSidebarOpen] = useState(true);
  return (
    <AuthGuard>
    <div className="min-h-screen min-w-full bg-background dark:bg-dark-900">
      <Sidebar isOpen={sidebarOpen} setIsOpen={setSidebarOpen} />
      <div className={cn("transition-all duration-300 bg-pink-50", sidebarOpen ? "ml-64" : "ml-20")}>
        <Topbar sidebarOpen={sidebarOpen} setSidebarOpen={setSidebarOpen} />
        <main className="container mx-auto  mt-20 xl:p-2 xxl:p-4">
          {children}
        </main>
      </div>
    </div>
    </AuthGuard>
  );
}
