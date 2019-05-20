import { InMemoryCache } from 'apollo-cache-inmemory';
import { ApolloClient, ApolloError, MutationOptions } from 'apollo-client';
import { FetchResult } from 'apollo-link';
import { notify } from '~/plugins/notify';
import { ApolloHelpers } from '../../interfaces/ApolloHelpers';
import { ApolloNotify } from './interfaces/ApolloNotify';
import { ServerError } from './interfaces/ServerError';

export function apolloClient(store: any): ApolloClient<InMemoryCache> {
    if (store.app.apolloProvider) return store.app.apolloProvider.defaultClient;
    else if (store.app.$apolloProvider)
        return store.app.$apolloProvider.defaultClient;
    throw new Error('Không thể tìm thấy apolloProvider hoặc $apolloProvider');
}

export function apolloHelpers(store: any): ApolloHelpers {
    return store.app.$apolloHelpers;
}

export function apolloClientNotify(store: any): ApolloNotify {
    const client = apolloClient(store);
    return {
        async mutate<TType, TVariables>(
            options: MutationOptions<TType, TVariables>,
        ): Promise<
            FetchResult<TType, Record<string, any>, Record<string, any>>
        > {
            try {
                const result = await client.mutate<TType, TVariables>(options);
                return result;
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
