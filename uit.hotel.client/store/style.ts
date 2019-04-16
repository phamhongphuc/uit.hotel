import { MutationTree, ActionTree } from 'vuex';

interface StyleState {
    breakpoint: string;
}

export const state = (): StyleState => ({
    breakpoint: '',
});

export const mutations: MutationTree<StyleState> = {
    setBreakpoint(state, text) {
        state.breakpoint = text;
    },
};

export const actions: ActionTree<StyleState, StyleState> = {
    updateBreakpoint({ state, commit }) {
        const w = window.innerWidth;
        let breakpoint = 'none';
        if (w < 576) breakpoint = 'xs';
        if (w >= 576) breakpoint = 'sm';
        if (w >= 768) breakpoint = 'md';
        if (w >= 992) breakpoint = 'lg';
        if (w >= 1200) breakpoint = 'xl';
        if (state.breakpoint !== breakpoint) {
            commit('setBreakpoint', breakpoint);
        }
    },
};
