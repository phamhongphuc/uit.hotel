import { StyleState } from './style';
import { UserState } from './user';

export interface RootState {
    style: StyleState;
    user: UserState;
}
