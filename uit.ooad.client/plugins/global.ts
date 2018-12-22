import Vue, { ComponentOptions } from 'vue';

export default function({ app }: { app: ComponentOptions<Vue> }): void {
    if (!app.mixins) app.mixins = [];
    app.mixins.push({
        mounted(): void {
            const updateBreakpoint = (): void => {
                this.$store.dispatch('style/updateBreakpoint');
            };
            updateBreakpoint();
            window.addEventListener('resize', updateBreakpoint);
        },
    });
}
