import { FaUser } from 'react-icons/fa6';

function BasicInfo() {
    return (
        <section className='Profile__BasicInfo BasicInfo'>
            <div className='BasicInfo__UserProfile'>
                <div className='BasicInfo__UserIcon'>
                    <FaUser />
                </div>
                <div className='BasicInfo__UserInfo'>
                    <div className='BasicInfo__UserName'>
                        <div className='BasicInfo__UserName--label'>Username:</div>
                        <div className='BasicInfo__UserName--data'>placeholder</div>
                    </div>
                    <div className='BasicInfo__UserEmail'>
                        <div className='BasicInfo__UserEmail--label'>Email:</div>
                        <div className='BasicInfo__UserEmail--data'>placeholder</div>
                    </div>
                </div>
            </div>
            <div className='BasicInfo__games'>
                <div className='BasicInfo__rating'>
                    <div className='BasicInfo__rating--label'>Rating:</div>
                    <div className='BasicInfo__rating--data'>30 000</div>
                </div>
                <div className='BasicInfo__wins'>
                    <div className='BasicInfo__wins--label'>Wins:</div>
                    <div className='BasicInfo__wins--data'>150</div>
                </div>
            </div>
        </section>
    );
}

export default BasicInfo;
