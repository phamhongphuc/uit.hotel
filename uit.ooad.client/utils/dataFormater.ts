export const toMoney = (num: number): string =>
    num.toLocaleString('vi', {
        style: 'currency',
        currency: 'VND',
    });
