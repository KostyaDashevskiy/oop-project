import { useState } from 'react';
import { FaUser } from 'react-icons/fa6';
import { BiLogOut } from 'react-icons/bi';
import Cookies from 'universal-cookie';
import { Link, Navigate } from 'react-router-dom';

function HeaderMenu({ cookies }) {
    const [isOpen, setOpen] = useState(false);
    const logoutFunc = () => {
        cookies.remove('jwt_token');
        cookies.remove('name');
        return <Navigate to='/' />;
    };
    return (
        <>
            <nav className='header_menu menu'>
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
                        <a className='menu_link' onClick={() => logoutFunc}>
                            <li className='menu_item'>
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
