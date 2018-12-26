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
    login(state, token: string) {
        state.token = token;
    },
};

export const actions: ActionTree<UserState, UserState> = {
    login(
        { state, commit },
        { id, password }: { id: string; password: string },
    ): Promise<void> | void {
        if (state.token !== null) return;

        return apollo(this, async apolloClient => {
            const result: GraphqlResult<{
                login: string;
            }> = await apolloClient.mutate({
                mutation: gql`
                    mutation login($id: String!, $password: String!) {
                        login(id: $id, password: $password)
                    }
                `,
                variables: { id, password },
            });

            commit('login', result.data.login);
        });
    },

    checkLogin({ state }) {
        return state.token !== null;
    },
};
