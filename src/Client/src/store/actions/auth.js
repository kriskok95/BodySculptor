import * as actionTypes from './actionTypes';
import axios from '../../axios';

export const authSuccess = (token, username) => {
    return {
        type: actionTypes.AUTH_SUCCESS,
        token: token,
        username: username
    };
};

export const successRegister = () => {
    localStorage.removeItem('token');
    return {
        type: actionTypes.REGISTRATION_SUCCESS,
    }
}

export const onLogout = () => {
    localStorage.removeItem('token');
    localStorage.removeItem('username');
    return {
        type: actionTypes.ON_LOGOUT,
    }
}

export const onRegister = (username, email, password) => {
    return dispatch => {
        const authData = {
            username: username,
            email: email,
            password: password,
        }

        axios.post('api/identity/register', authData)
            .then(function (response) {
                dispatch(successRegister());
            })
            .catch(function (error) {
                console.log(error);
            });
    }
}

export const auth = (username, password) => {
    return dispatch => {
        const authData = {
            username: username,
            password: password,
        };

        axios.post('api/identity/login', authData)
            .then(function (response) {
                localStorage.setItem('token', response.data['token']);
                localStorage.setItem('username', username);
                dispatch(authSuccess(response.data['token'], username));
            })
            .catch(function (error) {
                console.log(error);
            });
    };
};

export const isAuthenticated = () => {
    var token = localStorage.getItem('token');
    var username = localStorage.getItem('username');
    return {
        type: actionTypes.IS_AUTHENTICATED,
        token: token,
        username: username,
    }
};
