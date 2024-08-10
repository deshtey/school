// authSlice.js
import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { setSession } from 'src/auth/context/jwt';
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
    return rejectWithValue(error);
  }
});

const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    logout: (state) => {
      state.user = null;
      state.isAuthenticated = false;
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
        state.error = action.payload;
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
        state.error = action.payload;
      });
  },
});

export const { logout } = authSlice.actions;

export default authSlice.reducer;
