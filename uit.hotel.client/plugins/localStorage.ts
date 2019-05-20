import createPersistedState from 'vuex-persistedstate';
import Vue, { ComponentOptions } from 'vue';

export default ({ store }: ComponentOptions<Vue>): void => {
    window.onNuxtReady(() => {
        createPersistedState({
            paths: ['user'],
        })(store);
    });
};
