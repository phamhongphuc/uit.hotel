import { required, integer, minValue } from 'vuelidate/lib/validators';

export const rate = {
    required,
    integer,
    minValue: minValue(0),
};
