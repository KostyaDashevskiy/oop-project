import { Link } from 'react-router-dom';
import Cookies from 'universal-cookie';
import '../../scss/app.scss';
import Logo from '../Assets/Logo.png';
import HeaderMenu from './HeaderMenu';

function Header({ cookies }) {
    return (
        <header className='header'>
            <div className='header_container'>
                <div className='header_logo'>
                    <Link to='/home' className='header_link'>
                        <img src={Logo} alt='Gwent PvZ edition' />
                    </Link>
                </div>
                <HeaderMenu cookies={cookies} />
            </div>
        </header>
    );
}

export default Header;
