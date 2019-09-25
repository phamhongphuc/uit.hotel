import { Vue, Prop, Component } from 'nuxt-property-decorator';

@Component
export class ContextMixin extends Vue {
    @Prop({ default: undefined })
    protected refs!: { [key: string]: Vue | Element | Vue[] | Element[] };

    protected data: any = null;

    protected open(event: MouseEvent, data: any): void {
        const context = this.$refs.context as Vue & ContextMixin;
        if (context !== undefined && typeof context.open === 'function') {
            this.data = data;
            context.open(event, data);
            if (typeof (this as any).onOpen === 'function') {
                (this as any).onOpen();
            }
            return;
        }
        throw new Error(
            'Không tìm thấy ref=`context` hoặc hàm `context.open` trong component',
        );
    }
}
