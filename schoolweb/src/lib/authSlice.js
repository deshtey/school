// authSlice.js
import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { setSession } from 'src/auth/context/jwt';
import { STORAGE_KEY } from 'src/components/settings';
import axios, { endpoints } from 'src/utils/axios';

const initialState = {
  user: null,
  token: null,
  isAuthenticated: false,
  loading: false,
  error: null,
};

export const register = createAsyncThunk('auth/register', async (userData, { rejectWithValue }) => {
  try {
    const response = await axios.post('/api/register', userData);
    return response.data;
  } catch (error) {
    return rejectWithValue(error.response.data);
  }
});

export const signIn = createAsyncThunk('auth/signIn', async (credentials, { rejectWithValue }) => {
  try {
    const response = await axios.post(endpoints.auth.signIn, credentials);
    setSession(response.data.accessToken, response.data.user);
    return response.data;
  } catch (error) {
    console.log(error.message);
    return rejectWithValue(error.message);
  }
});
export const setAuthState = createAsyncThunk(
  'auth/setAuthState',
  async (authData, { rejectWithValue }) => {
    try {
      return authData;
    } catch (error) {
      console.log(error);
      return rejectWithValue(error.response.data);
    }
  }
);
const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    logout: async (state) => {
      state.user = null;
      state.isAuthenticated = false;
      await setSession(null);
      localStorage.removeItem('user');
      sessionStorage.removeItem(STORAGE_KEY);
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
      .addCase(register.pending, (state) => {
        state.loading = true;
      })
      .addCase(register.fulfilled, (state, action) => {
        state.loading = false;
        state.isAuthenticated = true;
        state.user = action.payload;
      })
      .addCase(register.rejected, (state, action) => {
        state.loading = false;
        state.error = action.error.message;
      })
      .addCase(signIn.pending, (state) => {
        state.loading = true;
      })
      .addCase(signIn.fulfilled, (state, action) => {
        state.loading = false;
        state.isAuthenticated = true;
        state.token = action.payload.accessToken;
        state.user = action.payload.user;
      })
      .addCase(signIn.rejected, (state, action) => {
        console.log(action);
        state.loading = false;
        state.error = action.error.message;
      })

      .addCase(setAuthState.fulfilled, (state, action) => {
        state.isAuthenticated = true;
        state.token = action.payload.token;
        state.user = action.payload.user;
      });
  },
});

export const { logout, setUser, setLoading, setAuthenticated } = authSlice.actions;

export default authSlice.reducer;
