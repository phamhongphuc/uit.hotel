import { Vue, Prop } from 'nuxt-property-decorator';
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
    protected value: any;

    @Prop({
        default: 'text',
        validator(type): boolean {
            return TYPES.indexOf(type) !== -1;
        },
    })
    protected type!: string;

    @Prop({ default: false })
    protected ariaInvalid!: [boolean, string];

    @Prop({ default: false })
    protected readonly!: boolean;

    @Prop({ default: false })
    protected plaintext!: boolean;

    @Prop({ default: null })
    protected autocomplete!: string;

    @Prop({ default: null })
    protected placeholder!: string;

    @Prop()
    protected formatter!: Function;

    @Prop({ default: false })
    protected lazyFormatter!: boolean;

    @Prop({ default: false })
    protected disabled!: boolean;
}
