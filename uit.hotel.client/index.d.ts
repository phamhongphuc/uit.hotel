import Vue, { ComponentOptions } from 'vue';
import VueRouter from 'vue-router';

declare module 'vuex' {
    interface Store<S> {
        app: ComponentOptions<Vue> & {
            router: VueRouter;
        };
        $router: VueRouter;
    }
}

declare module '*.vue' {
    export default Vue;
}
