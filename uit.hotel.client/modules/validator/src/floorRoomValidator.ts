import { minLength, required, between } from 'vuelidate/lib/validators';

export const floorRoomName = {
    required,
    minLength: minLength(1),
};

export const numberOfBeds = {
    required,
    between: between(1, 5),
};

export const amountOfPeople = {
    required,
    between: between(1, 10),
};

export const roomKindName = {
    required,
    minLength: minLength(3),
};
