import {
    email,
    minLength,
    not,
    numeric,
    or,
    required,
} from 'vuelidate/lib/validators';

export const optionalEmail = {
    or: or(email, not(required)),
};

export const listOfPhoneNumbers = {
    minLength: minLength(0),
    $each: {
        required,
        numeric,
    },
};
