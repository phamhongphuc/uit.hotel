import moment, { Moment } from 'moment';

const minValue = '0001-01-01T00:00:00+00:00';

export const isMinDate = (date: string | Date) => date === minValue;

export const getDate = (real: string | Date, book: string | Date) =>
    moment(isMinDate(real) ? book : real);

export const fromNow = (
    date: string | Date | Moment,
    withoutSuffix?: boolean,
) => moment(date).fromNow(withoutSuffix);

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
