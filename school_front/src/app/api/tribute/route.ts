// app/api/auth/route.ts
import axiosInstance from "@/lib/axios";
import { NextRequest, NextResponse } from "next/server";

// Types
type User = {
  id: string;
  email: string;
  password: string;
};

// Named export for POST method
export async function POST(request: NextRequest) {
  try {
    const body = await request.json();
    const { action, email, password, firstname, lastname, othername } = body;

    switch (action) {
      case "tribute_create":
        const signupObj = {
          email,
          password,
          firstname,
          lastname,
          othername,
        };
        return handleCreateTribute(signupObj);

      default:
        return Response.json({ error: "Invalid action" }, { status: 400 });
    }
  } catch (error) {
    return Response.json({ error: "Internal server error" }, { status: 500 });
  }
}

// If you need other HTTP methods, export them similarly:
export async function GET(request: NextRequest) {
  return Response.json({ message: "Auth endpoint ready" });
}

// Helper functions
async function handleCreateTribute(data: any) {
  const dat = JSON.stringify(data);
  const response: any = await axiosInstance.post("/auth/register", dat);
  if (response.ok) {
    return Response.json(
      {
        message: "Create tribute successfully",
      },
      { status: 201 }
    );
  } else {
    return Response.json(
      {
        message: response.data.message,
      },
      { status: response.status }
    );
  }
}


