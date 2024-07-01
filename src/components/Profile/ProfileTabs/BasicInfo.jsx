import { useEffect, useState } from 'react';
import { CreateApiEndpoint, END_POINTS } from '../../../api/';

function BasicInfo({ cookies, style }) {
    //переменные для отправки на бэк
    const [userName] = useState(cookies.get('name'));

    //переменные для ответа с бэка
    const [email, setEmail] = useState();
    const [rating, setRating] = useState();
    const [wins, setWins] = useState();

    useEffect(() => {
        CreateApiEndpoint(END_POINTS.GETPROFILE)
            .getProfile({ userName })
            .then((res) => {
                setEmail(res.data.email);
                setRating(res.data.rating);
                setWins(res.data.wins);
            })
            .catch((err) => console.log(err));
    });
    return (
        <section className='profile__BasicInfo BasicInfo' style={style}>
            <div className='BasicInfo__UserName profile__field'>
                <div className='BasicInfo__UserName--label BasicInfo--label profile--label'>
                    Username:
                </div>
                <div className='BasicInfo__UserName--data BasicInfo--data profile--data'>
                    {userName !== undefined ? userName : 'Username'}
                </div>
            </div>
            <div className='BasicInfo__UserEmail profile__field'>
                <div className='BasicInfo__UserEmail--label BasicInfo--label profile--label'>
                    Email:
                </div>
                <div className='BasicInfo__UserEmail--data BasicInfo--data profile--data'>
                    {email !== undefined ? email : 'placeholder@placeholder'}
                </div>
            </div>
            <div className='BasicInfo__UserRating profile__field'>
                <div className='BasicInfo__rating--label BasicInfo--label profile--label'>
                    Rating:
                </div>
                <div className='BasicInfo__rating--data BasicInfo--data profile--data'>
                    {rating !== undefined ? rating : '0'}
                </div>
            </div>
            <div className='BasicInfo__UserWins'>
                <div className='BasicInfo__wins--label BasicInfo--label profile--label'>Wins:</div>
                <div className='BasicInfo__wins--data BasicInfo--data profile--data'>
                    {wins !== undefined ? wins : '0'}
                </div>
            </div>
        </section>
    );
}

export default BasicInfo;
