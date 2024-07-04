import { useState } from 'react';
import { Link } from 'react-router-dom';
import Header from '../Header/Header';
import NotAuth from '../NotAuth/NotAuth';
import '../../scss/app.scss';

function Home({ cookies }) {
    const [cookiesState] = useState(cookies.get('name'));
    return (
        <>
            {cookiesState === undefined ? (
                <NotAuth />
            ) : (
                <>
                    <Header cookies={cookies} />
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
