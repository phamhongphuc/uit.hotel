import { Prop } from 'nuxt-property-decorator';
import Vue from 'vue';
import { Mixin } from 'vue-mixin-decorator';

@Mixin
export class ContextMixin extends Vue {
    @Prop({ default: undefined })
    refs: any;

    data: any = null;

    open(event: MouseEvent, data: any): void {
        const context: any = this.$refs.context;
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
