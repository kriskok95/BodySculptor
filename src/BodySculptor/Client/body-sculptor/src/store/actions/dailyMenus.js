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
        axios.get('/api/dailymenus')
            .then(response => {
                dispatch(setDailyMenus(response.data));
            })
            .catch(error => {
                console.log(error);
            });
    };
};