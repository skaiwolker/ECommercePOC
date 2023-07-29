import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { map, switchMap } from "rxjs";
import { UserService } from "../user/user.service";
import { getLoggedUser, invokeLoggedUserAPI } from "./user.action";

@Injectable()
export class UserEffects{
    constructor(private actions$: Actions, private userService: UserService) { }

    loadLoggedUserInfos$ = createEffect(() =>
        this.actions$.pipe(
            ofType(invokeLoggedUserAPI),
            switchMap(() => {
                return this.userService.getLoggedUser().pipe(map((data) => getLoggedUser({ loggedUser: data })))
            })
        )
    )
}