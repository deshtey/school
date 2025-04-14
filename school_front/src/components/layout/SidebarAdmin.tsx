"use client";
import { useState } from "react";
import { 
  BookOpen, 
  Calendar, 
  ChevronLeft, 
  ChevronRight, 
  GraduationCap, 
  Home, 
  Settings, 
  Users,
  BookText,
  ClipboardList,
  FileSpreadsheet,
  School
} from "lucide-react";
import { cn } from "@/lib/utils";
import Link from "next/link";

interface SidebarProps {
  isOpen: boolean;
  setIsOpen: (isOpen: boolean) => void;
}

interface NavItemProps {
  icon: React.ElementType;
  label: string;
  to: string;
  isOpen: boolean;
  isActive?: boolean;
}

const NavItem = ({ icon: Icon, label, to, isOpen, isActive = false }: NavItemProps) => {
  return (
    <Link 
      href={to} 
      className={cn(
        "nav-item", 
        isActive && "active",
        !isOpen && "justify-center px-0"
      )}
    >
      <Icon className="h-5 w-5" />
      {isOpen && <span>{label}</span>}
    </Link>
  );
};

const NavSection = ({ 
  title, 
  children, 
  isOpen 
}: { 
  title: string; 
  children: React.ReactNode; 
  isOpen: boolean;
}) => {
  return (
    <div className="mb-6">
      {isOpen && (
        <h3 className="mb-2 px-3 text-xs font-semibold uppercase text-school-gray">
          {title}
        </h3>
      )}
      <div className="space-y-1">
        {children}
      </div>
    </div>
  );
};

const Sidebar = ({ isOpen, setIsOpen }: SidebarProps) => {
  return (
    <aside 
      className={cn(
        "fixed left-0 top-0 z-20 h-full border-r bg-white transition-all duration-300",
        isOpen ? "w-64" : "w-20"
      )}
    >
      <div className="flex h-16 items-center justify-between border-b px-4">
        {isOpen ? (
          <Link href="/" className="flex items-center gap-2">
            <GraduationCap className="h-8 w-8 text-school-purple" />
            <span className="text-xl font-bold">EduManager</span>
          </Link>
        ) : (
          <Link href="/" className="mx-auto">
            <GraduationCap className="h-8 w-8 text-school-purple" />
          </Link>
        )}
        <button
          onClick={() => setIsOpen(!isOpen)}
          className="rounded-full p-1 hover:bg-muted"
        >
          {isOpen ? <ChevronLeft className="h-5 w-5" /> : <ChevronRight className="h-5 w-5" />}
        </button>
      </div>

      <div className="p-3">
        <NavSection title="Main" isOpen={isOpen}>
          <NavItem icon={Home} label="Dashboard" to="/admin" isOpen={isOpen} isActive />
          <NavItem icon={School} label="Schools" to="/admin/schools" isOpen={isOpen} />

          <NavItem icon={Users} label="Students" to="/admin/students" isOpen={isOpen} />
          <NavItem icon={BookOpen} label="Teachers" to="/admin/teachers" isOpen={isOpen} />
          <NavItem icon={BookText} label="Courses" to="/admin/courses" isOpen={isOpen} />
        </NavSection>

        <NavSection title="Academic" isOpen={isOpen}>
          <NavItem icon={ClipboardList} label="Attendance" to="/attendance" isOpen={isOpen} />
          <NavItem icon={FileSpreadsheet} label="Grades" to="/grades" isOpen={isOpen} />
          <NavItem icon={Calendar} label="Schedule" to="/schedule" isOpen={isOpen} />
        </NavSection>

        <NavSection title="System" isOpen={isOpen}>
          <NavItem icon={Settings} label="Settings" to="/settings" isOpen={isOpen} />
        </NavSection>
      </div>
    </aside>
  );
};

export default Sidebar;
