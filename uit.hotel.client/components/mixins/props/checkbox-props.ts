import { Vue, Prop, Component } from 'nuxt-property-decorator';

// Convert from https://github.com/bootstrap-vue/bootstrap-vue/blob/dev/src/components/form-checkbox/form-checkbox-group.js
@Component
export class CheckboxProps extends Vue {
    @Prop({ default: null })
    protected value: any;

    @Prop({ default: null })
    protected checked!: [string, number, Record<string, any>, any[], boolean];

    @Prop({ default: false })
    protected validated!: boolean;

    @Prop({ default: false })
    protected ariaInvalid!: [boolean, string];

    @Prop({ default: false })
    protected stacked!: boolean;

    // Render as button style
    @Prop({ default: false })
    protected buttons!: boolean;

    // Convert from bootstrap-vue/es/mixins/form-options.js
    // Only applicable when rendered with button style
    @Prop({ default: 'secondary' })
    protected buttonVariant!: string;

    @Prop({ default: (): [] => [] })
    protected options!: {
        text: string;
        value: string;
    }[];

    @Prop({ default: 'value' })
    protected valueField!: string;

    @Prop({ default: 'text' })
    protected textField!: string;

    @Prop({ default: 'disabled' })
    protected disabledField!: string;
}
