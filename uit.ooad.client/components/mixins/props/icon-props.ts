import { Prop } from 'nuxt-property-decorator';
import Vue from 'vue';
import { Mixin } from 'vue-mixin-decorator';

@Mixin
export class IconProps extends Vue {
    @Prop({ default: null, validator: icon => icon.length === 1 })
    icon: string;
}
