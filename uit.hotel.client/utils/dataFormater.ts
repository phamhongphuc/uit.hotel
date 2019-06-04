import moment from 'moment';

export const toMoney = (num: number) =>
    num.toLocaleString('vi', {
        style: 'currency',
        currency: 'VND',
    });

export const toDate = (date: string) => {
    const current = moment();
    const time = moment(date);
    if (current.year() === time.year())
        return moment(date).format('HH:mm A DD/MM');
    else return moment(date).format('HH:mm A DD/MM/YYYY');
};

export const toInputDate = (date: string | Date) =>
    moment(date).format('YYYY-MM-DD');
