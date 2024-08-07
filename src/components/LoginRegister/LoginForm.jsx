import { useState } from 'react';
import { CreateApiEndpoint, END_POINTS } from '../../api';
import { useNavigate } from 'react-router-dom';
import { FaUser, FaLock } from 'react-icons/fa6';

function LoginForm({ registerLink, cookies }) {
    //переменные для отправки на бэк
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');

    //переменные для ответа с бэка
    const [message, setMessage] = useState('');
    const [code, setCode] = useState();

    const navigate = useNavigate();
    const authorization = () => {
        navigate('/home');
    };

    const handleSubmit = (e) => {
        // Prevent the default submit and page reload
        e.preventDefault();

        CreateApiEndpoint(END_POINTS.LOGIN)
            .login(userName, password)
            .then((res) => {
                setCode(res.data.code);
                setMessage(res.data.message);

                //создание кукисов
                cookies.set('jwt_token', res.data.token);
                cookies.set('name', userName);

                //авторизация
                if (res.data.code === 200) authorization();

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
                onSubmit={(e) => handleSubmit(e)}
            >
                <h1>Login</h1>
                <div className='LoginForm__input-box'>
                    <input
                        type='text'
                        autoComplete='username'
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
                        autoComplete='current-password'
                        placeholder='Password'
                        required
                        pattern='^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{6,}$'
                        minLength='6'
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                    <FaLock className='icon' />
                </div>

                {/* <div className='LoginForm__check-box'>
                    <label>
                        <input type='checkbox' />
                        Remember Me
                    </label>
                    <a href='#!'>Forgot password?</a>
                </div> */}

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
                    onClick={() => {
                        registerLink(); //переход на страницу регистрации
                        setCode(); //исчезновение ошибки при логине
                    }}
                >
                    <p>
                        Don't have an account? <a href='#!'>Register</a>
                    </p>
                </div>
            </form>
        </>
    );
}

export default LoginForm;
