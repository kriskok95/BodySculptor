import React from 'react';
import { Switch, Route, Redirect } from 'react-router-dom';
import Login from '../Login/Login';
import Register from '../Register/Register';
import Logout from '../Logout/Logout';

const routes = () => {
    return (
        <Switch>
            <Route path="/home" />
            <Route path="/exercises" />
            <Route path="/foods" />
            <Route path="/register" component={Register} />
            <Route path="/login" component={Login} />
            <Route path="/logout" component={Logout} />
            <Redirect to="/" />
        </Switch>
    )
}

export default routes;
