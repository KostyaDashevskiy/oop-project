import { useState } from 'react';
import { CreateApiEndpoint, END_POINTS } from '../../api';
import { Navigate } from 'react-router-dom';
import Cookies from 'universal-cookie';
import { FaUser, FaLock } from 'react-icons/fa6';

function LoginForm({ registerLink, cookies }) {
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const [message, setMessage] = useState('');
    const [code, setCode] = useState();

    const navigate = () => {
        return <Navigate to='/home' />;
    };

    const handleSubmit = (e) => {
        // Prevent the default submit and page reload
        e.preventDefault();

        CreateApiEndpoint(END_POINTS.LOGIN)
            .login({ userName, password })
            .then((res) => {
                //создание локальных переменных
                setCode(res.data.code);
                setMessage(res.data.message);

                //создание кукисов
                cookies.set('jwt_token', res.data.token);
                cookies.set('name', userName);

                //подтираем следы вмешательства
                setUserName('');
                setPassword('');
            })
            .catch((err) => console.log(err));
    };

    return (
        <>
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
                        value={userName}
                        onChange={(e) => setUserName(e.target.value)}
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
                    className={'LoginForm__response' + (code !== undefined ? ' code--' + code : '')}
                    style={{ display: code !== undefined ? 'flex' : 'none' }}
                >
                    <p>{message}</p>
                </div>

                <button
                    className='LoginForm__submit-btn'
                    type='submit'
                    disabled={userName === '' || password === '' ? true : ''}
                >
                    Login
                </button>

                <div
                    className='LoginForm__link'
                    onClick={function () {
                        registerLink();
                        setCode();
                    }}
                >
                    <p>
                        Don't have an account? <a href='#!'>Register</a>
                    </p>
                </div>
            </form>
            <div>{code === 200 ? navigate() : ''}</div>
        </>
    );
}

export default LoginForm;
