import { Vue, Prop, Component } from 'nuxt-property-decorator';

// Valid supported input types
const InputPropsType = [
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

@Component
export class InputProps extends Vue {
    @Prop({ default: null })
    protected value: any;

    @Prop({
        default: 'text',
        validator(type): boolean {
            return InputPropsType.indexOf(type) !== -1;
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
