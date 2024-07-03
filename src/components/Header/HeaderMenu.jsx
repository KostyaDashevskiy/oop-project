import { useState } from 'react';
import { FaUser } from 'react-icons/fa6';
import { BiLogOut } from 'react-icons/bi';
import { Link, useNavigate } from 'react-router-dom';

function HeaderMenu({ cookies, setCookiesState }) {
    const [isOpen, setOpen] = useState(false);
    const navigate = useNavigate();
    function logoutFunc() {
        cookies.remove('jwt_token');
        cookies.remove('name');
        setCookiesState();
        navigate('/');
    }
    return (
        <>
            <nav className='header__menu menu' onClick={() => setOpen(!isOpen)}>
                <FaUser className='menu__icon' />
                <button className='menu__button'>
                    {cookies.get('name') !== undefined ? cookies.get('name') : 'Username'}
                </button>
                <div className={`menu__dropdown ${isOpen ? 'active' : ''}`}>
                    <ul className='menu__list'>
                        <Link to='/profile' className='menu__link'>
                            <li className='menu__item'>
                                <FaUser className='icon' />
                                <span>Profile</span>
                            </li>
                        </Link>
                        <a className='menu__link' onClick={() => logoutFunc()}>
                            <li className='menu__item'>
                                <BiLogOut className='icon' />
                                <span>Log out</span>
                            </li>
                        </a>
                    </ul>
                </div>
            </nav>
        </>
    );
}

export default HeaderMenu;
