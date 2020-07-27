import axios from 'axios';

const instance = axios.create({
    baseURL: 'http://localhost:5006/',

});

var authToken = localStorage.getItem('token');
instance.defaults.headers.common['Authorization'] = `Bearer ${authToken}`;

export default instance;