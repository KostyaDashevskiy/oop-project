import { useState } from 'react';
import { FaUser, FaLock, FaEnvelope } from 'react-icons/fa6';
import { CreateApiEndpoint, END_POINTS } from '../../api';

function RegisterForm({ loginLink }) {
    //переменные для отправки на бэк
    const [userName, setUserName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');

    //переменные для ответа с бэка
    const [message, setMessage] = useState('');
    const [code, setCode] = useState();

    const handleSubmit = (e) => {
        // Prevent the default submit and page reload
        e.preventDefault();

        CreateApiEndpoint(END_POINTS.REGISTER)
            .registration(userName, email, password, confirmPassword)
            .then((res) => {
                setMessage(res.data.message);
                setCode(res.data.code);

                //подтираем следы вмешательства
                setUserName('');
                setEmail('');
                setPassword('');
                setConfirmPassword('');
            })
            .catch((err) => console.log(err));
    };

    return (
        <>
            <form
                className='loginRegisterPage__RegisterForm RegisterForm'
                method='post'
                onSubmit={(e) => handleSubmit(e)}
                style={{ display: code === 200 ? 'none' : 'block' }}
            >
                <h1>Registration</h1>
                <div className='RegisterForm__input-box'>
                    <input
                        type='text'
                        autoComplete='username'
                        placeholder='Username'
                        required
                        pattern='^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{8,20}$'
                        minLength='8'
                        value={userName}
                        onChange={(e) => setUserName(e.target.value)}
                    />
                    <FaUser className='icon' />
                </div>
                <div className='RegisterForm__input-box'>
                    <input
                        type='email'
                        autoComplete='email'
                        placeholder='Email'
                        required
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                    />
                    <FaEnvelope className='icon' />
                </div>
                <div className='RegisterForm__input-box'>
                    <input
                        type='password'
                        autoComplete='new-password'
                        placeholder='Password'
                        required
                        minLength='6'
                        pattern='^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{6,}$'
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                    <FaLock className='icon' />
                </div>
                <div className='RegisterForm__input-box'>
                    <input
                        type='password'
                        autoComplete='new-password'
                        placeholder='Confirm your password'
                        required
                        minLength='6'
                        pattern='^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{6,}$'
                        value={confirmPassword}
                        style={{ border: password !== confirmPassword ? '2px solid red' : '' }}
                        onChange={(e) => setConfirmPassword(e.target.value)}
                    />
                    <FaLock className='icon' />
                </div>

                {/* <div className='RegisterForm__check-box'>
                    <label>
                        <input type='checkbox required' />I agree to the terms & conditions 
                    </label>
                </div> */}

                <div
                    className={
                        'RegisterForm__response' + (code !== undefined ? ' code--' + code : '')
                    }
                    style={{ display: code !== undefined ? 'flex' : 'none' }}
                >
                    <p>{message}</p>
                </div>

                <button
                    className='RegisterForm__submit-btn'
                    type='submit'
                    disabled={
                        userName === '' ||
                        email === '' ||
                        password === '' ||
                        confirmPassword === '' ||
                        password !== confirmPassword
                            ? true
                            : ''
                    }
                >
                    Register
                </button>

                <div className='RegisterForm__link'>
                    <p>
                        Already have an account?
                        <a
                            href='#!'
                            onClick={() => {
                                loginLink(); //переход на страницу логина
                                setCode(); //исчезновение ошибки при регистрации
                            }}
                        >
                            Login
                        </a>
                    </p>
                </div>
            </form>
            <div
                className={'RegisterForm__response' + (code !== undefined ? ' code--' + code : '')}
                style={{ display: code === 200 ? 'flex' : 'none' }}
            >
                <p>{message}</p>
            </div>
            <a
                href='#!'
                className='RegisterForm__response-link'
                style={{ display: code === 200 ? 'flex' : 'none' }}
                onClick={() => {
                    loginLink(); //переход на страницу логина
                    setCode(); //исчезновение сообщения об ошибке регистрации
                }}
            >
                Login
            </a>
        </>
    );
}

export default RegisterForm;
