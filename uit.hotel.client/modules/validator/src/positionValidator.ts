import { required, minLength } from 'vuelidate/lib/validators';

export const positionName = {
    required,
    minLength: minLength(3),
};
