import React, { useState } from 'react';
import LoginForm from './LoginForm';
import RegisterForm from './RegisterForm';

import './LoginRegister.css';

function LoginRegister() {
    const [action, setAction] = useState('');

    const registerLink = () => {
        setAction('active');
    };

    const loginLink = () => {
        setAction('');
    };

    return (
        <section className='loginRegisterPage'>
            <div className={`loginRegisterPage__wrapper ${action}`}>
                <div className='loginRegisterPage__form-box form-box--login'>
                    <LoginForm registerLink={registerLink} />
                </div>
                <div className='loginRegisterPage__form-box form-box--register'>
                    <RegisterForm loginLink={loginLink} />
                </div>
            </div>
        </section>
    );
}

export default LoginRegister;
