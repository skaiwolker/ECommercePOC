import { createFeatureSelector } from "@ngrx/store";
import { User } from "../user/user";

export const selectLoggedUser = createFeatureSelector<User>('loggedUser');