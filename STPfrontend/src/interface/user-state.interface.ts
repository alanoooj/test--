import type { User } from '@/interface/user.interface';

export interface UserState {
  users: User[];
  currentEditId?: number;
  currentUserName?: string;
  currentUserId?: number;
  token?: string;
}
