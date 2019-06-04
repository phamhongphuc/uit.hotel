import { Vue } from 'nuxt-property-decorator';
import { required } from 'vuelidate/lib/validators';

export const included = (ref: string) => ({
    id: {
        required,
        included(value: number) {
            const element = ((this as any) as Vue).$refs[ref] as (Vue & {
                options: {
                    id: number;
                }[];
            });
            const condition =
                element === undefined ||
                !('options' in element) ||
                !Array.isArray(element.options);
            if (condition) return false;
            return element.options.some(option => option.id === value);
        },
    },
});
