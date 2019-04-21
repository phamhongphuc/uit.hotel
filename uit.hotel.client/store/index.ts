import { StyleState } from './style';
import { UserState } from './user';
import { ViewState } from './view';

export interface RootState {
    style: StyleState;
    user: UserState;
    view: ViewState;
}
