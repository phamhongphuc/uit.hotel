import { Prop } from 'nuxt-property-decorator';
import { Mixin } from 'vue-mixin-decorator';
import Vue from 'vue';

@Mixin
export class IconProps extends Vue {
    @Prop({ default: null })
    protected icon!: string;
}
