import { useState } from 'react';
import { Link, Navigate } from 'react-router-dom';
import Cookies from 'universal-cookie';
import { FaUser } from 'react-icons/fa6';
import { BiLogOut } from 'react-icons/bi';
import './Header.css';

function Header({ cookies }) {
    const [isOpen, setOpen] = useState(false);
    const [logout, setLogout] = useState(false);

    function logoutFunc() {
        cookies.remove('jwt_token');
        cookies.remove('name');
        return <Navigate to='/' />;
    }

    return (
        <header className='header'>
            <div className='header_container'>
                <div className='header_logo'>
                    <Link to='/home' className='header_link'>
                        PLANTS VS ZOMBIES:
                        <br /> GWENT EDITION
                    </Link>
                </div>

                <div className='header_menu menu'>
                    <FaUser className='menu_icon' />
                    <button className='menu_button' onClick={() => setOpen(!isOpen)}>
                        {cookies.get('name') !== undefined ? cookies.get('name') : 'Username'}
                    </button>
                    <div className={`header_dropdown ${isOpen ? 'active' : ''}`}>
                        <ul className='menu_list'>
                            <Link to='/profile' className='menu_link'>
                                <li className='menu_item'>
                                    <FaUser className='icon' />
                                    <span>Profile</span>
                                </li>
                            </Link>
                            <a className='menu_link' onClick={() => setLogout(!logout)}>
                                <li className='menu_item'>
                                    <BiLogOut className='icon' />
                                    <span>Log out</span>
                                </li>
                            </a>
                        </ul>
                    </div>
                </div>
            </div>
            <div>{logout ? logoutFunc() : ''}</div>
        </header>
    );
}

export default Header;
