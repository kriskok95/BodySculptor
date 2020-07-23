import React from 'react';
import { Switch, Route, Redirect } from 'react-router-dom';

import Login from '../Login/Login';
import Register from '../Register/Register';
import Logout from '../Logout/Logout';
import ClientStatistics from '../ClientStatistics/ClientStatistics';

const Foods = React.lazy(() => {
    return import('../Foods/Foods');
})

const routes = (props) => {
    return (
        <Switch>
            <Route path="/home" render={() => <ClientStatistics />}/>
            <Route path="/exercises" />
            <Route path="/foods" render={() => <Foods />} />
            <Route path="/register" component={Register} />
            <Route path="/login" component={Login} />
            <Route path="/logout" component={Logout} />
            <Redirect to="/" />
        </Switch>
    )
}

export default routes;
