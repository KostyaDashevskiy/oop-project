import React, { useState } from 'react';
import LoginForm from './LoginForm';
import RegisterForm from './RegisterForm';

import '../../scss/app.scss';

function LoginRegister({ cookies }) {
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
                    <LoginForm registerLink={registerLink} cookies={cookies} />
                </div>
                <div className='loginRegisterPage__form-box form-box--register'>
                    <RegisterForm loginLink={loginLink} />
                </div>
            </div>
        </section>
    );
}

export default LoginRegister;
