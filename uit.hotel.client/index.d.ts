import Vue, { ComponentOptions } from 'vue';
import VueRouter from 'vue-router';
import { ApolloHelpers } from '~/interfaces/ApolloHelpers';
import { ApolloProvider } from '~/interfaces/ApolloProvider';

declare module 'vuex' {
    interface Store<S> {
        app: ComponentOptions<Vue>;
        $router: VueRouter;
    }
}

declare module 'vue/types/vue' {
    interface Vue {
        $apolloHelpers: ApolloHelpers;
        $apolloProvider: ApolloProvider;
        apolloProvider: ApolloProvider;
    }
}

declare module 'vuelidate/lib/validators' {
    type ValidationRuleFunction = () => ValidationRule;

    export function or(
        ...validators: (ValidationRuleFunction | ValidationRule | CustomRule)[]
    ): ValidationRule;
    export function and(
        ...validators: (ValidationRuleFunction | ValidationRule | CustomRule)[]
    ): ValidationRule;
    export function not(
        validator: ValidationRuleFunction | ValidationRule | CustomRule,
    ): ValidationRule;
}

declare global {
    interface Window {
        onNuxtReady: (callback: () => void) => void;
    }
}
