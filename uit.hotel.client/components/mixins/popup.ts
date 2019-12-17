import { Component, Vue, mixins } from 'nuxt-property-decorator';
import { InjectRefs } from './refs';
import { TableContext } from './table';

@Component
export class PopupMixin<TData, TInput> extends mixins<InjectRefs, TableContext>(
    InjectRefs,
    TableContext,
) {
    protected data!: TData;
    protected input: TInput | null = null;

    protected onOpen(): void | Promise<void> {}

    public async open(data: TData): Promise<void> {
        const popup = this.$refs.popup as Vue & PopupMixin<TData, TInput>;

        if (popup === undefined || typeof popup.open !== 'function') {
            throw new Error(
                'Không tìm thấy ref=`popup` hoặc hàm `popup.open` trong component',
            );
        }

        this.data = data;
        popup.open(data);

        await this.onOpen();
        await Vue.nextTick();

        const autoFocus = this.$refs.autoFocus as Vue;

        if (autoFocus !== undefined && autoFocus.$refs.input !== undefined) {
            const input = (autoFocus.$refs.input as Vue).$el as HTMLElement;

            if (typeof input.focus === 'function') input.focus();
        }
    }

    protected close() {
        const popup = this.$children[0] as Vue & {
            close: () => void;
        };
        if (typeof popup.close === 'function') popup.close();
    }
}
