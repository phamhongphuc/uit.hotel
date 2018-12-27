import Vue from 'vue';
import { ApolloClient, ApolloError } from 'apollo-client';
import { InMemoryCache } from 'apollo-cache-inmemory';

export default async function(store: any, action: Action): Promise<void> {
    try {
        await action(store.app.apolloProvider.defaultClient);
    } catch (error) {
        if (
            error instanceof ApolloError &&
            error.networkError !== null &&
            (error.networkError as ServerError).result !== undefined
        ) {
            Vue.notify({
                title: 'Lỗi',
                type: 'error',
                text: (error.networkError as ServerError).result[0]
                    .InnerException.Message,
            });
        } else {
            Vue.notify({
                title: 'Lỗi không xác định',
                type: 'error',
                text: error.message,
            });
        }
        throw error;
    }
}

interface Action {
    (apolloClient: ApolloClient<InMemoryCache>): Promise<void>;
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
