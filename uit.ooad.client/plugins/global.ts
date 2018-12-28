import Vue, { ComponentOptions } from 'vue';

export default function({ app }: { app: ComponentOptions<Vue> }): void {
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
            (this as Vue).$store.watch(
                state => state.user.token,
                async () => {
                    const isLogin = await (this as Vue).$store.dispatch(
                        'user/checkLogin',
                    );
                    if (!isLogin) (this as Vue).$router.push('/login');
                    else if ((this as Vue).$route.name === 'login') {
                        (this as Vue).$router.push('/');
                    }
                },
            );
        },
    });
}
