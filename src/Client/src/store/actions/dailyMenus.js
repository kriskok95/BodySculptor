import * as actionTypes from './actionTypes';
import axios from '../../axiosNutrition';

export const setDailyMenus = (dailyMenus) => {
    return {
        type: actionTypes.SET_DAILY_MENUS,
        dailyMenus: dailyMenus,
    }
}

export const startFetchDailyMenus = () => {
    return {
        type: actionTypes.START_FETCH_DAILY_MENUS,
    }
}

export const fetchDailyMenus = () => {
    return dispatch => {
        dispatch(startFetchDailyMenus());
        var token = localStorage.getItem('token');
        if (token) {
            axios.get('/api/dailymenus', {
                headers: {
                    Authorization: 'Bearer ' + token //the token is a variable which holds the token
                }
            })
                .then(response => {
                    dispatch(setDailyMenus(response.data));
                })
                .catch(error => {
                    console.log(error);
                });
        }
    };
};