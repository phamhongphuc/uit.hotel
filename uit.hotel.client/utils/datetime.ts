import moment, { Moment } from 'moment';

const minValue = '0001-01-01T00:00:00+00:00';

export const isMinDate = (date: string | Date) => date === minValue;

export const getDate = (real: string | Date, book: string | Date) =>
    moment(isMinDate(real) ? book : real);

export const fromNow = (
    date: string | Date | Moment,
    withoutSuffix?: boolean,
) => moment(date).fromNow(withoutSuffix);
