import React, { useEffect } from 'react';
import { connect } from 'react-redux';

import Jumbotron from 'react-bootstrap/Jumbotron';
import Container from 'react-bootstrap/Container';

import * as actions from '../../store/actions/index';

const ClientStatistics = props => {
    const { onFetchArticlesStatistics } = props;

    useEffect(() => {
        onFetchArticlesStatistics();
    }, [onFetchArticlesStatistics]);

    let clientStatistics = <p>Loading...</p>

    if (!props.loading) {
        clientStatistics = <Jumbotron fluid>
            <Container>
                <h1>Welcome to BodySculptor! :)</h1>
                <p>
                    You can build your own training programs choosing between:
            {props.clientStatistics.totalExercises} exercises, track your nutrition plan
            choosing between: {props.clientStatistics.totalFoods} foods and gain some knowledge
            by reading: {props.clientStatistics.totalArticles} articles.
          </p>
            </Container>
        </Jumbotron>
    };

    return (
        <Container>
            <div>{clientStatistics}</div>
        </Container>
    )
}

const mapStateToProps = state => {
    return {
        clientStatistics: state.articlesStatistics.clientStatistics,
        loading: state.articlesStatistics.loading,
    }
}

const mapDispatchToProps = dispatch => {
    return {
        onFetchArticlesStatistics: () => dispatch(actions.fetchArticlesStatistics()),
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(ClientStatistics);