import { required, integer, minValue } from 'vuelidate/lib/validators';

export const price = {
    required,
    integer,
    minValue: minValue(0),
};
