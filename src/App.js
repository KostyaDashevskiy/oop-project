import LoginRegister from './components/LoginRegister/LoginRegister';
import Profile from './components/Profile/Profile';
import Home from './components/Home/Home';
import { Routes, Route } from 'react-router-dom';
import Cookies from 'universal-cookie';

function App() {
    const cookies = new Cookies(null, {
        path: '/',
        maxAge: 3600,
    });
    return (
        <Routes>
            <Route path='/' element={<LoginRegister cookies={cookies} />} />
            <Route path='/profile' element={<Profile cookies={cookies} />} />
            <Route path='/home' element={<Home cookies={cookies} />} />
        </Routes>
    );
}

export default App;
