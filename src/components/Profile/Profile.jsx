import { useState, useEffect } from 'react';
import '../../scss/app.scss';
import Cookies from 'universal-cookie';
import Header from '../Header/Header';
import NotAuth from '../NotAuth/NotAuth';
import BasicInfo from './ProfileTabs/BasicInfo';
import AdditionalInfo from './ProfileTabs/AdditionalInfo';
import ChangePassword from './ProfileTabs/ChangePassword';
import DeleteAccount from './ProfileTabs/DeleteAccount';
function Profile({ cookies }) {
    const [activeTab, setActiveTab] = useState('basicInfo');
    const [cookiesState, setCookiesState] = useState(cookies.get('name'));

    const handleTabChange = (tab) => {
        setActiveTab(tab);
    };

    return (
        <>
            {cookiesState === undefined ? (
                <NotAuth />
            ) : (
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
                                        activeTab === 'aditionalInfo' ? 'active' : ''
                                    }`}
                                    onClick={() => handleTabChange('aditionalInfo')}
                                >
                                    Aditional Info
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
                                    className={`sidebar__button sidebar__button--delite-account ${
                                        activeTab === 'deleteAccount' ? 'active' : ''
                                    }`}
                                    onClick={() => handleTabChange('deleteAccount')}
                                >
                                    Delete Account
                                </button>
                            </div>
                            <div className='Profile__content--wrapper'>
                                <div className='Profile__content'>
                                    {activeTab !== 'basicInfo' ? (
                                        <BasicInfo style={{ display: 'none' }} cookies={cookies} />
                                    ) : (
                                        <BasicInfo cookies={cookies} />
                                    )}
                                    {activeTab === 'aditionalInfo' && (
                                        <AdditionalInfo cookies={cookies} />
                                    )}
                                    {activeTab === 'changePassword' && (
                                        <ChangePassword
                                            cookies={cookies}
                                            setCookiesState={setCookiesState}
                                        />
                                    )}
                                    {activeTab === 'deleteAccount' && (
                                        <DeleteAccount
                                            cookies={cookies}
                                            setCookiesState={setCookiesState}
                                        />
                                    )}
                                </div>
                            </div>
                        </div>
                    </section>
                </>
            )}
        </>
    );
}

export default Profile;
