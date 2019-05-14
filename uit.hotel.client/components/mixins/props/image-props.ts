import { Vue, Prop } from 'nuxt-property-decorator';
import { Mixin } from 'vue-mixin-decorator';

@Mixin
export class ImageProps extends Vue {
    @Prop({ default: '' })
    protected image!: string;

    @Prop({ default: 0 })
    protected imageWidth!: number;

    @Prop({ default: 0 })
    protected imageHeight!: number;

    @Prop({ default: '' })
    protected imageClass!: string;

    @Prop({ default: false })
    protected circle!: boolean;
}
