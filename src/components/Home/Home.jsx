import Cookies from 'universal-cookie';
import { Link } from 'react-router-dom';
import Header from '../Header/Header';
import NotAuth from '../NotAuth/NotAuth';
import './Home.css';

function Home({ cookies }) {
    return (
        <>
            {cookies.get('name') === undefined ? (
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
