import { Context } from '@nuxt/types';
import cookie from 'cookie';
import { RootState } from '~/store';

const publicRoutes = ['login', 'initialize'];

export default async function({
    req,
    store,
    redirect,
    route,
}: Context): Promise<void | undefined> {
    function checkAndRedirect(): void {
        if (!publicRoutes.includes(route.name || '')) redirect('/login');
    }

    if (process.server) {
        // Call first and one time user access to this application.
        const { headers } = req;
        if (headers.cookie === undefined) return checkAndRedirect();
        const token = cookie.parse(headers.cookie)['apollo-token'];
        const isUserLoggedIn = await store.dispatch(
            'user/serverUpdateUserProfile',
            token,
        );
        if (!isUserLoggedIn) return checkAndRedirect();
        if (route.name === 'login') return redirect('/');
    } else {
        const { employee } = (store.state as RootState).user;
        if (!employee) return checkAndRedirect();
    }
    return undefined;
}
