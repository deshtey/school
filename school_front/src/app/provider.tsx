"use client";

import { Provider } from "react-redux";
import { store } from "@/lib/features/store";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider/LocalizationProvider";
import { ThemeToggle } from "@/components/ui/theme-toggle";
import { ThemeProvider } from "next-themes";
import ToastContainer from "@/components/ui/toast-container";
import { ToastProvider } from "@/components/ui/toast-content";


const queryClient = new QueryClient();
export function Providers({ children }: { children: React.ReactNode }) {
  return (
    <ThemeProvider attribute='class' defaultTheme='system' enableSystem>
      <ThemeToggle />

      <ToastProvider>
        <ToastContainer />

        {/* <LocalizationProvider dateAdapter={datefns}> */}
          <Provider store={store}>
            <QueryClientProvider client={queryClient}>{children}</QueryClientProvider>
          </Provider>
        {/* </LocalizationProvider> */}
      </ToastProvider>
    </ThemeProvider>
  );
}
