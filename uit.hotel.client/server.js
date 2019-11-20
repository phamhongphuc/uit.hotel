/* eslint-disable no-console */
/* eslint-disable node/no-extraneous-require */
/* eslint-disable @typescript-eslint/no-var-requires */

// process.argv[2] = 'start';
// require('@nuxt/typescript-runtime/bin/nuxt-ts');

const { Nuxt } = require('@nuxt/core');
const app = require('express')();
const config = require('./nuxt.config');

const HOST = process.env.HOST || '127.0.0.1';
const PORT = process.env.PORT || 8080;

const isProd = process.env.NODE_ENV !== 'development';
config.dev = !isProd;
const nuxt = new Nuxt(config);

app.use(nuxt.render);
app.listen(PORT, HOST);
console.log(`Server listening on ${HOST}:${PORT}.`);
