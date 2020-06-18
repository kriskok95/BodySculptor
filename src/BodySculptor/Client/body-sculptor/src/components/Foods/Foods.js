import React, { useEffect } from 'react';
import { connect } from 'react-redux';

import Container from 'react-bootstrap/Container';

import Food from './Food/Food';
import * as actions from '../../store/actions/index';

const Foods = props => {
    const { onFetchFoods } = props;

    useEffect(() => {
        onFetchFoods();
    }, [onFetchFoods]);

    let foods = <p>Loading...</p>;

    if (!props.loading) {
        foods = props
            .foods
            .map(food => (
                <Food key={food.id} food={food} />
            ))
    };

    return (
        <Container>
            <div>{foods}</div>
        </Container>
    )
};

const mapStateToProps = state => {
    return {
        foods: state.foods.foods,
        loading: state.foods.loading,
    }
}

const mapDispatchToProps = dispatch => {
    return {
        onFetchFoods: () => dispatch(actions.fetchFoods()),
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(Foods);