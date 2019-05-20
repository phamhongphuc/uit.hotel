import Vue, { ComponentOptions } from 'vue';
import VueRouter from 'vue-router';
import { ApolloHelpers } from '~/interfaces/ApolloHelpers';
import { ApolloProvider } from '~/interfaces/ApolloProvider';

declare module 'vuex' {
    interface Store<S> {
        app: ComponentOptions<Vue> & {
            router: VueRouter;
            $apolloHelpers: ApolloHelpers;
            $apolloProvider: ApolloProvider;
            apolloProvider: ApolloProvider;
        };
        $router: VueRouter;
    }
}

declare module '*.vue' {
    export default Vue;
}

declare global {
    interface Window {
        onNuxtReady: (callback: () => void) => void;
    }
}
