import React, { useState } from 'react';
import Cookies from 'universal-cookie';
import { CreateApiEndpoint, END_POINTS } from '../../../api/';

function AdditionalInfo({ cookies }) {
    const [country, setcountry] = useState('');
    const [twitchLink, setTwitchLink] = useState();

    const [userName] = useState(cookies.get('name'));
    const [code, setCode] = useState('');
    const [message, setMessage] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();

        country !== undefined
            ? CreateApiEndpoint(END_POINTS.SETCOUNTRY)
                  .setCountry({
                      userName,
                      country,
                  })
                  .then((res) => {
                      setCode(res.data.code);
                      setMessage(res.data.message);
                  })
                  .catch((err) => console.log(err))
            : setMessage(message);
        twitchLink !== undefined
            ? CreateApiEndpoint(END_POINTS.SETTWITCH)
                  .setTwitch({
                      userName,
                      twitchLink,
                  })
                  .then((res) => {
                      console.log(res);
                      setCode(res.data.code);
                      setMessage(res.data.message);
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
        <form className='profile__AdditionalInfo AdditionalInfo' onSubmit={handleSubmit}>
            <div className='AdditionalInfo__Country'>
                <div className='AdditionalInfo__Country--label AdditionalInfo--label'>Country:</div>
                <select
                    className='AdditionalInfo__Country--data AdditionalInfo--data'
                    value={country}
                    onChange={(event) => {
                        setcountry(event.target.value);
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
            <div className='AdditionalInfo__Twitch'>
                <div className='AdditionalInfo__Twitch--label AdditionalInfo--label'>
                    Twitch link:
                </div>

                <input
                    className='AdditionalInfo__Twitch--data AdditionalInfo--data'
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
                className='AdditionalInfo__button'
                type='submit'
                disabled={country === '' && twitchLink === undefined ? true : ''}
            >
                Save
            </button>
        </form>
    );
}

export default AdditionalInfo;
