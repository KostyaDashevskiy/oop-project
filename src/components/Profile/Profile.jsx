import { useState } from 'react';
import './Profile.css';
import Header from '../Header/Header';
import BasicInfo from './ProfileTabs/BasicInfo';
import ChangePassword from './ProfileTabs/ChangePassword';
import DeleteAccount from './ProfileTabs/DeleteAccount';
function Profile({ cookies }) {
    const [activeTab, setActiveTab] = useState('basicInfo');

    const handleTabChange = (tab) => {
        setActiveTab(tab);
    };

    return (
        <>
            <Header cookies={cookies} />
            <section className='Profile'>
                <div className='Profile__container'>
                    <div className='Profile__sidebar sidebar'>
                        <button
                            className={`sidebar__button ${
                                activeTab === 'basicInfo' ? 'active' : ''
                            }`}
                            onClick={() => handleTabChange('basicInfo')}
                        >
                            Basic Information
                        </button>
                        <button
                            className={`sidebar__button ${
                                activeTab === 'changePassword' ? 'active' : ''
                            }`}
                            onClick={() => handleTabChange('changePassword')}
                        >
                            Change Password
                        </button>
                        <button
                            className='sidebar__button sidebar__button--delite-account'
                            onClick={() => handleTabChange('deleteAccount')}
                        >
                            Delite Account
                        </button>
                    </div>
                    <div className='Profile__content--wrapper'>
                        <div className='Profile__content'>
                            {activeTab === 'basicInfo' && <BasicInfo cookies={cookies} />}
                            {activeTab === 'changePassword' && <ChangePassword cookies={cookies} />}
                            {activeTab === 'deleteAccount' && <DeleteAccount cookies={cookies} />}
                        </div>
                    </div>
                </div>
            </section>
        </>
    );
}

export default Profile;
