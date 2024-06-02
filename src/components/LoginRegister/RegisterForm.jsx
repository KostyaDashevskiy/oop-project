import { useState } from 'react';
import { FaUser, FaLock, FaEnvelope } from 'react-icons/fa6';
import { CreateApiEndpoint, END_POINTS } from '../../api';

function RegisterForm({ loginLink }) {
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [message, setMessage] = useState('');
    const [code, setCode] = useState('');
    const handleSubmit = (e) => {
        // Prevent the default submit and page reload
        e.preventDefault();

        CreateApiEndpoint(END_POINTS.REGISTER)
            .registration({ name, email, password, confirmPassword })
            .then((res) => {
                console.log(res.status, res.statusText);
                setMessage(res.data.message);
                setCode(res.status);
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
                        minLength='8'
                        value={name}
                        onChange={(e) => setName(e.target.value)}
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
                    className={'RegisterForm__response' + (code !== '' ? ' code--' + code : '')}
                    style={{ display: code !== 200 ? 'flex' : 'none' }}
                >
                    <p>{message}</p>
                </div>

                <button
                    className='RegisterForm__submit-btn'
                    type='submit'
                    disabled={
                        name === '' ||
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
                        <a href='#!' onClick={loginLink}>
                            Login
                        </a>
                    </p>
                </div>
            </form>
            <div
                className={'RegisterForm__response' + (code !== '' ? ' code--' + code : '')}
                style={{ display: code === 200 ? 'flex' : 'none' }}
            >
                <p>{message}</p>
            </div>
            <a
                href='#!'
                className='RegisterForm__response-link'
                style={{ display: code === 200 ? 'flex' : 'none' }}
                onClick={loginLink}
            >
                Login
            </a>
        </>
    );
}

export default RegisterForm;
