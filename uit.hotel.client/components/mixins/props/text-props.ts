import { Prop } from 'nuxt-property-decorator';
import { Mixin } from 'vue-mixin-decorator';
import Vue from 'vue';

@Mixin
export class TextProps extends Vue {
    @Prop({ default: '' })
    protected textClass!: string;

    @Prop({ default: '' })
    protected text!: string;
}
