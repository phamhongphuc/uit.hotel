import gql from 'graphql-tag';
import Vue from 'vue';
import { ActionTree, MutationTree } from 'vuex';
import { UserCheckLogin, UserLogin } from '~/graphql/types';
import {
    apolloClient,
    apolloHelpers,
    apolloClientNotify,
} from '~/modules/apollo';
import { router, route } from '~/utils/store';

interface UserState {
    token: undefined | string;
}

export const state = (): UserState => ({
    token: undefined,
});

export const mutations: MutationTree<UserState> = {
    setToken(state, token: string) {
        state.token = token;
    },
};

export const actions: ActionTree<UserState, UserState> = {
    async login({ commit }, variables: UserLogin.Variables): Promise<void> {
        const result = await apolloClientNotify(this).mutate<
            UserLogin.Mutation,
            UserLogin.Variables
        >({
            mutation: gql`
                mutation userLogin($id: String!, $password: String!) {
                    login(id: $id, password: $password) {
                        token
                        employee {
                            id
                            name
                        }
                    }
                }
            `,
            variables,
            errorPolicy: 'none',
        });

        if (result.data === undefined || result.data.login === null) return;

        const token = result.data.login.token;
        apolloHelpers(this).onLogin(token);
        commit('setToken', result.data.login.token);

        Vue.notify({
            title: 'Đăng nhập thành công',
        });
        router(this).push('/');
    },

    async logout({ commit }) {
        apolloHelpers(this).onLogout();
        commit('setToken', undefined);
        router(this).push('/login');

        await Vue.nextTick();
        Vue.notify({
            title: 'Đăng xuất thành công',
        });
    },

    async checkLogin({ state, commit }) {
        const token = state.token || apolloHelpers(this).getToken();

        if (typeof token === 'string') {
            try {
                await apolloClient(this).mutate<UserCheckLogin.Mutation>({
                    mutation: gql`
                        mutation userCheckLogin {
                            checkLogin {
                                id
                                name
                            }
                        }
                    `,
                });
                apolloHelpers(this).onLogin(token);
                commit('setToken', token);

                if (route(this).name === 'login') {
                    router(this).push('/');
                }
            } catch (e) {
                apolloHelpers(this).onLogout();
                commit('setToken', undefined);
                router(this).push('/login');
            }
        } else {
            router(this).push('/login');
        }
    },
};
