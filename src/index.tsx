import * as React from 'react';
import * as ReactDOM from 'react-dom/client';
import './scss/app.scss';
import App from './App';
import { routes } from './components/Routes/Routes';
import { RouterProvider } from 'react-router-dom';

const root = ReactDOM.createRoot(document.getElementById('root')!);

root.render(<RouterProvider router={routes} />);
