import { Prop } from 'nuxt-property-decorator';
import Vue from 'vue';
import { Mixin } from 'vue-mixin-decorator';

// Convert from bootstrap-vue/es/components/form-checkbox/form-checkbox-group.js

@Mixin
export class CheckboxProps extends Vue {
    @Prop({ default: null })
    value: any;

    @Prop({ default: null })
    checked: [string, number, Record<string, any>, any[], boolean];

    @Prop({ default: false })
    validated: boolean;

    @Prop({ default: false })
    ariaInvalid: [boolean, string];

    @Prop({ default: false })
    stacked: boolean;

    // Render as button style
    @Prop({ default: false })
    buttons: boolean;

    // Convert from bootstrap-vue/es/mixins/form-options.js
    // Only applicable when rendered with button style
    @Prop({ default: 'secondary' })
    buttonVariant: string;

    @Prop({ default: () => [] })
    options: { text: string; value: string }[];

    @Prop({ default: 'value' })
    valueField: string;

    @Prop({ default: 'text' })
    textField: string;

    @Prop({ default: 'disabled' })
    disabledField: string;
}
