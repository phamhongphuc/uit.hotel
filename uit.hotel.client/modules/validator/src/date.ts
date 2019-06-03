import moment, { Moment } from 'moment';
import { RuleDecl } from 'vue/types/options';

export function validDate(value: string) {
    return moment(value, 'YYYY-MM-DD').isValid();
}

export const beforeDate = (date?: Moment) => (value: string) =>
    moment(value, 'YYYY-MM-DD').isBefore(date || moment());

export const birthdate: RuleDecl = {
    validDate,
    beforeDate: beforeDate(moment().subtract('year', 5)),
};

export const startingDate: RuleDecl = {
    validDate,
    beforeDate: beforeDate(),
};
