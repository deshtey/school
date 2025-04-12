
import { Calendar } from "lucide-react";
import { cn } from "@/lib/utils";

interface Event {
  id: string;
  title: string;
  date: string;
  time: string;
  type: "exam" | "meeting" | "activity" | "holiday";
}

const events: Event[] = [
  {
    id: "1",
    title: "Math Final Exam",
    date: "April 20, 2025",
    time: "9:00 AM - 11:00 AM",
    type: "exam",
  },
  {
    id: "2",
    title: "Parent-Teacher Meeting",
    date: "April 22, 2025",
    time: "3:30 PM - 5:00 PM",
    type: "meeting",
  },
  {
    id: "3",
    title: "Science Fair",
    date: "April 25, 2025",
    time: "10:00 AM - 2:00 PM",
    type: "activity",
  },
  {
    id: "4",
    title: "Spring Break",
    date: "May 1-7, 2025",
    time: "All Day",
    type: "holiday",
  },
];

const typeColors = {
  exam: "bg-red-100 text-red-800",
  meeting: "bg-blue-100 text-blue-800",
  activity: "bg-green-100 text-green-800",
  holiday: "bg-amber-100 text-amber-800",
};

const EventItem = ({ event }: { event: Event }) => {
  return (
    <div className="flex items-start gap-3 rounded-md border p-3">
      <div className="flex h-10 w-10 flex-shrink-0 items-center justify-center rounded-full bg-school-lightPurple">
        <Calendar className="h-5 w-5 text-school-darkPurple" />
      </div>
      <div>
        <div className="flex items-center gap-2">
          <h4 className="font-medium">{event.title}</h4>
          <span
            className={cn(
              "rounded-full px-2 py-0.5 text-xs font-medium",
              typeColors[event.type]
            )}
          >
            {event.type}
          </span>
        </div>
        <p className="text-sm text-muted-foreground">{event.date}</p>
        <p className="text-xs text-muted-foreground">{event.time}</p>
      </div>
    </div>
  );
};

const UpcomingEvents = ({ className }: { className?: string }) => {
  return (
    <div className={cn("dashboard-card", className)}>
      <h3 className="mb-4 text-lg font-semibold">Upcoming Events</h3>
      <div className="space-y-3">
        {events.map((event) => (
          <EventItem key={event.id} event={event} />
        ))}
      </div>
      <button className="mt-4 text-sm font-medium text-school-purple hover:underline">
        View calendar
      </button>
    </div>
  );
};

export default UpcomingEvents;
