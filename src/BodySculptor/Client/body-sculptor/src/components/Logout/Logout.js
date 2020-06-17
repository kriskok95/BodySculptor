import React from 'react';
import { Redirect } from 'react-router-dom';
import { connect } from 'react-redux';

import { onLogout } from '../../store/actions/auth';

const logout = (props) => {
    props.onLogout();
    return <Redirect to="/" />
}

const mapDispatchToProps = dispatch => {
    return {
        onLogout: () => dispatch(onLogout())
    }
}

export default connect(null, mapDispatchToProps)(logout);