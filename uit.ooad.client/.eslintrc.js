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
        parser: 'eslint-plugin-typescript/parser',
        sourceType: 'module',
        ecmaVersion: 2017,
        ecmaFeatures: {
            jsx: false,
        },
    },
    plugins: ['standard', 'vue', 'import', 'node', 'graphql', 'typescript'],
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
        'linebreak-style': ['warn', isWin ? 'windows' : 'unix'],
        'no-console': 'warn',
        'no-lonely-if': 'error',

        'typescript/adjacent-overload-signatures': 'error',
        'typescript/array-type': 'error',
        'typescript/ban-types': 'error',
        camelcase: 'off',
        'typescript/camelcase': 'error',
        'typescript/class-name-casing': 'error',
        'typescript/explicit-function-return-type': 'warn',
        'typescript/explicit-member-accessibility': 'off',
        indent: 'off',
        'typescript/indent': 'off', // because of prettier
        'typescript/interface-name-prefix': 'error',
        'typescript/member-delimiter-style': 'error',
        'typescript/no-angle-bracket-type-assertion': 'error',
        'no-array-constructor': 'off',
        'typescript/no-array-constructor': 'error',
        'typescript/no-empty-interface': 'error',
        'typescript/no-explicit-any': 'off',
        'typescript/no-inferrable-types': 'error',
        'typescript/no-misused-new': 'error',
        'typescript/no-namespace': 'off',
        'typescript/no-non-null-assertion': 'error',
        'typescript/no-object-literal-type-assertion': 'error',
        'typescript/no-parameter-properties': 'error',
        'typescript/no-triple-slash-reference': 'error',
        'no-unused-vars': 'off',
        'typescript/no-unused-vars': 'warn',
        'typescript/no-use-before-define': 'error',
        'typescript/no-var-requires': 'error',
        'typescript/prefer-interface': 'off',
        'typescript/prefer-namespace-keyword': 'error',
        'typescript/type-annotation-spacing': 'error',

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
    overrides: [
        {
            files: ['graphql/types.ts'],
            rules: {
                'import/export': 'off',
            },
        },
    ],
};

if (process.env.NODE_ENV == 'development') {
    config.plugins.push('only-warn');
}

module.exports = config;
