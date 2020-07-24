import * as actionTypes from '../actions/actionTypes';
import { updateObject } from '../../shared/utility';

const initialState = {
    exercises: null,
    loading: true,
}

const startFetchExercises = (state, action) => {
    return updateObject(state, {
        loading: true,
    });
};

const setExercises = (state, action) => {
    return updateObject(state, {
        exercises: action.exercises,
        loading: false,
    });
};

const reducer = (state = initialState, action) => {
    switch(action.type){
        case actionTypes.START_FETCH_EXERCISES: return startFetchExercises(state, action);
        case actionTypes.SET_EXERCISES: return setExercises(state, action);
        default: return state;
    }
}

export default reducer;