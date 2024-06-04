import axios from 'axios';

const BASE_URL = 'http://localhost:5286/api/';

export const END_POINTS = {
    //User CRUD
    LOGIN: 'User/login',
    REGISTER: 'User/register',
    CHANGEPASSWORD: 'User/changePassword',
    DELETEACCOUNT: 'User/deleteUser',

    //Profule
    GETPROFILE: 'Profile/getProfile',
};

export const CreateApiEndpoint = (endpoint) => {
    let url = BASE_URL + endpoint;

    return {
        login: (data) => axios.post(url, data),
        registration: (data) => axios.post(url, data),
        getProfile: (data) => axios.post(url, data),
        changePassword: (data) => axios.post(url, data),
        deleteAccount: (data) => axios.delete(url, (data = { data })),
    };
};
