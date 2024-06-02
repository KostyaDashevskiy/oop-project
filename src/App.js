import LoginRegister from './components/LoginRegister/LoginRegister';
import Profile from './components/Profile/Profile';
import Home from './components/Home/Home';
import { Routes, Route } from 'react-router-dom';

function App() {
    return (
        <Routes>
            <Route path='/' element={<LoginRegister />} />
            <Route path='/profile' element={<Profile />} />
            <Route path='/home' element={<Home />} />
        </Routes>
    );
}

export default App;
