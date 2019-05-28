export interface ApolloHelpers {
    onLogin: (token: string) => void;
    onLogout: () => void;
    getToken: () => string;
}
