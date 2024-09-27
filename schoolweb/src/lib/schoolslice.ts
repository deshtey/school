import { createSlice } from '@reduxjs/toolkit';

export interface SchoolState {
  name: string;
  id: number;
  email: string;
  logoUrl: string;
}
const initialState: SchoolState = {
  name: '',
  id: 2,
  email: '',
  logoUrl: '',
};
const schoolSlice = createSlice({
  name: 'school',
  initialState,
  reducers: {
    setSchool: (state, action) => {
      state.name = action.payload.name;
      state.id = action.payload.id;
      state.email = action.payload.email;
      state.logoUrl = action.payload.logoUrl;
    },
  },
});

export const { setSchool } = schoolSlice.actions;
export default schoolSlice.reducer;
