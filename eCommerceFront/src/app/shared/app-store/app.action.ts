import { createAction, props } from "@ngrx/store";
import { Appstate } from "./appstate";

export const setAPIStatus = createAction(
    '[API] success or failed status',
    props<{apiStatus: Appstate}>()
)