import React, { useEffect } from 'react';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom'

import DailyMenu from './DailyMenu/DailyMenu';
import Spinner from 'react-bootstrap/Spinner';
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';

import * as actions from '../../store/actions/index';

const DailyMenus = props => {
    const { onFetchDailyMenus } = props;

    useEffect(() => {
        onFetchDailyMenus();
    }, [onFetchDailyMenus]);

    let dailyMenus = <Spinner animation="border" />;

    if (props.loading === false) {
        dailyMenus = props.dailyMenus
            .map(dm => <DailyMenu key={dm.id} dailyMenu={dm} />)
    };

    return (
        <Container>
            <Link to="/createDailyMenu">
                <Button variant="primary" size="lg" className="mb-3">Create new</Button>
            </Link>
            <div>{dailyMenus}</div>
        </Container>
    )
}

const mapStateToProps = state => {
    return {
        dailyMenus: state.dailymenus.dailyMenus,
        loading: state.dailymenus.loading,
    }
}

const mapDispatchToProps = dispatch => {
    return {
        onFetchDailyMenus: () => dispatch(actions.fetchDailyMenus()),
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(DailyMenus);