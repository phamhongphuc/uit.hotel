import { Vue, Prop } from 'nuxt-property-decorator';
import { Mixin } from 'vue-mixin-decorator';

@Mixin
export class StateProps extends Vue {
    @Prop({ default: null })
    protected state!: [boolean, string];
}
