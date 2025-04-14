import { Users, BookOpen, GraduationCap, Calendar } from "lucide-react";
import StatCard from "@/components/dashboard/StatCard";
import RecentActivity from "@/components/dashboard/RecentActivity";
import UpcomingEvents from "@/components/dashboard/UpcomingEvents";
import Layout from "../dashboard/layout";

const AdminDashboard = () => {
  return (
  
    <div className="animate-fade-in space-y-6">
      <div>
        <h1 className="text-2xl font-bold tracking-tight">Dashboard</h1>
        <p className="text-muted-foreground">Welcome back to your school management system.</p>
      </div>
      
      <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-4">
        <StatCard
          title="Total Students"
          value="1,248"
          icon={Users}
          trend={{ value: 4.5, isPositive: true }}
        />
        <StatCard
          title="Total Teachers"
          value="86"
          icon={BookOpen}
          trend={{ value: 2.1, isPositive: true }}
        />
        <StatCard
          title="Courses"
          value="32"
          icon={GraduationCap}
          description="Active courses this semester"
        />
        <StatCard
          title="Upcoming Events"
          value="8"
          icon={Calendar}
          description="Next 14 days"
        />
      </div>
      
      <div className="grid gap-4 md:grid-cols-2">
        <RecentActivity />
        <UpcomingEvents />
      </div>
    </div>

  );
};

export default AdminDashboard;
