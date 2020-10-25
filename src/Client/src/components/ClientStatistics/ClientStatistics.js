import React, { useEffect } from 'react';
import { connect } from 'react-redux';

import Jumbotron from 'react-bootstrap/Jumbotron';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Spinner from 'react-bootstrap/Spinner';

import * as actions from '../../store/actions/index';

const ClientStatistics = props => {
    const { onFetchArticlesStatistics } = props;

    useEffect(() => {
        onFetchArticlesStatistics();
    }, [onFetchArticlesStatistics]);

    let clientStatistics = <Spinner animation="border" />;

    if (!props.loading) {
        clientStatistics = <Jumbotron fluid>
            <Container>
                <Row className="justify-content-md-center mb-3">
                    <Col md="auto">
                        <h1>Welcome to BodySculptor! :)</h1>
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <p style={{fontSize: "20px"}}>
                            You can build your own training programs choosing between:
                            <strong>{props.clientStatistics.totalExercises}</strong> exercises, track your nutrition plan
                            choosing between: <strong>{props.clientStatistics.totalFoods}</strong> foods and gain some knowledge
                            by reading: <strong>{props.clientStatistics.totalArticles}</strong> articles.
                        </p>
                    </Col>
                </Row>
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