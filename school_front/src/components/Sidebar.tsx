
"use client";
import { useState } from "react";
import { Button } from "@/components/ui/button";
import { Sheet, SheetContent, SheetTrigger } from "@/components/ui/sheet";
import { Menu, Home, Users, GraduationCap, BarChart2, ChevronRight } from "lucide-react";

const menuItems = [
  { name: "Home", Icon: Home },
  { name: "Students", Icon: Users },
  { name: "Teachers", Icon: GraduationCap },
  { name: "Grades", Icon: BarChart2 },
];

export function Sidebar() {
  const [open, setOpen] = useState(false);
  const [active, setActive] = useState("Home");

  return (
    <Sheet open={open} onOpenChange={setOpen}>
      <SheetTrigger asChild>
        <Button variant="ghost" size="icon" className="fixed left-4 top-4 z-50">
          <Menu className="h-6 w-6" />
        </Button>
      </SheetTrigger>
      <SheetContent side="left" className="w-[280px] p-0 bg-background border-r">
        <div className="h-full flex flex-col">
          <div className="p-6">
            <div className="flex items-center gap-2 mb-8">
              <ChevronRight className="h-4 w-4" />
              <h2 className="font-semibold">Admin Dashboard</h2>
            </div>
            <nav className="space-y-2">
              {menuItems.map((item) => (
                <button
                  key={item.name}
                  onClick={() => setActive(item.name)}
                  className={`sidebar-item w-full ${active === item.name ? "active" : ""}`}
                >
                  <item.Icon className="h-5 w-5" />
                  <span>{item.name}</span>
                </button>
              ))}
            </nav>
          </div>
        </div>
      </SheetContent>
    </Sheet>
  );
}
