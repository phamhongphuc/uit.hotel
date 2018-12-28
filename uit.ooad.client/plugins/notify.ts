import { NotificationOptions } from 'vue-notification/dist/ssr';
import Vue from 'vue';

function show(
    options: NotificationOptions | string,
    delay: number,
    type: string,
): void {
    setTimeout(() => Vue.notify({ ...options, type }), delay);
}

export const notify = {
    warn(options: NotificationOptions | string, delay: number = 250) {
        show(options, delay, 'warn');
    },
    error(options: NotificationOptions | string, delay: number = 250) {
        show(options, delay, 'error');
    },
    success(options: NotificationOptions | string, delay: number = 250) {
        show(options, delay, 'success');
    },
};
