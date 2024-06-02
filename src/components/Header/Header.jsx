import { useState } from 'react';
import { Link } from 'react-router-dom';
import { FaUser } from 'react-icons/fa6';
import { BiLogOut } from 'react-icons/bi';
import './Header.css';

function Header() {
    const [isOpen, setOpen] = useState(false);

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
                        USERNAME
                    </button>
                    <div className={`header_dropdown ${isOpen ? 'active' : ''}`}>
                        <ul className='menu_list'>
                            <Link to='/profile' className='menu_link'>
                                <li className='menu_item'>
                                    <FaUser className='icon' />
                                    <span>Profile</span>
                                </li>
                            </Link>
                            <Link to='/' className='menu_link'>
                                <li className='menu_item'>
                                    <BiLogOut className='icon' />
                                    <span>Log out</span>
                                </li>
                            </Link>
                        </ul>
                    </div>
                </div>
            </div>
        </header>
    );
}

export default Header;
