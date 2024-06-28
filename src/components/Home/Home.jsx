import { useState } from 'react';
import Cookies from 'universal-cookie';
import { Link } from 'react-router-dom';
import Header from '../Header/Header';
import NotAuth from '../NotAuth/NotAuth';
import '../../scss/app.scss';

function Home({ cookies }) {
    const [cookiesState, setCookiesState] = useState(cookies.get('name'));
    return (
        <>
            {cookiesState === undefined ? (
                <NotAuth />
            ) : (
                <>
                    <Header cookies={cookies} setCookiesState={setCookiesState} />
                    <section id='home'>
                        <div className='home__container'>
                            <Link to='/game' className='home__btn'>
                                Play
                            </Link>
                        </div>
                    </section>
                </>
            )}
        </>
    );
}

export default Home;
