import { required, not } from 'vuelidate/lib/validators';
import moment, { Moment } from 'moment';
import { RuleDecl } from 'vue/types/options';

export function validDate(value: string) {
    return moment(value, 'YYYY-MM-DD').isValid();
}

export const beforeDate = (date?: Moment) => (value: string) =>
    moment(value, 'YYYY-MM-DD').isBefore(date || moment());

export const beforeDateTime = (date?: Moment) => (value: string) =>
    moment(value).isBefore(date || moment());

export const birthdate: RuleDecl = {
    validDate,
    beforeDate: beforeDate(),
};

interface HasBirthdate {
    input: { birthdate: string };
}

export const startingDate: RuleDecl = {
    validDate,
    notBefore(value: string) {
        const { input } = (this as any) as HasBirthdate;
        if (!input) return false;
        return !beforeDate(moment(input.birthdate))(value);
    },
};

export const bookCheckInTime: RuleDecl = {
    required,
    validDate,
    beforeDateTime: not(beforeDateTime()),
};

interface HasBookCheckInTime {
    bookCheckInTime: string;
}

export const bookCheckOutTime = {
    required,
    validDate,
    beforeDateTime(value: string) {
        const { bookCheckInTime } = (this as any) as HasBookCheckInTime;
        if (!bookCheckInTime) return false;
        return !beforeDateTime(moment(bookCheckInTime))(value);
    },
};
