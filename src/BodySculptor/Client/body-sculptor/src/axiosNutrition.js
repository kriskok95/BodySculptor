import axios from 'axios';

const instance = axios.create({
    baseURL: 'http://localhost:5006/',
});

export default instance;