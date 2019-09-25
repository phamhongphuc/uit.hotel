module.exports = function typescript() {
    // Add .ts extension for store, middleware and more
    this.nuxt.options.extensions.push('ts');
    // Extend build
    this.extendBuild(config => {
        const tsLoader = {
            loader: 'ts-loader',
            options: {
                appendTsSuffixTo: [/\.vue$/],
            },
        };
        // Add TypeScript loader
        config.module.rules.push({
            test: /((client|server)\.js)|(\.tsx?)$/,
            ...tsLoader,
        });
        // Add TypeScript loader for vue files
        // eslint-disable-next-line no-restricted-syntax
        for (const rule of config.module.rules) {
            if (rule.loader === 'vue-loader') {
                rule.options.loaders.ts = tsLoader;
            }
        }
        // Add .ts extension in webpack resolve
        if (config.resolve.extensions.indexOf('.ts') === -1) {
            config.resolve.extensions.push('.ts');
        }
    });
};
