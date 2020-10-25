import React, { useEffect } from 'react';
import { connect } from 'react-redux';

import Article from './Article/Article';
import Spinner from 'react-bootstrap/Spinner';

import Container from 'react-bootstrap/Container';

import * as actions from '../../store/actions/index';

const Articles = props => {
    const { onFetchArticlesStatistics } = props;

    useEffect(() => {
        onFetchArticlesStatistics();
    }, [onFetchArticlesStatistics])

    let articles = <Spinner animation="border" />;

    if (!props.loading) {
        console.log(props.articles)
        articles = props
            .articles
            .map(article => (
                <Article key={article.id} article={article} />
            ));
    };

    return (
        <Container>
            <div>{articles}</div>
        </Container>
    )
};

const mapStateToProps = state => {
    return {
        articles: state.articlesStatistics.articles,
        loading: state.articlesStatistics.loading,
    }
}

const mapDispatchToProps = dispatch => {
    return {
        onFetchArticlesStatistics: () => dispatch(actions.fetchArticlesStatistics()),
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(Articles);
