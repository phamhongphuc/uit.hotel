import { Prop } from 'nuxt-property-decorator';
import Vue from 'vue';
import { Mixin } from 'vue-mixin-decorator';

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
