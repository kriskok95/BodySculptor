import * as actionTypes from '../actions/actionTypes';
import { updateObject } from '../../shared/utility';

const initialState = {
    articles: null,
    clientStatistics: null,
    loading: true,
}

const startFetchArticlesStatistics = (state, action) => {
    return updateObject(state, {
        loading: true,
    });
};

const setArticlesStatistics = (state, action) => {
    return updateObject(state, {
        articles: action.articles,
        clientStatistics: action.clientStatistics,
        loading: false,
    });
};

const reducer = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.START_FETCH_ARTICLES_STATISTICS: return startFetchArticlesStatistics(state, action);
        case actionTypes.SET_ARTICLES_STATISTICS: return setArticlesStatistics(state, action);
        default: return state;
    }
}

export default reducer;