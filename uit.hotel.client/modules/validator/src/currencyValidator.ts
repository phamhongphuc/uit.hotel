import { RuleDecl } from 'vue/types/options';
import { required, integer, minValue } from 'vuelidate/lib/validators';
import { toNumber } from '~/utils';

export const currency: RuleDecl = {
    required,
    integer,
    divisibleByThousand: (input: number | string) =>
        toNumber(input) % 1000 === 0,
};

export const price: RuleDecl = {
    ...currency,
    minValue: minValue(0),
};
