import moment from 'moment';
import { getHours, getMiddleOfDay } from '~/utils';

export const getBounding = (time: string | Date, isMin: boolean) =>
    getMiddleOfDay(moment(time)).add(
        (getHours(moment(time)) < 12 ? -2 : -1) + (isMin ? 0 : 3),
        'day',
    );
