import Vue from 'vue';

const requireComponent = require.context('../components', true, /.vue$/);

requireComponent.keys().forEach((fileName): void => {
    const componentConfig = requireComponent(fileName);

    const regexr = /^.(\/[\w-]+)+\/([\w-]+).vue$/i;
    const name = fileName.replace(regexr, '$2');

    Vue.component(name + '-', componentConfig.default || componentConfig);
});
