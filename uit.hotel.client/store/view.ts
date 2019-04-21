import { MutationTree } from 'vuex';

export interface ViewState {
    open: boolean;
}

export const state = (): ViewState => ({
    open: false,
});

export const mutations: MutationTree<ViewState> = {
    toggle(state) {
        state.open = !state.open;
    },
};
