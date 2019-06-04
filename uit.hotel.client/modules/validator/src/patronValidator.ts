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

export const patronKindName = {
    required,
    minLength: minLength(3),
};

export const patronKindDescription = {
    required,
    minLength: minLength(3),
};
