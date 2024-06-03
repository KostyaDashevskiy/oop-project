import { useState } from 'react';
import './Profile.css';
import Header from '../Header/Header';
import BasicInfo from './ProfileTabs/BasicInfo';
import DeleteAccount from './ProfileTabs/DeleteAccount';
const Profile = () => {
    const [activeTab, setActiveTab] = useState('basicInfo');

    const handleTabChange = (tab) => {
        setActiveTab(tab);
    };

    const OtherInfo = () => {
        return (
            <div>
                <h2>Other Information</h2>
                <p>This is the other information component.</p>
            </div>
        );
    };

    return (
        <>
            <Header />
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
                                activeTab === 'otherInfo' ? 'active' : ''
                            }`}
                            onClick={() => handleTabChange('otherInfo')}
                        >
                            Other Information
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
                            {activeTab === 'basicInfo' && <BasicInfo />}
                            {activeTab === 'otherInfo' && <OtherInfo />}
                            {activeTab === 'deleteAccount' && <DeleteAccount />}
                        </div>
                    </div>
                </div>
            </section>
        </>
    );
};

export default Profile;
