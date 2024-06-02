function BasicInfo() {
    return (
        <section className='Profile__BasicInfo BasicInfo'>
            <div className='BasicInfo__UserName'>
                <div className='BasicInfo__UserName--label BasicInfo--label'>Username:</div>
                <div className='BasicInfo__UserName--data BasicInfo--data'>placeholder</div>
            </div>
            <div className='BasicInfo__UserEmail'>
                <div className='BasicInfo__UserEmail--label BasicInfo--label'>Email:</div>
                <div className='BasicInfo__UserEmail--data BasicInfo--data'>placeholder</div>
            </div>
            <div className='BasicInfo__UserRating'>
                <div className='BasicInfo__rating--label BasicInfo--label'>Rating:</div>
                <div className='BasicInfo__rating--data BasicInfo--data'>30 000</div>
            </div>
            <div className='BasicInfo__UserWins'>
                <div className='BasicInfo__wins--label BasicInfo--label'>Wins:</div>
                <div className='BasicInfo__wins--data BasicInfo--data'>150</div>
            </div>
        </section>
    );
}

export default BasicInfo;
