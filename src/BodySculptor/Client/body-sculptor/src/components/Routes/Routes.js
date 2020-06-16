import React from 'react';
import { Switch, Route, Redirect } from 'react-router-dom';
import Login from '../Login/Login';
import Register from '../Register/Register';

const routes = () => {
    return (
        <Switch>
            <Route path="/home" />
            <Route path="/exercises" />
            <Route path="/foods" />
            <Route path="/register" component={Register} />
            <Route path="/login" component={Login} />
            <Redirect to="/" />
        </Switch>
    )
}

export default routes;
