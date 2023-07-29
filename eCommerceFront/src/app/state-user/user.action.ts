import { createAction, props } from "@ngrx/store";
import { User } from "../user/user";

export const invokeLoggedUserAPI = createAction(
    "[User] invoke logged user API",
);

export const getLoggedUser = createAction(
      "[User] get logged user success",
      props<{ loggedUser : User}>(),
);
