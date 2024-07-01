import { useState } from 'react';
import { CreateApiEndpoint, END_POINTS } from '../../../api';

const DeleteAccount = ({ cookies, setCookiesState }) => {
    //переменные для отправки на бэк
    const userName = cookies.get('name');
    const [password, setPassword] = useState('');

    //переменные для ответа с бэка
    const [code, setCode] = useState();

    const handleSubmit = (e) => {
        e.preventDefault();

        CreateApiEndpoint(END_POINTS.DELETEACCOUNT)
            .deleteAccount({ userName, password })
            .then((res) => {
                setCode(res.data.code);
                if (res.data.code === 200) {
                    cookies.remove('jwt_token');
                    cookies.remove('name');
                    setCookiesState();
                }
            })
            .catch((err) => console.log(err));

        setPassword('');
    };

    return (
        <form className='profile__DeleteAccount DeleteAccount' onSubmit={handleSubmit}>
            <div className='DeleteAccount__Password profile__field'>
                <div className='DeleteAccount__Password--label DeleteAccount--label profile--label'>
                    Password:
                </div>
                <input
                    className='DeleteAccount__Password--data DeleteAccount--data profile--data'
                    type='password'
                    autoComplete='current-password'
                    placeholder='Password'
                    pattern='^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{6,}$'
                    minLength='6'
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    required
                />
            </div>

            <button
                className='DeleteAccount__button profile__button'
                type='submit'
                disabled={password === '' || password.length < 6 ? true : ''}
            >
                Delete
            </button>
        </form>
    );
};

export default DeleteAccount;
