import moment from 'moment';

export const toMoney = (num: number) =>
    num.toLocaleString('vi', {
        style: 'currency',
        currency: 'VND',
    });

export const toDate = (date: string) => {
    const current = moment();
    const time = moment(date);
    if (current.year() === time.year()) return time.format('HH:mm - DD/MM');
    else if (time.year() === 1) return 'N/A';
    return time.format('HH:mm - DD/MM/YYYY');
};

export const toInputDate = (date: string | Date) =>
    moment(date).format('YYYY-MM-DD');

export const toYear = (date: string) => {
    const year = moment(date).year();
    return year === 1 ? 'N/A' : year;
};
