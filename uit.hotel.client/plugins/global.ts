import Vue from 'vue';
import { Context } from '@nuxt/types';
import moment from 'moment';

moment.locale('vi');

export default function({ app }: Context): void {
    if (!app.mixins) app.mixins = [];

    app.mixins.push({
        async mounted(): Promise<void> {
            // Breakpoint
            const updateBreakpoint = (): void => {
                (this as Vue).$store.dispatch('style/updateBreakpoint');
            };

            window.addEventListener('resize', updateBreakpoint);
            updateBreakpoint();
        },
    });
}
