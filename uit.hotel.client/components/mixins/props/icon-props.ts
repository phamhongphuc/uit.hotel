import { Vue, Prop, Component } from 'nuxt-property-decorator';

@Component
export class IconProps extends Vue {
    @Prop({ default: null })
    protected icon!: string;
}
