import { notify } from '~/plugins/notify';
import { InMemoryCache } from 'apollo-cache-inmemory';
import { ApolloClient, ApolloError, MutationOptions } from 'apollo-client';
import { FetchResult } from 'apollo-link';

declare module 'vue/types/vue' {
    interface Vue {
        $apolloHelpers: ApolloHelpers;
        $apolloProvider: {
            defaultClient: ApolloClient<InMemoryCache>;
        };
    }
}

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
        ) {
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

interface ServerError extends Error {
    result: {
        ClassName: string;
        Message: string;
        Data: null;
        InnerException: {
            ClassName: string;
            Message: string;
            Data: {};
            InnerException: null;
            HelpURL: null;
            StackTraceString: string;
            RemoteStackTraceString: null;
            RemoteStackIndex: number;
            ExceptionMethod: null;
            HResult: number;
            Source: string;
            WatsonBuckets: null;
        };
        HelpURL: null;
        StackTraceString: null;
        RemoteStackTraceString: null;
        RemoteStackIndex: 0;
        ExceptionMethod: null;
        HResult: number;
        Source: null;
        WatsonBuckets: null;
    }[];
    name: string;
    response: object;
    statusCode: number;
}

interface ApolloNotify {
    mutate<TType, TVariables>(
        options: MutationOptions<TType, TVariables>,
    ): Promise<FetchResult<TType>>;
}

interface ApolloHelpers {
    onLogin: (token: string) => void;
    onLogout: () => void;
    getToken: () => string;
}
