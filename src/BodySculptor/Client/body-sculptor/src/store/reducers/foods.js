import * as actionTypes from '../actions/actionTypes';
import { updateObject } from '../../shared/utility';

const initialState = {
    foods: null,
    loading: true,
}

const startFetchFoods = (state, action) => {
    return updateObject(state, {
        loading: true,
    });
};

const setFoods = (state, action) => {
    return updateObject(state, {
        foods: action.foods,
        loading: false,
    });
};

const reducer = (state = initialState, action) => {
    switch(action.type){
        case actionTypes.START_FETCH_FOODS: return startFetchFoods(state, action);
        case actionTypes.SET_FOODS: return setFoods(state, action);
        default: return state;
    }
}

export default reducer;