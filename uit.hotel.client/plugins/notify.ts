import { NotificationOptions } from 'vue-notification/dist/ssr';
import Vue from 'vue';

const defaultDelay = 400;

type Options = NotificationOptions | string;

function show(options: Options, delay: number, type: string): void {
    setTimeout(() => Vue.notify({ ...options, type }), delay);
}

export const notify = {
    warn(options: Options, delay = defaultDelay) {
        show(options, delay, 'warn');
    },
    error(options: Options, delay = defaultDelay) {
        show(options, delay, 'error');
    },
    success(options: Options, delay = defaultDelay) {
        show(options, delay, 'success');
    },
};
