import { useState } from 'react';
import { FaUser, FaLock, FaEnvelope } from 'react-icons/fa6';
import { CreateApiEndpoint, END_POINTS } from '../../api';

function RegisterForm({ loginLink }) {
    const [userName, setUserName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');

    const [message, setMessage] = useState('');
    const [code, setCode] = useState();
    const handleSubmit = (e) => {
        // Prevent the default submit and page reload
        e.preventDefault();

        CreateApiEndpoint(END_POINTS.REGISTER)
            .registration({ userName, email, password, confirmPassword })
            .then((res) => {
                setMessage(res.data.message);
                setCode(res.data.code);

                //подтираем следы вмешательства
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
                onSubmit={handleSubmit}
                style={{ display: code === 200 ? 'none' : 'block' }}
            >
                <h1>Registration</h1>
                <div className='RegisterForm__input-box'>
                    <input
                        type='text'
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

                <div className='RegisterForm__check-box' style={{ display: 'none' }}>
                    <label>
                        <input type='checkbox' />I agree to the terms & conditions {/*required*/}
                    </label>
                </div>

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
                            onClick={function () {
                                loginLink();
                                setCode();
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
                onClick={function () {
                    loginLink();
                    setUserName('');
                    setEmail('');
                    setCode();
                }}
            >
                Login
            </a>
        </>
    );
}

export default RegisterForm;
