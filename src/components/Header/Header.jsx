import { Link } from 'react-router-dom';
import Cookies from 'universal-cookie';
import '../../scss/app.scss';
import Logo from '../Assets/Logo.png';
import HeaderMenu from './HeaderMenu';

function Header({ cookies, setCookiesState }) {
    return (
        <header id='header'>
            <div className='header__container'>
                <div className='header__logo'>
                    <Link to='/home' className='header__link'>
                        <img src={Logo} alt='Gwent PvZ edition' />
                    </Link>
                </div>
                <HeaderMenu cookies={cookies} setCookiesState={setCookiesState} />
            </div>
        </header>
    );
}

export default Header;
