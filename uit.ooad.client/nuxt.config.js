module.exports = {
    head: {
        title: 'uit.ooad.client',
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
        link: [{ rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' }],
    },
    server: {
        port: 8080,
    },
    css: [{ src: 'bootstrap/scss/bootstrap.scss', lang: 'scss' }],
    loading: { color: '#3B8070' },
    build: {
        extend(config, { isDev, isClient }) {
            if (isDev && isClient) {
                config.module.rules.push({
                    enforce: 'pre',
                    test: /\.(js|vue)$/,
                    loader: 'eslint-loader',
                    exclude: /(node_modules)/,
                });
            }
        },
    },
    modules: ['@nuxtjs/apollo'],
    apollo: {
        clientConfigs: {
            default: {
                httpEndpoint: 'http://localhost:3000/api/graphql',
            },
        },
    },
};
