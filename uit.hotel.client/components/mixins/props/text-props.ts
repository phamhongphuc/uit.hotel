import { Vue, Prop } from 'nuxt-property-decorator';
import { Mixin } from 'vue-mixin-decorator';

@Mixin
export class TextProps extends Vue {
    @Prop({ default: '' })
    protected textClass!: string;

    @Prop({ default: '' })
    protected text!: string;
}
