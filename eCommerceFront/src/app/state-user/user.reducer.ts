import { createReducer, on } from "@ngrx/store";
import { User } from "../user/user";
import { getLoggedUser } from "./user.action";

export interface State{
    user: User | null
}

export const initialState: State = {
    user: null
};

export const userReducer = createReducer(
    initialState,
    on(getLoggedUser, (state, { loggedUser }) => {          
        return {
            ...state,
            user: loggedUser
        } 
    })
);