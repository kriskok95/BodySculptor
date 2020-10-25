import * as actionTypes from '../actions/actionTypes';
import { updateObject } from '../../shared/utility';

const initialState = {
    token: null,
    isAuth: false,
    username: null,
}

export const authSuccess = (state, action) => {
    return updateObject(state, {
        token: action.token,
        isAuth: true,
        username: action.username,
    });
};

export const onLogout = (state, action) => {
    return updateObject(state, {
        token: null,
        isAuth: false,
    });
};

export const isAuthenticated = (state, action) => {
    return updateObject(state, {
        token: action.token,
        isAuth: action.token ? true : false,
        username: action.username,
    })
}

const reducer = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.AUTH_SUCCESS: return authSuccess(state, action);
        case actionTypes.ON_LOGOUT: return onLogout(state, action);
        case actionTypes.IS_AUTHENTICATED: return isAuthenticated(state, action);
        default: return state;
    }
}

export default reducer;
