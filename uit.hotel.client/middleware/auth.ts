import { Context } from '@nuxt/types';
import cookie from 'cookie';
import { RootState } from '~/store';

const publicRoutes = ['login', 'initialize'];

export default async function({
    req,
    store,
    redirect,
    route,
}: Context): Promise<void> {
    function checkAndRedirect(): void {
        if (!publicRoutes.includes(route.name || '')) redirect('/login');
    }

    if (process.server) {
        // Call first and one time user access to this application.
        const headers: any = req.headers;
        if (headers.cookie === undefined) return checkAndRedirect();
        const token = cookie.parse(headers.cookie)['apollo-token'];
        const isUserLoggedIn = await store.dispatch(
            'user/serverUpdateUserProfile',
            token,
        );
        if (!isUserLoggedIn) return checkAndRedirect();
        else if (route.name === 'login') redirect('/');
    } else {
        const employee = (store.state as RootState).user.employee;
        if (!employee) return checkAndRedirect();
    }
}
