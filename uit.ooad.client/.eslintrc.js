const schemaJson = require('./graphql/schema.json');
const isWin = require('os').platform() === 'win32';

const config = {
    env: {
        node: true,
        browser: true,
        es6: true,
        mocha: true,
    },
    extends: [
        'airbnb-base',
        'eslint:recommended',
        'standard',
        'plugin:vue/recommended',
        'plugin:node/recommended',
        'plugin:import/warnings',
        'plugin:import/errors',
        'plugin:prettier/recommended',
        'prettier/vue',
    ],
    parser: 'vue-eslint-parser',
    parserOptions: {
        parser: 'babel-eslint',
        ecmaVersion: 2017,
        sourceType: 'module',
    },
    plugins: ['standard', 'vue', 'import', 'node', 'graphql'],
    settings: {
        'import/resolver': {
            'babel-plugin-root-import': {
                rootPathPrefix: '~',
                rootPathSuffix: '',
            },
        },
        'import/core-modules': [
            'vue',
            'vuex',
            '@babel/register',
            '@babel/polyfill',
            'chalk',
        ],
    },
    rules: {
        indent: ['error', 4],
        camelcase: 'error',
        'eol-last': 'error',
        'linebreak-style': ['warn', isWin ? 'windows' : 'unix'],
        'no-console': 'warn',
        'no-lonely-if': 'error',
        'prefer-const': 'error',
        'space-before-function-paren': [
            'error',
            { anonymous: 'never', named: 'never', asyncArrow: 'always' },
        ],
        'node/no-unsupported-features/es-syntax': 'off',
        'import/prefer-default-export': 'off',
        'vue/html-indent': ['error', 4],
        'vue/html-self-closing': [
            'error',
            { html: { void: 'always', normal: 'always', component: 'always' } },
        ],
        'vue/component-name-in-template-casing': ['error', 'kebab-case'],
        'vue/attributes-order': [
            'error',
            {
                order: [
                    'DEFINITION', //        is
                    'LIST_RENDERING', //    v-for
                    'CONDITIONALS', //      v-if | v-else-if | v-else | v-show | v-cloak
                    'RENDER_MODIFIERS', //  v-pre | v-once
                    'GLOBAL', //            id
                    'UNIQUE', //            ref | key | slot | slot-scope
                    'TWO_WAY_BINDING', //   v-model
                    'OTHER_DIRECTIVES', //  v-custom-directive
                    'OTHER_ATTR', //        custom-prop | v-bind:prop | :prop
                    'EVENTS', //            v-on:click | @click
                    'CONTENT', //           v-text | v-html
                ],
            },
        ],
        'graphql/template-strings': [
            'error',
            {
                validators: 'all',
                env: 'apollo',
                schemaJson,
            },
        ],
        'graphql/named-operations': [
            'warn',
            {
                schemaJson,
            },
        ],
    },
};

if (process.env.NODE_ENV == 'development') {
    config.plugins.push('only-warn');
}

module.exports = config;
