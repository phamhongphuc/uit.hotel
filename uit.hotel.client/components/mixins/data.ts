import { Vue } from 'nuxt-property-decorator';

export function DataMixin<TData = { [key: string]: any }>(data: TData) {
    return Vue.extend({
        data() {
            return data;
        },
    });
}
