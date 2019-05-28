import { Vue, Prop, Component } from 'nuxt-property-decorator';

// Copy and convert from https://github.com/bootstrap-vue/bootstrap-vue/blob/dev/src/components/link/link.js
@Component
export class LinkProps extends Vue {
    @Prop({ default: null })
    protected href!: string;

    @Prop({ default: null })
    protected rel!: string;

    @Prop({ default: '_self' })
    protected target!: string;

    @Prop({ default: false })
    protected active!: boolean;

    @Prop({ default: 'active' })
    protected activeClass!: string;

    @Prop({ default: false })
    protected append!: boolean;

    @Prop({ default: false })
    protected disabled!: boolean;

    @Prop({ default: 'click' })
    protected event!: [string, any[]];

    @Prop({ default: false })
    protected exact!: boolean;

    @Prop({ default: 'active' })
    protected exactActiveClass!: string;

    @Prop({ default: false })
    protected replace!: boolean;

    @Prop({ default: 'a' })
    protected routerTag!: string;

    @Prop({ default: null })
    protected to!: [string, Record<string, any>];
}
