import { MutationTree, ActionTree } from 'vuex';
import apollo from '~/modules/apollo';
import gql from 'graphql-tag';
import { GraphqlResult } from '../graphql/graphqlHelper';

interface UserState {
    token: null | string;
}

export const state = (): UserState => ({
    token: null,
});

export const mutations: MutationTree<UserState> = {
    setToken(state, token: string) {
        state.token = token;
    },
};

export const actions: ActionTree<UserState, UserState> = {
    async login(
        { state, commit },
        { id, password }: { id: string; password: string },
    ): Promise<void> {
        if (state.token !== null) return;

        await apollo(this, async apolloClient => {
            type LoginResult = GraphqlResult<{ login: string }>;
            const result: LoginResult = await apolloClient.mutate({
                mutation: gql`
                    mutation login($id: String!, $password: String!) {
                        login(id: $id, password: $password)
                    }
                `,
                variables: { id, password },
            });

            commit('setToken', result.data.login);
        });
    },

    checkLogin({ state }) {
        return state.token !== null;
    },
};
