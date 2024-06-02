import { useState } from 'react';
import { FaUser, FaLock } from 'react-icons/fa6';
import { CreateApiEndpoint, END_POINTS } from '../../api';

function LoginForm({ registerLink }) {
    const [name, setName] = useState('');
    const [password, setPassword] = useState('');
    const [message, setMessage] = useState('');
    const [code, setCode] = useState('');
    const handleSubmit = (e) => {
        // Prevent the default submit and page reload
        e.preventDefault();

        CreateApiEndpoint(END_POINTS.LOGIN)
            .login({ name, password })
            .then((res) => {
                setMessage(res.data.message);
                setCode(res.status);
            })
            .catch((err) => console.log(err));
    };
    return (
        <form
            className='loginRegisterPage__LoginForm LoginForm'
            method='post'
            onSubmit={handleSubmit}
        >
            <h1>Login</h1>
            <div className='LoginForm__input-box'>
                <input
                    type='text'
                    placeholder='Username'
                    minLength='8'
                    required
                    pattern='^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{8,20}$'
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
                    pattern='^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{6,}$'
                    minLength='6'
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                />
                <FaLock className='icon' />
            </div>

            <div className='LoginForm__check-box' style={{ display: 'none' }}>
                <label>
                    <input type='checkbox' />
                    Remember Me
                </label>
                <a href='#!'>Forgot password?</a>
            </div>

            <div
                className={'LoginForm__response' + (code !== '' ? ' code--' + code : '')}
                style={{ display: code === '' ? 'none' : 'flex' }}
            >
                <p>{message}</p>
            </div>

            <button
                className='LoginForm__submit-btn'
                type='submit'
                disabled={name === '' || password === '' ? true : ''}
            >
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
