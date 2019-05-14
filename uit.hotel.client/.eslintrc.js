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

        'plugin:node/recommended',
        'plugin:import/warnings',
        'plugin:import/errors',
        'plugin:import/typescript',

        'plugin:vue/recommended',
        'plugin:@typescript-eslint/recommended',
        'plugin:prettier/recommended',

        'prettier/@typescript-eslint',
        'prettier/vue',
    ],
    parser: 'vue-eslint-parser',
    parserOptions: {
        parser: '@typescript-eslint/parser',
        sourceType: 'module',
        ecmaVersion: 2017,
        ecmaFeatures: {
            jsx: false,
        },
    },
    plugins: [
        'standard',
        'vue',
        'import',
        'node',
        'graphql',
        '@typescript-eslint',
    ],
    settings: {
        cache: true,
        'import/resolver': {
            'babel-plugin-root-import': {
                rootPathPrefix: '~',
                rootPathSuffix: '',
            },
            typescript: {},
        },
        'import/core-modules': [
            '@babel/polyfill',
            '@babel/register',
            '@nuxt/vue-app',
            'apollo-cache-inmemory',
            'apollo-client',
            'apollo-link',
            'chalk',
            'graphql',
            'vue-router',
            'vue',
            'vuex',
        ],
    },
    rules: {
        'eol-last': 'error',
        'linebreak-style': ['warn', 'unix'],
        'no-console': 'warn',
        'no-lonely-if': 'error',
        'prefer-const': 'error',
        'space-before-function-paren': [
            'error',
            { anonymous: 'never', named: 'never', asyncArrow: 'always' },
        ],

        '@typescript-eslint/no-explicit-any': 'off',

        'node/no-unsupported-features/es-syntax': 'off',
        'import/prefer-default-export': 'off',

        'vue/html-self-closing': [
            'error',
            { html: { void: 'always', normal: 'always', component: 'always' } },
        ],
        'vue/component-name-in-template-casing': ['error', 'kebab-case'],

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
    overrides: [
        {
            files: ['graphql/types.ts'],
            rules: {
                'import/export': 'off',
                '@typescript-eslint/no-empty-interface': 'off',
                '@typescript-eslint/no-explicit-any': 'off',
                '@typescript-eslint/no-namespace': 'off',
                '@typescript-eslint/prefer-interface': 'off',
                '@typescript-eslint/array-type': ['error', 'generic'],
            },
        },
        {
            files: ['store/*.ts'],
            rules: {
                'import/no-cycle': 'off',
            },
        },
    ],
};

if (process.env.NODE_ENV == 'development') {
    config.plugins.push('only-warn');
}

module.exports = config;
