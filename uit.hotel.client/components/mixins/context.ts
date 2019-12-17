import { Component, mixins, Vue } from 'nuxt-property-decorator';
import { InjectRefs } from './refs';

@Component
export class ContextMixin extends mixins<InjectRefs>(InjectRefs) {
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

    protected close(event: MouseEvent) {
        const context = this.$children[0] as Vue & {
            close: (emit: boolean | Event) => void;
        };
        if (typeof context.close === 'function') context.close(event);
    }
}
