import Vue from 'vue';
import { StoreSelf } from '~/utils/store';

export default function({ app }: StoreSelf): void {
    if (!app.mixins) app.mixins = [];
    app.mixins.push({
        async mounted() {
            // Breakpoint
            const updateBreakpoint = (): void => {
                (this as Vue).$store.dispatch('style/updateBreakpoint');
            };
            window.addEventListener('resize', updateBreakpoint);
            updateBreakpoint();

            // Route
            await Vue.nextTick();
            await (this as Vue).$store.dispatch('user/checkLogin');
        },
    });
}
