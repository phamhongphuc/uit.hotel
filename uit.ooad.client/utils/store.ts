import Vue, { ComponentOptions } from 'vue';
import VueRouter, { Route } from 'vue-router';

export interface StoreSelf {
    app: ComponentOptions<Vue>;
}

export function router(self: StoreSelf): VueRouter {
    return self.app.router as VueRouter;
}

export function route(self: StoreSelf): Route {
    return router(self).currentRoute;
}
