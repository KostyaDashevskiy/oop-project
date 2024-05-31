import axios from 'axios';

const BASE_URL = 'http://localhost:5286/api/User/';
const WEATHERFORECAST_URL = 'http://localhost:5286/';

export const END_POINTS = {
    LOGIN: 'login',
    REGISTER: 'register',
    WEATHERFORECAST: 'WeatherForecast',
};

export const CreateApiEndpoint = (endpoint) => {
    let url = BASE_URL + endpoint;
    let WeatherForecast_url = WEATHERFORECAST_URL + endpoint;

    return {
        login: (data) => axios.post(url, data),
        registration: (data) => axios.post(url, data),
        weather: () => axios.get(WeatherForecast_url),

        fetchAll: () => axios.get(url),
        fetchById: () => axios.get(url),
        create: (newRecord) => axios.post(url, newRecord),
        update: (id, updatedRecord) => (url, updatedRecord),
        delite: (id) => axios.delite(url),
    };
};
