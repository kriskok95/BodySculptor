import React from 'react';
import { Switch, Route, Redirect } from 'react-router-dom';
import Login from '../Login/Login';

const routes = () => {
    return (
        <Switch>
            <Route path="/login" component={Login} />
            <Route path="/home" />
            <Route path="/exercises" />
            <Route path="/foods" />
            <Route path="/register" />
            <Redirect to="/" />
        </Switch>
    )
}

export default routes;
