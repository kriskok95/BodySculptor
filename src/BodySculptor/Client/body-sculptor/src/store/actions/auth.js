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
                localStorage.setItem('token', response.data);
                dispatch(authSuccess(response.data, username))
            })
            .catch(function (error) {
                console.log(error);
            });
    };
};
