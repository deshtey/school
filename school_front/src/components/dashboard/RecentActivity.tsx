
import { Avatar, AvatarFallback } from "@/components/ui/avatar";
import { cn } from "@/lib/utils";

interface ActivityItem {
  id: string;
  user: {
    name: string;
    initials: string;
  };
  action: string;
  target: string;
  timestamp: string;
}

const activities: ActivityItem[] = [
  {
    id: "1",
    user: {
      name: "Sarah Johnson",
      initials: "SJ",
    },
    action: "updated grades for",
    target: "Math 101",
    timestamp: "10 minutes ago",
  },
  {
    id: "2",
    user: {
      name: "Michael Chen",
      initials: "MC",
    },
    action: "submitted assignment for",
    target: "English Literature",
    timestamp: "2 hours ago",
  },
  {
    id: "3",
    user: {
      name: "Emma Davis",
      initials: "ED",
    },
    action: "created a new event",
    target: "Science Fair",
    timestamp: "Yesterday",
  },
  {
    id: "4",
    user: {
      name: "James Wilson",
      initials: "JW",
    },
    action: "added a new student to",
    target: "Class 10B",
    timestamp: "Yesterday",
  },
];

const RecentActivity = ({ className }: { className?: string }) => {
  return (
    <div className={cn("dashboard-card", className)}>
      <h3 className="mb-4 text-lg font-semibold">Recent Activity</h3>
      <div className="space-y-4">
        {activities.map((activity) => (
          <div key={activity.id} className="flex items-start gap-3">
            <Avatar className="h-8 w-8">
              <AvatarFallback className="bg-school-lightPurple text-school-darkPurple text-xs">
                {activity.user.initials}
              </AvatarFallback>
            </Avatar>
            <div>
              <p className="text-sm">
                <span className="font-medium">{activity.user.name}</span>{" "}
                {activity.action}{" "}
                <span className="font-medium">{activity.target}</span>
              </p>
              <p className="text-xs text-muted-foreground">
                {activity.timestamp}
              </p>
            </div>
          </div>
        ))}
      </div>
      <button className="mt-4 text-sm font-medium text-school-purple hover:underline">
        View all activity
      </button>
    </div>
  );
};

export default RecentActivity;
