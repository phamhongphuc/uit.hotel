import moment, { Moment } from 'moment';

export const toMoney = (num = 0) =>
    num.toLocaleString('vi', {
        style: 'currency',
        currency: 'VND',
    });

export const toDate = (date: string | number) => {
    const current = moment();
    const time = moment(date);
    if (current.year() === time.year()) return time.format('DD/MM HH:mm');
    if (time.year() === 1) return 'N/A';
    return time.format('DD/MM/YYYY HH:mm');
};

export const toHour = (time: Moment) => time.format('HH:mm');

export const toInputDate = (date: string | Date) =>
    moment(date).format('YYYY-MM-DD');

export const toYear = (date: string) => {
    const year = moment(date).year();
    return year === 1 ? 'N/A' : year;
};
