import axios from 'axios';

const instance = axios.create({
    baseURL: 'http://localhost:5008/'
});

export default instance;