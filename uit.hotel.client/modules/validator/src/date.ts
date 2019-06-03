import moment from 'moment';

export function validDate(value: string) {
    return moment(value, 'YYYY-MM-DD').isValid();
}

export const birthdate = {
    validDate,
    maxToday: (value: string) => moment(value, 'YYYY-MM-DD').isBefore(moment()),
};
