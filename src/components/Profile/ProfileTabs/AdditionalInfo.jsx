import { useState } from 'react';
import { CreateApiEndpoint, END_POINTS } from '../../../api/';

function AdditionalInfo({ cookies }) {
    const [userName] = useState(cookies.get('name'));

    //переменные для отправки на бэк
    const [country, setCountry] = useState('');
    const [twitchLink, setTwitchLink] = useState('');

    //переменные для ответа с бэка
    const [code, setCode] = useState('');
    const [message, setMessage] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();

        country !== ''
            ? CreateApiEndpoint(END_POINTS.SETCOUNTRY)
                  .setCountry(userName, country)
                  .then((res) => {
                      setCode(res.data.code);
                      setMessage(res.data.message);
                      setCountry('');
                  })
                  .catch((err) => console.log(err))
            : setMessage(message);
        twitchLink !== ''
            ? CreateApiEndpoint(END_POINTS.SETTWITCH)
                  .setTwitch(userName, twitchLink)
                  .then((res) => {
                      setCode(res.data.code);
                      setMessage(res.data.message);
                      setTwitchLink();
                  })
                  .catch((err) => console.log(err))
            : setMessage(message);
    };

    const countries = [
        'Россия',
        'Украина',
        'Беларусь',
        'Казахстан',
        'Грузия',
        'Армения',
        'Азербайджан',
        'Молдова',
        'Таджикистан',
        'Киргизия',
    ];

    return (
        <form className='profile__AdditionalInfo AdditionalInfo' onSubmit={(e) => handleSubmit(e)}>
            <div className='AdditionalInfo__Country profile__field'>
                <div className='AdditionalInfo__Country--label AdditionalInfo--label profile--label'>
                    Country:
                </div>
                <select
                    className='AdditionalInfo__Country--data AdditionalInfo--data profile--data'
                    value={country}
                    onChange={(event) => {
                        setCountry(event.target.value);
                        setCode('');
                    }}
                >
                    <option value=''>Выберите страну</option>
                    {countries.map((country) => (
                        <option key={country} value={country}>
                            {country}
                        </option>
                    ))}
                </select>
            </div>
            <div className='AdditionalInfo__Twitch profile__field'>
                <div className='AdditionalInfo__Twitch--label AdditionalInfo--label profile--label'>
                    Twitch link:
                </div>

                <input
                    className='AdditionalInfo__Twitch--data AdditionalInfo--data profile--data'
                    type='url'
                    value={twitchLink}
                    onChange={(event) => {
                        setTwitchLink(event.target.value);
                        setCode('');
                    }}
                    placeholder='twitch.tv/your_chanel'
                />
            </div>
            {code && <p>{message}</p>}

            <button
                className='AdditionalInfo__button profile__button'
                type='submit'
                disabled={country === '' && twitchLink === '' ? true : ''}
            >
                Save
            </button>
        </form>
    );
}

export default AdditionalInfo;
