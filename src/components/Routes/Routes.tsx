import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import App from '../../App';
import LoginRegister from '../../components/LoginRegister/LoginRegister';
import Home from '../../components/Home/Home';
import Game from '../../components/GameComponents/pages/Main';
import Profile from '../../components/Profile/Profile';
import Page404 from '../../components/Page404/Page404';
import Cookies from 'universal-cookie';

const cookies: Cookies = new Cookies(null, {
    path: '/',
    maxAge: 3600,
});

export const routes = createBrowserRouter([
    {
        path: '/',
        element: <App />,
        children: [
            { path: '', element: <LoginRegister cookies={cookies} /> },
            { path: 'home', element: <Home cookies={cookies} /> },
            { path: 'game', element: <Game /> },
            { path: 'profile', element: <Profile cookies={cookies} /> },
            { path: '*', element: <Page404 cookies={cookies} /> },
        ],
    },
]);
