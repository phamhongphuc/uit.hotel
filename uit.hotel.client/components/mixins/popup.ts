import { Vue, Prop, Component } from 'nuxt-property-decorator';

@Component
export class PopupMixin<TData, TInput> extends Vue {
    @Prop({ default: undefined })
    protected refs: any;

    protected data!: TData;
    protected input: TInput | null = null;

    protected onOpen(): void | Promise<void> {}

    protected async open(data: TData): Promise<void> {
        const popup = this.$refs.popup as Vue & PopupMixin<TData, TInput>;
        if (popup !== undefined && typeof popup.open === 'function') {
            this.data = data;
            popup.open(data);

            await this.onOpen();
            await Vue.nextTick();

            const autoFocus = this.$refs.autoFocus as Vue;
            if (
                autoFocus !== undefined &&
                autoFocus.$refs.input !== undefined
            ) {
                const input = (autoFocus.$refs.input as any).$el as HTMLElement;
                if (typeof input.focus === 'function') input.focus();
            }
            return;
        }
        throw new Error(
            'Không tìm thấy ref=`popup` hoặc hàm `popup.open` trong component',
        );
    }
}
