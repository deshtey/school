'use client';

import { configureStore } from '@reduxjs/toolkit';
import authReducer from './authSlice';
import schoolReducer from './schoolslice';

export const store = configureStore({
  reducer: {
    auth: authReducer,
    school: schoolReducer,
  },
});

// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>;
// Inferred type: {posts: PostsState, comments: CommentsState, users: UsersState}
export type AppDispatch = typeof store.dispatch;
