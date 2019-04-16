import { Prop } from 'nuxt-property-decorator';
import Vue from 'vue';
import { Mixin } from 'vue-mixin-decorator';

// Copy and modify from bootstrap-vue/es/components/button/button.js
@Mixin
export class ButtonProps extends Vue {
    @Prop({ default: false })
    block: boolean = false;

    @Prop({ default: false })
    disabled: boolean = false;

    @Prop({ default: null })
    size!: string;

    @Prop({ default: null })
    variant!: string;

    @Prop({ default: 'button' })
    type!: string;

    @Prop({ default: null })
    pressed: boolean = false;
}
