import {
    required,
    sameAs,
    minLength,
    alphaNum,
} from 'vuelidate/lib/validators';

export const id = {
    required,
    minLength: minLength(3),
};

export const rePassword = {
    required,
    sameAs: sameAs(
        (self: { input: { password: string } }) => self.input.password,
    ),
};

export const password = {
    required,
    minLength: minLength(3),
};

export const phoneNumber = {
    required,
    alphaNum,
};

export const address = {
    required,
    minLength: minLength(10),
};
