import { Prop } from 'nuxt-property-decorator';
import Vue from 'vue';
import { Mixin } from 'vue-mixin-decorator';

@Mixin
export class ImageProps extends Vue {
    @Prop({ default: '' })
    image: string;

    @Prop({ default: 0 })
    imageWidth: number;

    @Prop({ default: 0 })
    imageHeight: number;

    @Prop({ default: '' })
    imageClass: string;

    @Prop({ default: false })
    circle: boolean;
}
