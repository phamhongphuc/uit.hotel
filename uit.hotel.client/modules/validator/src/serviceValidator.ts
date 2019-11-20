import { minValue, required, minLength } from 'vuelidate/lib/validators';

export const serviceName = {
    required,
    minLength: minLength(1),
};
export const unitPrice = {
    required,
    minLength: minValue(1000),
};
export const unit = { required };
