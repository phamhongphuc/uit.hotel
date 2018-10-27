module.exports = {
    env: {
        node: true,
        browser: true,
        es6: true,
        mocha: true,
    },
    extends: [
        'eslint:recommended',
        'plugin:vue/recommended',
        'plugin:import/errors',
        'plugin:import/warnings',
        'plugin:node/recommended',
    ],
    parser: 'vue-eslint-parser',
    parserOptions: {
        parser: 'babel-eslint',
        ecmaVersion: 2017,
        sourceType: 'module',
        ecmaFeatures: {
            jsx: true,
            experimentalObjectRestSpread: true,
        },
    },
    plugins: ['vue', 'import', 'node'],
    settings: {
        'import/resolver': {
            'babel-plugin-root-import': {
                rootPathPrefix: '~',
                rootPathSuffix: '',
            },
        },
    },
    rules: {
        'eol-last': 'off',
        indent: ['warn', 4, { MemberExpression: 1 }],
        'linebreak-style': ['error', process.platform === 'win32' ? 'windows' : 'unix'],
        'no-console': 'off',
        'no-global-assign': [
            'error',
            {
                exceptions: ['Object'],
            },
        ],
        'no-throw-literal': 'off',
        'no-unused-vars': 'warn',
        'node/no-deprecated-api': [
            'warn',
            {
                ignoreModuleItems: [],
                ignoreGlobalItems: [],
            },
        ],
        'node/no-unsupported-features/es-syntax': 'off',
        'operator-linebreak': 'off',
        'prefer-const': 'error',
        quotes: [
            'warn',
            'single',
            {
                avoidEscape: true,
                allowTemplateLiterals: true,
            },
        ],
        semi: ['error', 'always'],
        'space-before-function-paren': [
            'error',
            {
                anonymous: 'never',
                named: 'never',
                asyncArrow: 'always',
            },
        ],
        'vue/html-indent': [
            'error',
            4,
            {
                attribute: 1,
                closeBracket: 0,
                alignAttributesVertically: true,
                ignores: [],
            },
        ],
        'vue/max-attributes-per-line': [
            2,
            {
                singleline: 1,
                multiline: {
                    max: 1,
                    allowFirstLine: true,
                },
            },
        ],
    },
};
