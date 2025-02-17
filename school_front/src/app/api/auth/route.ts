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
      case "signup":
        const signupObj = {
          email,
          password,
          firstname,
          lastname,
          othername,
        };
        return handleRegister(signupObj);
      case "signin":
        return handleLogin(email, password);
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
async function handleRegister(data: any) {
  if (!data.email || !data.password) {
    return Response.json({ error: "Missing required fields" }, { status: 400 });
  }
  const dat = JSON.stringify(data);
  console.log(dat);
  const response: any = await axiosInstance.post("/auth/register", dat);
  console.log(response);
  if (response.ok) {
    return Response.json(
      {
        message: "User registered successfully",
      },
      { status: 201 }
    );
  } else {
    console.log(response);
    return Response.json(
      {
        message: "User registration failed",
      },
      { status: 400 }
    );
  }
}

async function handleLogin(email: string, password: string) {
  if (!email || !password) {
    return NextResponse.json({ error: "Missing required fields" }, { status: 400 });
  }
  return NextResponse.json(
    {
      message: "Login successful",
    },
    { status: 200 }
  );
}
