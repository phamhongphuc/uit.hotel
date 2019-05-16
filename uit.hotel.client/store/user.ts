import gql from 'graphql-tag';
import { ActionTree, GetterTree, MutationTree } from 'vuex';
import { IsInitialized, UserCheckLogin, UserLogin } from '~/graphql/types';
import {
    apolloClient,
    apolloClientNotify,
    apolloHelpers,
} from '~/modules/apollo';
import { notify } from '~/plugins/notify';
import { router } from '~/utils';
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

    async serverUpdateUserProfile({ commit }, token: string): Promise<boolean> {
        if (typeof token !== 'string') return false;

        commit('setToken', token);

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
            return true;
        } catch (e) {
            return false;
        }
    },

    async checkIsInitializedDatabase(): Promise<void> {
        let isInitialized = true;
        try {
            const result = await apolloClient(this).query<IsInitialized.Query>({
                query: gql`
                    query isInitialized {
                        isInitialized
                    }
                `,
            });
            isInitialized = result.data.isInitialized;
        } finally {
            if (isInitialized) {
                router(this).push('/login');
                notify.error({
                    title: 'Thông báo',
                    text:
                        'Hệ thống đã có sẵn tài khoản quản trị, không thể khởi tạo',
                });
            }
        }
    },
};
