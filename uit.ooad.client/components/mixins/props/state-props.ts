import { Prop } from 'nuxt-property-decorator';
import Vue from 'vue';
import { Mixin } from 'vue-mixin-decorator';

@Mixin
export class StateProps extends Vue {
    @Prop({ default: null })
    state: [boolean, string];
}
