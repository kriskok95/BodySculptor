import React, { useEffect } from 'react';
import { connect } from 'react-redux';

import Exercise from './Exercise/Exercise';
import Spinner from 'react-bootstrap/Spinner';
import Table from 'react-bootstrap/Table';
import Container from 'react-bootstrap/Container';

import * as actions from '../../store/actions/index';

const Exercises = props => {
    const { onFetchExercises } = props;

    useEffect(() => {
        onFetchExercises();
    }, [onFetchExercises]);

    let exercises = <Spinner animation="border" />;

    if (!props.loading) {
        exercises = <Table striped bordered hover>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Image</th>
                    <th>Main Muscle Group</th>
                    <th>Secondary Muscle Groups</th>
                </tr>
            </thead>
            <tbody>
                {props.exercises
                    .map(ex => <Exercise key={ex.id} exercise={ex} />)}
            </tbody>
        </Table>
    }

    return (
        <Container>
            <div>{exercises}</div>
        </Container>
    )
}

const mapStateToProps = state => {
    return {
        exercises: state.exercises.exercises,
        loading: state.exercises.loading,
    }
}

const mapDispatchToProps = dispatch => {
    return {
        onFetchExercises: () => dispatch(actions.fetchExercises()),
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(Exercises);