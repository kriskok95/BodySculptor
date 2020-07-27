import React, { useEffect } from 'react';
import { connect } from 'react-redux';

import DailyMenu from './DailyMenu/DailyMenu';
import Spinner from 'react-bootstrap/Spinner';
import Container from 'react-bootstrap/Container';

import * as actions from '../../store/actions/index';

const DailyMenus = props => {
    const { onFetchDailyMenus } = props;

    useEffect(() => {
        onFetchDailyMenus();
    }, [onFetchDailyMenus]);

    let dailyMenus = <Spinner animation="border" />;

    if (props.loading === false) {
        dailyMenus = props.dailyMenus
        .map(dm => <DailyMenu key={dm.id} dailyMenu={dm}/>)
    };

    return (
        <Container>
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