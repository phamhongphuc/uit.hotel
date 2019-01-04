import Vue from 'vue';
import { Mixin } from 'vue-mixin-decorator';

@Mixin
export class PopupMixin extends Vue {
    data: any = null;

    async open(data: any): Promise<void> {
        const popup: any = this.$refs.popup;
        if (popup !== undefined && typeof popup.open === 'function') {
            this.data = data;
            popup.open(data);
            if (typeof (this as any).onOpen === 'function') {
                (this as any).onOpen();
            }
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