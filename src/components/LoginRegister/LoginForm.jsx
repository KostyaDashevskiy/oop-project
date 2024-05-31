import { useState } from 'react';
import { FaUser, FaLock } from 'react-icons/fa6';
import { CreateApiEndpoint, END_POINTS } from '../../api';
import axios from 'axios';

function LoginForm({ registerLink }) {
    const [name, setName] = useState();
    const [password, setPassword] = useState();
    const handleSubmit = (e) => {
        // Prevent the default submit and page reload
        e.preventDefault();

        CreateApiEndpoint(END_POINTS.LOGIN)
            .login({ name, password })
            .then((res) => console.log(res))
            .catch((err) => console.log(err));

        CreateApiEndpoint(END_POINTS.WEATHERFORECAST)
            .weather()
            .then((res) => console.log(res))
            .catch((err) => console.log(err));
        // Handle validations
        //CreateApiEndpoint(END_POINTS.LOGIN).post(name, password).then((response) => {console.log(response);}).catch((error) => console.log(error));
    };
    return (
        <form className='RegisterForm__LoginForm LoginForm' method='post' onSubmit={handleSubmit}>
            <h1>Login</h1>
            <div className='LoginForm__input-box'>
                <input
                    type='text'
                    placeholder='Username'
                    required
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                />
                <FaUser className='icon' />
            </div>
            <div className='LoginForm__input-box'>
                <input
                    type='password'
                    placeholder='Password'
                    required
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                />
                <FaLock className='icon' />
            </div>

            <div className='LoginForm__check-box'>
                <label>
                    <input type='checkbox' />
                    Remember Me
                </label>
                <a href='#!'>Forgot password?</a>
            </div>

            <button className='LoginForm__submit-btn' type='submit'>
                Login
            </button>

            <div className='LoginForm__link' onClick={registerLink}>
                <p>
                    Don't have an account? <a href='#!'>Register</a>
                </p>
            </div>
        </form>
    );
}

export default LoginForm;
