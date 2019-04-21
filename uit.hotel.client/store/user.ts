import gql from 'graphql-tag';
import { ActionTree, GetterTree, MutationTree } from 'vuex';
import { UserCheckLogin, UserLogin } from '~/graphql/types';
import {
    apolloClient,
    apolloClientNotify,
    apolloHelpers,
} from '~/modules/apollo';
import { notify } from '~/plugins/notify';
import { route, router } from '~/utils/store';
import { RootState } from '.';

export interface UserState {
    token: undefined | string;
    employee?: UserLogin.Employee;
}

export const state = (): UserState => ({
    token: undefined,
    employee: undefined,
});

export const getters: GetterTree<UserState, RootState> = {};

export const mutations: MutationTree<UserState> = {
    setToken(state, token: string): void {
        state.token = token;
    },
    login(state, { token, employee }: UserLogin.Login): void {
        apolloHelpers(this).onLogin(token);
        state.token = token;
        state.employee = employee;
    },
    logout(state): void {
        apolloHelpers(this).onLogout();
        state.token = undefined;
        state.employee = undefined;
    },
};

export const actions: ActionTree<UserState, RootState> = {
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
                            position {
                                id
                                name
                            }
                        }
                    }
                }
            `,
            variables,
        });

        if (result.data === undefined || result.data.login === null) return;

        commit('login', result.data.login);
        router(this).push('/');
        notify.success({ title: 'Thông báo', text: 'Đăng nhập thành công' });
    },

    async logout({ commit }): Promise<void> {
        commit('logout');
        router(this).push('/login');
        notify.success({ title: 'Thông báo', text: 'Đăng xuất thành công' });
    },

    async checkLogin({ state, commit }): Promise<void> {
        const token = state.token || apolloHelpers(this).getToken();

        if (typeof token === 'string') {
            try {
                const result = await apolloClient(this).mutate<
                    UserCheckLogin.Mutation
                >({
                    mutation: gql`
                        mutation userCheckLogin {
                            checkLogin {
                                id
                                name
                                position {
                                    id
                                    name
                                }
                            }
                        }
                    `,
                });

                if (result.data === undefined) {
                    throw new Error('Lỗi không xác định');
                }
                const loginArgs: UserLogin.Login = {
                    token,
                    employee: result.data.checkLogin,
                };
                commit('login', loginArgs);

                if (route(this).name === 'login') router(this).push('/');
            } catch (e) {
                commit('logout');
                router(this).push('/login');
                notify.error({
                    title: 'Lỗi xác thực',
                    text: 'Vui lòng đăng nhập lại',
                });
            }
        } else {
            router(this).push('/login');
        }
    },
};
