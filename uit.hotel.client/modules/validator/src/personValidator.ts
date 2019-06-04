import {
    maxLength,
    minLength,
    numeric,
    required,
} from 'vuelidate/lib/validators';

export const gender = { required };

export const name = { required, minLength: minLength(3) };

export const identification = {
    required,
    numeric,
    maxLength: maxLength(9),
    minLength: minLength(9),
};
