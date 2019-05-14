import { Prop } from 'nuxt-property-decorator';
import { Mixin } from 'vue-mixin-decorator';
import Vue from 'vue';

// Copy and modify from bootstrap-vue/es/components/button/button.js
@Mixin
export class ButtonProps extends Vue {
    @Prop({ default: false })
    protected block: boolean = false;

    @Prop({ default: false })
    protected disabled: boolean = false;

    @Prop({ default: null })
    protected size!: string;

    @Prop({ default: null })
    protected variant!: string;

    @Prop({ default: 'button' })
    protected type!: string;

    @Prop({ default: null })
    protected pressed: boolean = false;
}
