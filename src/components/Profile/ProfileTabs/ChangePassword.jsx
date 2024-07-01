import { useState } from 'react';
import { CreateApiEndpoint, END_POINTS } from '../../../api';

const ChangePassword = ({ cookies, setCookiesState }) => {
    //переменные для отправки на бэк
    const userName = cookies.get('name');
    const [oldPassword, setOldPassword] = useState('');
    const [newPassword, setNewPassword] = useState('');
    const [confirmNewPassword, setConfirmNewPassword] = useState('');

    //переменные для ответа с бэка
    const [code, setCode] = useState();
    const [message, setMessage] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();

        CreateApiEndpoint(END_POINTS.CHANGEPASSWORD)
            .changePassword({
                userName,
                oldPassword,
                newPassword,
            })
            .then((res) => {
                setCode(res.data.code);
                setMessage(res.data.message);
                if (res.data.code === 200) {
                    cookies.remove('jwt_token');
                    cookies.remove('name');
                    setCookiesState();
                }
            })
            .catch((err) => console.log(err));

        //Подчищаем следы
        setOldPassword('');
        setNewPassword('');
        setConfirmNewPassword('');
    };

    return (
        <form className='profile__ChangePassword ChangePassword' onSubmit={(e) => handleSubmit(e)}>
            <div className='ChangePassword__OldPassword profile__field'>
                <div className='ChangePassword__OldPassword--label ChangePassword--label profile--label'>
                    Old password:
                </div>
                <input
                    className='ChangePassword__UserName--data ChangePassword--data profile--data'
                    type='password'
                    autoComplete='current-password'
                    placeholder='Password'
                    pattern='^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{6,}$'
                    minLength='6'
                    value={oldPassword}
                    onChange={(e) => setOldPassword(e.target.value)}
                    required
                />
            </div>
            <div className='ChangePassword__NewPassword profile__field'>
                <div className='ChangePassword__NewPassword--label ChangePassword--label profile--label'>
                    New password:
                </div>

                <input
                    className='ChangePassword__NewPassword--data ChangePassword--data profile--data'
                    type='password'
                    autoComplete='new-password'
                    placeholder='New password'
                    pattern='^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{6,}$'
                    minLength='6'
                    value={newPassword}
                    onChange={(e) => setNewPassword(e.target.value)}
                    required
                />
            </div>
            <div className='ChangePassword__ConfirmNewPassword profile__field'>
                <div className='ChangePassword__ConfirmNewPassword--label ChangePassword--label profile--label'>
                    Confirm new password:
                </div>
                <input
                    className='ChangePassword__ConfirmNewPassword--data ChangePassword--data profile--data'
                    type='password'
                    autoComplete='new-password'
                    placeholder='Confirm new password'
                    pattern='^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{6,}$'
                    minLength='6'
                    value={confirmNewPassword}
                    style={{ border: newPassword !== confirmNewPassword ? '2px solid red' : '' }}
                    onChange={(e) => setConfirmNewPassword(e.target.value)}
                    required
                />
            </div>
            {oldPassword === newPassword &&
                newPassword === confirmNewPassword &&
                oldPassword !== '' &&
                newPassword !== '' &&
                confirmNewPassword !== '' && (
                    <p>The new password cannot be the same as the old one</p>
                )}
            {code && <p>{message}</p>}
            <button
                className='ChangePassword__button profile__button'
                type='submit'
                disabled={
                    oldPassword === '' ||
                    newPassword === '' ||
                    confirmNewPassword === '' ||
                    newPassword !== confirmNewPassword ||
                    (oldPassword === newPassword && newPassword === confirmNewPassword)
                        ? true
                        : ''
                }
            >
                Save
            </button>
        </form>
    );
};

export default ChangePassword;
