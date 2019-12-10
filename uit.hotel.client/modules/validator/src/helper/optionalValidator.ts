import { Validation } from 'vuelidate';

export function optional(validation: Validation) {
    const model = validation.$model;

    if (
        model === '' ||
        model === null ||
        model === undefined ||
        (Array.isArray(model) &&
            (model.length === 0 || (model.length === 1 && model[0] === '')))
    )
        return null;

    return !validation.$invalid;
}
