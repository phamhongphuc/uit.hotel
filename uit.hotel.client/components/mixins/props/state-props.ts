import { Vue, Prop, Component } from 'nuxt-property-decorator';

@Component
export class StateProps extends Vue {
    @Prop({ default: null })
    protected state!: [boolean, string];
}
