import gql from 'graphql-tag';
import { ActionTree, MutationTree } from 'vuex';
import { userCheckLogin, userLogin } from '~/graphql/documents';
import { IsInitialized, UserCheckLogin, UserLogin } from '~/graphql/types';
import {
    apolloClient,
    apolloClientNotify,
    apolloHelpers,
} from '~/modules/apollo';
import { notify } from '~/plugins/notify';
import { RootState } from '.';

export interface UserState {
    token: undefined | string;
    employee?: UserLogin.Employee;
}

export const state = (): UserState => ({
    token: undefined,
    employee: undefined,
});

export const mutations: MutationTree<UserState> = {
    setToken(state, token: string) {
        state.token = token;
    },
    login(state, { token, employee }: UserLogin.Login) {
        apolloHelpers(this).onLogin(token);
        state.token = token;
        state.employee = employee;
    },
    logout(state) {
        apolloHelpers(this).onLogout();
        state.token = undefined;
        state.employee = undefined;
    },
};

export const actions: ActionTree<UserState, RootState> = {
    async login({ commit }, variables: UserLogin.Variables) {
        const result = await apolloClientNotify(this).mutate<
            UserLogin.Mutation,
            UserLogin.Variables
        >({
            mutation: userLogin,
            variables,
        });

        if (result.data === undefined || result.data.login === null) return;

        commit('login', result.data.login);
        this.$router.push('/');
        notify.success({ title: 'Thông báo', text: 'Đăng nhập thành công' });
    },

    async logout({ commit }) {
        commit('logout');
        this.$router.push('/login');
        notify.success({ title: 'Thông báo', text: 'Đăng xuất thành công' });
    },

    async serverUpdateUserProfile({ commit }, token: string) {
        if (typeof token !== 'string') return false;

        commit('setToken', token);

        try {
            const result = await apolloClient(this).mutate<
                UserCheckLogin.Mutation
            >({
                mutation: userCheckLogin,
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

    async checkIsInitializedDatabase() {
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
                this.$router.push('/login');
                notify.error({
                    title: 'Thông báo',
                    text:
                        'Hệ thống đã có sẵn tài khoản quản trị, không thể khởi tạo',
                });
            }
        }
    },
};
