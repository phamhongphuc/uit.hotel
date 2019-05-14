import { Prop } from 'nuxt-property-decorator';
import { Mixin } from 'vue-mixin-decorator';
import Vue from 'vue';

@Mixin
export class StateProps extends Vue {
    @Prop({ default: null })
    protected state!: [boolean, string];
}
