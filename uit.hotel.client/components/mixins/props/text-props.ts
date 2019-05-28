import { Vue, Prop, Component } from 'nuxt-property-decorator';

@Component
export class TextProps extends Vue {
    @Prop({ default: '' })
    protected textClass!: string;

    @Prop({ default: '' })
    protected text!: string;
}
