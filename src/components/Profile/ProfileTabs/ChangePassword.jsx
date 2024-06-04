import { useState } from 'react';
import { CreateApiEndpoint, END_POINTS } from '../../../api';
import Cookies from 'universal-cookie';

const ChangePassword = ({ cookies }) => {
    const userName = cookies.get('name');
    const [oldPassword, setOldPassword] = useState('');
    const [newPassword, setNewPassword] = useState('');
    const [confirmNewPassword, setConfirmNewPassword] = useState('');

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
                setCode(res.data.flag);
                setMessage(res.data.message);
                if (code === 200) {
                    cookies.remove('name');
                    cookies.remove('jwt_token');
                }
            })
            .catch((err) => console.log(err));

        //Подчищаем следы
        setOldPassword('');
        setNewPassword('');
        setConfirmNewPassword('');
    };

    return (
        <form className='Profile__ChangePassword ChangePassword' onSubmit={handleSubmit}>
            <div className='ChangePassword__OldPassword'>
                <div className='ChangePassword__OldPassword--label ChangePassword--label'>
                    Old password:
                </div>
                <input
                    className='ChangePassword__UserName--data ChangePassword--data'
                    type='password'
                    placeholder='Password'
                    pattern='^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{6,}$'
                    minLength='6'
                    value={oldPassword}
                    onChange={(e) => setOldPassword(e.target.value)}
                    required
                />
            </div>
            <div className='ChangePassword__NewPassword'>
                <div className='ChangePassword__NewPassword--label ChangePassword--label'>
                    New password:
                </div>

                <input
                    className='ChangePassword__NewPassword--data ChangePassword--data'
                    type='password'
                    placeholder='New password'
                    pattern='^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{6,}$'
                    minLength='6'
                    value={newPassword}
                    onChange={(e) => setNewPassword(e.target.value)}
                    required
                />
            </div>
            <div className='ChangePassword__ConfirmNewPassword'>
                <div className='ChangePassword__ConfirmNewPassword--label ChangePassword--label'>
                    Confirm new password:
                </div>
                <input
                    className='ChangePassword__ConfirmNewPassword--data ChangePassword--data'
                    type='password'
                    placeholder='Confirm new password'
                    pattern='^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{6,}$'
                    minLength='6'
                    value={confirmNewPassword}
                    style={{ border: newPassword !== confirmNewPassword ? '2px solid red' : '' }}
                    onChange={(e) => setConfirmNewPassword(e.target.value)}
                    required
                />
            </div>
            {code && <p>{message}</p>}
            <button
                className='ChangePassword__button'
                type='submit'
                disabled={
                    oldPassword === '' ||
                    newPassword === '' ||
                    confirmNewPassword === '' ||
                    newPassword !== confirmNewPassword
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
