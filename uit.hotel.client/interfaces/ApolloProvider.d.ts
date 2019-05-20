import { InMemoryCache } from 'apollo-cache-inmemory';
import { ApolloClient } from 'apollo-client';

export interface ApolloProvider {
    defaultClient: ApolloClient<InMemoryCache>;
}
