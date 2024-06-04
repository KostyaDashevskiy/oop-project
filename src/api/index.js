import axios from 'axios';

const BASE_URL = 'http://localhost:5286/api/User/';

export const END_POINTS = {
    LOGIN: 'login',
    REGISTER: 'register',
    CHANGEPASSWORD: 'changePassword',
    DELITE: 'deliteUser',
};

export const CreateApiEndpoint = (endpoint) => {
    let url = BASE_URL + endpoint;

    return {
        login: (data) => axios.post(url, data),
        registration: (data) => axios.post(url, data),
        changePassword: (data) => axios.post(url, data),
        deliteAccount: (data) => axios.delete(url, data),
    };
};
