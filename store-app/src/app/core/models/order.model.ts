import { User } from "./user.model";

export interface Order {
  id: number;
  total: number;
  createdAt: Date;
  user : User;
}