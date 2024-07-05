import axios from 'axios';

const BASE_URL = 'http://localhost:5286/api/';

export const END_POINTS = {
    //LoginRegisterPage
    LOGIN: 'User/login',
    REGISTER: 'User/register',

    //UserProfilePage
    GETPROFILE: 'Profile/getProfile?UserName=',
    SETCOUNTRY: 'Country/setCountry',
    SETTWITCH: 'Twitch/setTwitch',
    CHANGEPASSWORD: 'User/changePassword',
    DELETEACCOUNT: 'User/deleteUser',
};

export const CreateApiEndpoint = (endpoint: string) => {
    let url = BASE_URL + endpoint;

    return {
        login: (userName: string, password: string) => axios.post(url, { userName: userName, password: password }),

        registration: (userName: string, email: string, password: string, confirmPassword: string) =>
            axios.post(url, {
                userName: userName,
                email: email,
                password: password,
                confirmPassword: confirmPassword,
            }),

        getProfile: (userName: string) => axios.get(url + userName),

        setCountry: (userName: string, country: string) => axios.patch(url, { userName: userName, country: country }),

        setTwitch: (userName: string, twitchLink: string) => axios.patch(url, { userName: userName, twitchLink: twitchLink }),

        changePassword: (userName: string, oldPassword: string, newPassword: string) =>
            axios.patch(url, {
                userName: userName,
                oldPassword: oldPassword,
                newPassword: newPassword,
            }),
        deleteAccount: (userName: string, password: string) => axios.delete(url, { data: { userName: userName, password: password } }),
    };
};
