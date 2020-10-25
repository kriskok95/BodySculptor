import * as actionTypes from './actionTypes';
import axios from '../../axiosExercises';

export const setExercises = (exercises) => {
    return {
        type: actionTypes.SET_EXERCISES,
        exercises: exercises,
    }
}

export const startFetchExercises = () => {
    return {
        type: actionTypes.START_FETCH_EXERCISES,
    }
}

export const fetchExercises = () => {
    return dispatch => {
        dispatch(startFetchExercises());
        axios.get('/api/exercises')
            .then(response => {
                dispatch(setExercises(response.data));
            })
            .catch(error => {
                console.log(error);
            });
    };
};