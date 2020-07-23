import * as actionTypes from './actionTypes';
import axios from '../../axiosGateway';

export const setArticlesStatistics = (articles, clientStatistics) => {
    return {
        type: actionTypes.SET_ARTICLES_STATISTICS,
        articles: articles,
        clientStatistics: clientStatistics
    }
}

export const startFetchArticlesStatistics = () => {
    return {
        type: actionTypes.START_FETCH_ARTICLES_STATISTICS,
    }
}

export const fetchArticlesStatistics = () => {
    return dispatch => {
        dispatch(startFetchArticlesStatistics());
        axios.get('/api/articlesstatistics')
            .then(response => {
                dispatch(setArticlesStatistics(response.data.articles, response.data.clientStatistics));
            })
            .catch(error => {
                console.log(error);
            });
    };
};