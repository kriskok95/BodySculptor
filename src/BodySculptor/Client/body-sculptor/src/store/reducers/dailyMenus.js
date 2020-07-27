import * as actionTypes from '../actions/actionTypes';
import { updateObject } from '../../shared/utility';

const initialState = {
    dailyMenus: null,
    loading: true,
}

const startFetchDailyMenus = (state, action) => {
    return updateObject(state, {
        loading: true,
    });
};

const setDailyMenus = (state, action) => {
    return updateObject(state, {
        dailyMenus: action.dailyMenus,
        loading: false,
    });
};

const reducer = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.START_FETCH_DAILY_MENUS: return startFetchDailyMenus(state, action);
        case actionTypes.SET_DAILY_MENUS: return setDailyMenus(state, action);
        default: return state;
    }
}

export default reducer;