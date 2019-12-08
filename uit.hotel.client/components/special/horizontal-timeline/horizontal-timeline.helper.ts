import moment, { Moment } from 'moment';

export const getMiddleOfDay = (time: Moment) =>
    time.clone().set({ hour: 12, minute: 0, second: 0, millisecond: 0 });

export const getHours = (time: Moment) =>
    moment
        .duration(
            -time
                .clone()
                .startOf('days')
                .diff(time),
        )
        .asHours();

export const getBounding = (time: string | Date, isMin: boolean) => {
    return getMiddleOfDay(moment(time)).add(
        (getHours(moment(time)) < 12 ? -2 : -1) + (isMin ? 0 : 3),
        'day',
    );
};
