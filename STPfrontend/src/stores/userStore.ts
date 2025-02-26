import { defineStore } from 'pinia';
import axios from 'axios';
import type { UserState } from '../interface/user-state.interface';

// const api = axios.create({
//   baseURL: 'https://localhost:5245',
//   headers: {
//     Accept: '*/*',
//     'Content-Type': 'application/json',
//   },
//   timeout: 5000,
// });
export const useUsersStore = defineStore({
  id: 'users',
  state: (): UserState => ({
    users: [],
    currentEditId: undefined,
    currentUserId: 0,
    currentUserName: '',
    token: undefined,
  }),
  getters: {
    authorizationHeader: (state) => {
      return state.token ? { Authorization: `Bearer ${state.token}` } : {};
    },
  },
  actions: {
    async logUserIn(username: string, password: string) {
      const res = await axios.post(
        'http://localhost:5245/api/Authenticate/login',
        {
          username,
          password,
        }
      );
      const { payload, token } = res.data;

      this.currentUserName = await payload.username;
      this.currentUserId = await payload.id;
      console.log(payload);
      this.token = token;

      localStorage.setItem('token', token);
      return true;
    },
    initializeStore() {
      const token = localStorage.getItem('token');
      if (token) {
        this.token = token;
      }
    },
  },
});
