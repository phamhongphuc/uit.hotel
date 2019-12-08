import moment from 'moment';

const minValue = '0001-01-01T00:00:00+00:00';

export const getDate = (real: string | Date, book: string | Date) => {
    return moment(real === minValue ? book : real);
};
