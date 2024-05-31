import { useState } from 'react';
import { FaUser, FaLock, FaEnvelope } from 'react-icons/fa6';
import { CreateApiEndpoint, END_POINTS } from '../../api';

function RegisterForm({ loginLink }) {
    const [name, setName] = useState();
    const [email, setEmail] = useState();
    const [password, setPassword] = useState();
    const [confirmPassword, setConfirmPassword] = useState();
    const handleSubmit = (e) => {
        // Prevent the default submit and page reload
        e.preventDefault();

        CreateApiEndpoint(END_POINTS.REGISTER)
            .login({ name, email, password, confirmPassword })
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
        <form
            className='loginRegisterPage__RegisterForm RegisterForm'
            method='post'
            onSubmit={handleSubmit}
        >
            <h1>Registration</h1>
            <div className='RegisterForm__input-box'>
                <input
                    type='text'
                    placeholder='Username'
                    required
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
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                />
                <FaLock className='icon' />
            </div>
            <div className='RegisterForm__input-box'>
                <input
                    type='password'
                    placeholder='Password'
                    required
                    value={confirmPassword}
                    onChange={(e) => setConfirmPassword(e.target.value)}
                />
                <FaLock className='icon' />
            </div>

            <div className='RegisterForm__check-box'>
                <label>
                    <input type='checkbox' required />I agree to the terms & conditions
                </label>
            </div>

            <button className='RegisterForm__submit-btn' type='submit'>
                Register
            </button>

            <div className='RegisterForm__link'>
                <p>
                    Already have an account?{' '}
                    <a href='#!' onClick={loginLink}>
                        Login
                    </a>
                </p>
            </div>
        </form>
    );
}

export default RegisterForm;
