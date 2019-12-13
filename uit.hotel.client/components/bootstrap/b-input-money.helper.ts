export function unformat(input: string, precision: number) {
    const negative = input.indexOf('-') >= 0 ? -1 : 1;
    const numbers = input.replace(/\D+/g, '') || '0';
    return (parseFloat(numbers) / 10 ** precision) * negative;
}
