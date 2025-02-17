
import { Sidebar } from "@/components/Sidebar";
import { DashboardHeader } from "@/components/DashboardHeader";
import { Button } from "@/components/ui/button";

const Layout = ({ children }: { children: React.ReactNode }) => {
  return (
    <div className="min-h-screen flex bg-background text-foreground">
      <Sidebar />
      <main className="flex-1">
        <DashboardHeader />
        <div className="p-6">
          <div className="grid gap-4">
            <div className="flex items-center justify-between">
              <div>
                <h1 className="text-2xl font-bold">Schools</h1>
                <p className="text-muted-foreground">Manage your schools and their details</p>
              </div>
              <Button>New school</Button>
            </div>
          </div>
        </div>
      </main>
    </div>
  );
};

export default Layout ;
