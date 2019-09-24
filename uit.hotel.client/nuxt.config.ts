import { Configuration } from '@nuxt/types';

const LOCALHOST = `http://localhost:3000`;

const config: Configuration = {
    head: {
        title: 'uit.hotel.client',
        meta: [
            { charset: 'utf-8' },
            {
                name: 'viewport',
                content: 'width=device-width, initial-scale=1',
            },
            {
                hid: 'description',
                name: 'description',
                content: 'Nuxt.js project',
            },
        ],
        link: [
            {
                rel: 'stylesheet',
                href: 'https://fonts.googleapis.com/css?family=Pacifico',
            },
            { rel: 'icon', type: 'image/png', href: '/favicon.png' },
        ],
    },
    server: {
        port: process.env.PORT || 8080,
    },
    env: {},
    css: ['~/assets/scss/main.scss'],
    loading: { color: '#3B8070' },
    buildModules: [
        [
            '@nuxt/typescript-build',
            { typeCheck: true, ignoreNotFoundWarnings: true },
        ],
        '@nuxtjs/style-resources',
    ],
    modules: ['@nuxtjs/apollo', ['bootstrap-vue/nuxt', { css: false }]],
    styleResources: {
        scss: [
            'assets/scss/before/_before.scss',
            'bootstrap/scss/_functions.scss',
            'bootstrap/scss/_variables.scss',
            'bootstrap/scss/_mixins.scss',
            'assets/scss/after/_after.scss',
        ],
    },
    plugins: [
        { src: '~/plugins/localStorage', ssr: false },
        { src: '~/plugins/notification', ssr: false },
        { src: '~/plugins/notify', ssr: false },
        { src: '~/plugins/global', ssr: false },
        { src: '~/plugins/component' },
        { src: '~/plugins/vuelidate' },
    ],
    router: {
        middleware: 'auth',
    },
    apollo: {
        clientConfigs: {
            default: {
                httpEndpoint: `${process.env.HTTP_ENDPOINT ||
                    LOCALHOST}/api/graphql`,
            },
        },
    },
    build: {
        extend(config, { isDev, isClient }) {
            if (isDev && isClient) {
                if (config.module) {
                    config.module.rules.push({
                        enforce: 'pre',
                        test: /\.(ts|js|vue)$/,
                        loader: 'eslint-loader',
                        exclude: /(node_modules)/,
                    });
                }
            }
        },
        postcss: {
            plugins: {},
            preset: {
                autoprefixer: {},
            },
        },
    },
};

export default config;
