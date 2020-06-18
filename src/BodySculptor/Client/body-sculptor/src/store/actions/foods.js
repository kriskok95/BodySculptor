import * as actionTypes from './actionTypes';
import axios from '../../axios';

export const setFoods = (foods) => {
    return {
        type: actionTypes.SET_FOODS,
        foods: foods,
    }
}

export const startFetchFoods = () => {
    return {
        type: actionTypes.START_FETCH_FOODS,
    }
}

export const fetchFoods = () => {
    return dispatch => {
        dispatch(startFetchFoods());
        axios.get('/api/foods')
            .then(response => {
                dispatch(setFoods(response.data));
            })
            .catch(error => {
                console.log(error);
            });
    };
};