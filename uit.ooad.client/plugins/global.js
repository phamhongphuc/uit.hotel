/* eslint-disable no-unused-vars */
import Vue, { ComponentOptions } from 'vue';

/**
 * @param {Object} Nuxt
 * @param {Vue} Nuxt.app
 */
export default function({ app }) {
    extend(app, {
        mounted() {
            const updateBreakpoint = () =>
                this.$store.dispatch('style/updateBreakpoint');
            updateBreakpoint();
            window.addEventListener('resize', updateBreakpoint);
        },
    });
}

/**
 * @param {Vue} app
 * @param {ComponentOptions} mixin
 */
const extend = (app, mixin) => {
    if (!app.mixins) app.mixins = [];
    app.mixins.push(mixin);
};
