import { Prop } from 'nuxt-property-decorator';
import Vue from 'vue';
import { Mixin } from 'vue-mixin-decorator';

// Copy and convert from bootstrap-vue/es/components/link/link.js
@Mixin
export class LinkProps extends Vue {
    @Prop({ default: null })
    href: string;

    @Prop({ default: null })
    rel: string;

    @Prop({ default: '_self' })
    target: string;

    @Prop({ default: false })
    active: boolean;

    @Prop({ default: 'active' })
    activeClass: string;

    @Prop({ default: false })
    append: boolean;

    @Prop({ default: false })
    disabled: boolean;

    @Prop({ default: 'click' })
    event: [string, any[]];

    @Prop({ default: false })
    exact: boolean;

    @Prop({ default: 'active' })
    exactActiveClass: string;

    @Prop({ default: false })
    replace: boolean;

    @Prop({ default: 'a' })
    routerTag: string;

    @Prop({ default: null })
    to: [string, Record<string, any>];
}

// Copy and modify from bootstrap-vue/es/components/button/button.js
@Mixin
export class ButtonProps extends Vue {
    @Prop({ default: false })
    block: boolean;

    @Prop({ default: false })
    disabled: boolean;

    @Prop({ default: null })
    size: string;

    @Prop({ default: null })
    variant: string;

    @Prop({ default: 'button' })
    type: string;

    @Prop({ default: null })
    pressed: boolean;
}

@Mixin
export class IconProps extends Vue {
    @Prop({ default: null, validator: icon => icon.length === 1 })
    icon: string;
}

// Valid supported input types
var TYPES = [
    'text',
    'password',
    'email',
    'number',
    'url',
    'tel',
    'search',
    'range',
    'color',
    'date',
    'time',
    'datetime',
    'datetime-local',
    'month',
    'week',
];

@Mixin
export class InputProps extends Vue {
    @Prop({ default: null })
    value: any;

    @Prop({
        default: 'text',
        validator(type) {
            return TYPES.indexOf(type) !== -1;
        },
    })
    type: string;

    @Prop({ default: false })
    ariaInvalid: [boolean, string];

    @Prop({ default: false })
    readonly: boolean;

    @Prop({ default: false })
    plaintext: boolean;

    @Prop({ default: null })
    autocomplete: string;

    @Prop({ default: null })
    placeholder: string;

    @Prop()
    formatter: Function;

    @Prop({ default: false })
    lazyFormatter: boolean;
}

@Mixin
export class StateProps extends Vue {
    @Prop({ default: null })
    state: [boolean, string];
}

@Mixin
export class TextProps extends Vue {
    @Prop({ default: '' })
    textClass: string;

    @Prop({ default: '' })
    text: string;
}

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
