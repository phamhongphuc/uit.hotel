import moment, { Moment } from 'moment';

export const toMoney = (num = 0, skipPrefix = false) => {
    return (
        (num < 0 && !skipPrefix ? 'Hoàn tiền ' : '') +
        (skipPrefix ? num : Math.abs(num)).toLocaleString('vi', {
            style: 'currency',
            currency: 'VND',
        })
    );
};

const dateTimeFormatter = (date: string | number | Moment, hasTime = false) => {
    const time = moment(date);
    if (time.year() === 1) return 'N/A';

    const timeSuffixFormat = hasTime ? ' HH:mm' : '';
    const yearFormat = moment().year() === time.year() ? '' : '/YYYY';
    return time.format(`DD/MM${yearFormat}${timeSuffixFormat}`);
};

export const toDateTime = (date: string | number | Moment) =>
    dateTimeFormatter(date, true);

export const toDate = (date: string | number | Moment) =>
    dateTimeFormatter(date, false);

export const toHour = (time: Moment) => time.format('HH:mm');

export const toInputDate = (date: string | Date) =>
    moment(date).format('YYYY-MM-DD');

export const toYear = (date: string) => {
    const year = moment(date).year();

    return year === 1 ? 'N/A' : year;
};

export const toPercent = (num: number) =>
    `${parseFloat((num * 100).toFixed(2))}%`;

export const toNumber = (num: string | number) =>
    typeof num !== 'string' ? num : parseFloat(num);

export const dash = (value: string | number | any) =>
    value === null || value === undefined || value === '' ? '-' : value;
