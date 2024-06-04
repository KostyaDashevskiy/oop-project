import React from 'react';
import Header from '../Header/Header';

function Home({ cookies }) {
    return (
        <>
            <Header cookies={cookies} />
            <div>Home page</div>
        </>
    );
}

export default Home;
