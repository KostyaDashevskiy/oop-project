import { FaUser } from "react-icons/fa6";
import { BiLogOut } from "react-icons/bi";
import './Header.css'
import { useState } from 'react';

function Header () {
    const [isOpen,setOpen] = useState(false);

    return (
        <header className = "header">
            <div className = "header_container">
                
                <div className="header_logo">
                    <a href='#!'className='header_link'>PLANTS VS ZOMBIES:<br /> GWENT EDITION</a>
                </div>

                <div className="header_username">
                    <div className="header_menu menu">
                        <FaUser className='menu_icon'/>
                        <button className = "menu_button" onClick={() => setOpen(!isOpen)}>
                            <span>USERNAME</span>
                        </button>
                        <div className={`header_dropdown ${isOpen ? "active" : ""}`}>
                            <ul className = "menu_list">
                                <li className = "menu_item">
                                    <FaUser className = "icon"/>
                                    <span>Profile</span>
                                </li>
                                <li className = "menu_item">
                                    <BiLogOut className = "icon"/>
                                    <span>Log out</span>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                
            </div>
        </header>
    )
}

export default Header;