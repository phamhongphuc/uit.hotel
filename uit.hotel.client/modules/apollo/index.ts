import { InMemoryCache } from 'apollo-cache-inmemory';
import { ApolloClient, ApolloError, MutationOptions } from 'apollo-client';
import { FetchResult } from 'apollo-link';
import Vue from 'vue';
import { MutationTree, Store } from 'vuex';
import { notify } from '~/plugins/notify';
import { ApolloNotify } from './interfaces/ApolloNotify';
import { ServerError } from './interfaces/ServerError';

type HasAppType = { app: Vue };
type AppContextType = MutationTree<any> | Store<any> | HasAppType;

const hasApp = (context: object | HasAppType): context is HasAppType =>
    'app' in context;

// store/user (mutation login / logout)
export function apolloHelpers(context: AppContextType) {
    if (!hasApp(context))
        throw new Error('Phải truyền vào một thể hiện của Store');
    return context.app.$apolloHelpers;
}

// store/user
export function apolloClient(
    context: AppContextType,
): ApolloClient<InMemoryCache> {
    if (!hasApp(context))
        throw new Error('Phải truyền vào một thể hiện của Store');
    const provider = context.app.$apolloProvider || context.app.apolloProvider;
    if (!provider) throw new Error('Không thể tìm thấy apolloProvider');
    return provider.defaultClient;
}

// mixin/mutable và store/user
export function apolloClientNotify(context: AppContextType): ApolloNotify {
    const client = apolloClient(context);
    return {
        async mutate<TType, TVariables>(
            options: MutationOptions<TType, TVariables>,
        ): Promise<
            FetchResult<TType, Record<string, any>, Record<string, any>>
        > {
            try {
                return await client.mutate<TType, TVariables>(options);
            } catch (error) {
                if (
                    error instanceof ApolloError &&
                    error.networkError !== null &&
                    (error.networkError as ServerError).result !== undefined
                ) {
                    notify.error({
                        title: 'Lỗi',
                        text: (error.networkError as ServerError).result[0]
                            .InnerException.Message,
                    });
                } else {
                    notify.error({
                        title: 'Lỗi không xác định',
                        type: 'error',
                        text: error.message,
                    });
                }

                // eslint-disable-next-line no-console
                console.warn(error);
                return {};
            }
        },
    };
}
