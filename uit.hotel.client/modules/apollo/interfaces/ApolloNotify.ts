import { MutationOptions } from 'apollo-client';
import { FetchResult } from 'apollo-link';

export interface ApolloNotify {
    mutate<TType, TVariables>(
        options: MutationOptions<TType, TVariables>,
    ): Promise<FetchResult<TType>>;
}
