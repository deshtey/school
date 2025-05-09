import axios from 'axios';
import { useSelector } from 'react-redux';
import { STORAGE_KEY } from 'src/auth/context/jwt';

import { CONFIG } from 'src/config-global';

// ----------------------------------------------------------------------

const axiosInstance = axios.create({ baseURL: CONFIG.site.serverUrl });

// axiosInstance.interceptors.response.use(
//   (response) => response,
//   (error) => Promise.reject((error.response && error.response.data) || 'Something went wrong!')
// );

export default axiosInstance;

// ----------------------------------------------------------------------

export const fetcher = async (args) => {
  try {
    const [url, config] = Array.isArray(args) ? args : [args];

    const res = await axiosInstance.get(url, { ...config });

    return res.data;
  } catch (error) {
    console.error('Failed to fetch:', error);
    throw error;
  }
};
export const fetcherPost = async (url, method = 'GET', data = null) => {
  console.log(method);
  const token = sessionStorage.getItem(STORAGE_KEY);
  console.log(token);
  try {
    const config = {
      method,
      url,
      headers: {
        accept: 'text/plain',
        'Content-Type': 'application/json',
        Authorization: `Bearer ${token}`,
      },
    };

    if (data && (method === 'POST' || method === 'PUT')) {
      config.data = data;
    }

    const res = await axiosInstance(config);
    res.status(200).json(result.data);
  } catch (error) {
    throw error;
  }
};

export const endpoints = {
  auth: {
    me: '/api/auth/me',
    signIn: '/api/auth/login',
    signUp: '/api/auth/register',
  },

  school: {
    list: '/api/schools',
    details: '/api/schools',
    search: '/api/product/search',
  },
  student: {
    list: '/api/students',
    details: '/api/students',
    search: '/api/student/search',
  },
  teacher: {
    list: '/api/teachers',
    details: '/api/teachers',
    search: '/api/teachers/search',
  },
  supportStaff: {
    list: '/api/staff',
    details: '/api/staff',
    search: '/api/staff/search',
  },
  roles: {
    list: '/api/roles',
    details: '/api/roles',
    create: '/api/roles/createrole',
  },
  permissions: {
    list: '/api/permissions',
    details: '/api/permissions',
  },
  rolepermissions: {
    list: '/api/rolepermissions',
    details: '/api/rolepermissions',
  },
  grade: {
    list: '/api/grades',
    details: '/api/grades/grade',
    create: '/api/grades',
  },
  classroom: {
    list: '/api/classrooms',
    details: '/api/classrooms/classroom',
    create: '/api/classrooms',
  },
  classroomsubject: {
    list: '/api/classroomsubjects',
    details: '/api/classroomsubjects/classroomsubject',
    create: '/api/classroomsubject',
  },
  studentsubject: {
    list: '/api/studentsubjects',
    details: '/api/studentsubjects/studentsubject',
    create: '/api/studentsubjects',
  },
  schoolsubject: {
    list: '/api/schoolsubjects',
    details: '/api/schoolsubjects/schoolsubject',
    create: '/api/schoolsubjects',
  },
};
