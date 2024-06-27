import { Link } from 'react-router-dom';
import '../../scss/app.scss';

function NotAuth() {
    return (
        <section id='notnuth'>
            <div class='notnuth'>
                <div class='notnuth__content'>
                    <h1>
                        4<span></span>4
                    </h1>
                </div>
                <h2>Oops! You are not authorized</h2>
                <p>
                    Sorry but you are not authorized. You can log in by clicking the button below.
                </p>
                <Link to='/'>Log In / Registration</Link>
            </div>
        </section>
    );
}

export default NotAuth;
