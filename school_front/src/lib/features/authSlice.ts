import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import { endpoints } from "../endpoints";
import { setSession } from "../jwtutils";
import axios from "axios";

interface AuthState {
  user: {
    id?: string;
    username?: string;
    email?: string;
  } | null;
  isAuthenticated: boolean;
  loading: boolean;
  token: string | null;
  error: string | null | undefined;
}

export interface SignInCredentials {
  email: string;
  password: string;
}

interface SignInResponse {
  accessToken: string;
  user: {
    id: string;
    username: string;
    // add other user properties as needed
  };
}

const initialState: AuthState = {
  user: null,
  token: null,
  isAuthenticated: false,
  loading: false,
  error: null,
};

type Credentials = {
  email: string;
  password: string;
};

export const signup = createAsyncThunk("auth/register", async (userData: Credentials, { rejectWithValue }) => {
  try {
    const response = await axios.post(endpoints.auth.signUp, userData);
    return response.data;
  } catch (error: any) {
    return rejectWithValue(error.response.data);
  }
});

export const signIn = createAsyncThunk<SignInResponse, SignInCredentials, { rejectValue: string }>(
  "auth/signIn",
  async (credentials, { rejectWithValue }) => {
    try {
      const response = await axios.post<SignInResponse>(process.env.NEXT_PUBLIC_SERVER_URL + endpoints.auth.signIn, credentials);
      setSession(response.data.accessToken, response.data.user);
      localStorage.setItem("token", response.data.accessToken);
      localStorage.setItem("user", JSON.stringify(response.data.user));
      return response.data;
    } catch (error) {
      if (error instanceof Error) {
        return rejectWithValue(error.message);
      }
      return rejectWithValue("An unknown error occurred");
    }
  }
);
export const setAuthState = createAsyncThunk("auth/setAuthState", async (authData, { rejectWithValue }) => {
  try {
    return authData;
  } catch (error: any) {
    console.log(error);
    return rejectWithValue(error.response.data);
  }
});
export const hydrate = createAsyncThunk("auth/hydrate", async (_, { dispatch }) => {
  const token = localStorage.getItem('token');
  const userStr = localStorage.getItem('user');
  
  if (token && userStr) {
    try {
      const user = JSON.parse(userStr);
      return { token, user };
    } catch (e) {
      console.error("Failed to parse user from localStorage");
    }
  }
  return null;
});
// Add this before creating the slice
const loadInitialState = (): AuthState => {
  if (typeof window === 'undefined') {
    return initialState;
  }
  
  try {
    const token = localStorage.getItem('token');
    const userStr = localStorage.getItem('user');
    
    if (token && userStr) {
      const user = JSON.parse(userStr);
      return {
        user,
        token,
        isAuthenticated: true,
        loading: false,
        error: null,
      };
    }
  } catch (error) {
    console.error('Failed to parse user from localStorage', error);
  }
  
  return initialState;
};

// Then use it
const   initState: AuthState = loadInitialState();
const authSlice = createSlice({
  name: "auth",
  initialState: initState,
  reducers: {
    logout: (state) => {
      state.user = null;
      state.isAuthenticated = false;
      state.token = null;
      setSession("", null);
      localStorage.removeItem('token');
      localStorage.removeItem('user');
    },
    setUser: (state, action) => {
      state.user = action.payload;
    },
    setLoading: (state, action) => {
      state.loading = action.payload;
    },
    setAuthenticated: (state, action) => {
      state.isAuthenticated = action.payload;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(signup.pending, (state) => {
        state.loading = true;
      })
      .addCase(signup.fulfilled, (state, action) => {
        state.loading = false;
        state.isAuthenticated = true;
        state.user = action.payload;
      })
      .addCase(signup.rejected, (state, action) => {
        state.loading = false;
        state.error = action.error.message;
      })
      .addCase(signIn.pending, (state) => {
        
        state.loading = true;
      })
      .addCase(signIn.fulfilled, (state, action) => {
        console.log(action.payload);
        state.loading = false;
        state.isAuthenticated = true;
        state.token = action.payload.accessToken;
        state.user = action.payload.user;
      })
      .addCase(signIn.rejected, (state, action) => {
        state.loading = false;
        state.error = "Wrong credentials";
      })


      .addCase(hydrate.fulfilled, (state, action) => {
        if (action.payload) {
          state.token = action.payload.token;
          state.user = action.payload.user;
          state.isAuthenticated = true;
        }
      })
  },
});

export const { setUser, setLoading, setAuthenticated } = authSlice.actions;

export default authSlice.reducer;
