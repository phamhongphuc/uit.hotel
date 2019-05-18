import { Vue, Prop, Component } from 'nuxt-property-decorator';

// Copy and modify from https://github.com/bootstrap-vue/bootstrap-vue/blob/dev/src/components/button/button.js
@Component
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
