import { useState } from 'react';
import { CreateApiEndpoint, END_POINTS } from '../../../api';
import Cookies from 'universal-cookie';

const DeleteAccount = ({ cookies }) => {
    const name = cookies.get('name');
    const [password, setPassword] = useState('');
    const [code, setCode] = useState();
    const [message, setMessage] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();

        CreateApiEndpoint(END_POINTS.DeleteAccount)
            .deliteAccount({ name, password })
            .then((res) => {
                setCode(res.data.code);
                setMessage(res.data.message);
                if (code === 200) {
                    cookies.remove('name');
                    cookies.remove('jwt_token');
                }
            });

        setPassword('');
    };

    return (
        <form className='Profile__DeleteAccount DeleteAccount' onSubmit={handleSubmit}>
            <div className='DeleteAccount__Password'>
                <div className='DeleteAccount__Password--label DeleteAccount--label'>Password:</div>
                <input
                    className='DeleteAccount__Password--data DeleteAccount--data'
                    type='password'
                    placeholder='Password'
                    pattern='^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{6,}$'
                    minLength='6'
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    required
                />
            </div>
            <button
                className='DeleteAccount__button'
                type='submit'
                disabled={password === '' || password.length < 6 ? true : ''}
            >
                Delite
            </button>
        </form>
    );
};

export default DeleteAccount;
