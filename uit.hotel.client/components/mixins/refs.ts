/* eslint-disable max-classes-per-file */
import { Vue, Component, Provide, Inject } from 'nuxt-property-decorator';

@Component
export class ProvideRefs extends Vue {
    @Provide()
    get refs() {
        return this.$refs;
    }
}

@Component
export class InjectRefs extends Vue {
    @Inject() refs!: { [key: string]: Vue | Element | Vue[] | Element[] };
}
