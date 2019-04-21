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
        'plugin:@typescript-eslint/recommended',
        'plugin:prettier/recommended',
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
            'vue',
            'vuex',
            'vue-router',
            '@babel/register',
            '@babel/polyfill',
            'chalk',
            'graphql',
            'apollo-client',
            'apollo-link',
            'apollo-cache-inmemory',
        ],
    },
    rules: {
        'eol-last': 'error',
        'linebreak-style': ['warn', 'unix'],
        'no-console': 'warn',
        'no-lonely-if': 'error',

        //?"@typescript-eslint/explicit-member-accessibility": "error",
        //? 'typescript/prefer-interface': 'off',
        '@typescript-eslint/indent': 'off', // Because of prettier
        '@typescript-eslint/no-explicit-any': 'off',

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
        'vue/attributes-order': 'error',

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
            },
        },
    ],
};

if (process.env.NODE_ENV == 'development') {
    config.plugins.push('only-warn');
}

module.exports = config;
