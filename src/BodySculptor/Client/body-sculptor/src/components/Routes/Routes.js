import React from 'react';
import { Switch, Route, Redirect } from 'react-router-dom';

import Login from '../Login/Login';
import Register from '../Register/Register';
import Logout from '../Logout/Logout';
import ClientStatistics from '../ClientStatistics/ClientStatistics';
import Articles from '../Articles/Articles';

const Foods = React.lazy(() => {
    return import('../Foods/Foods');
})

const Exercises = React.lazy(() => {
    return import('../Exercises/Exercises');
})

const DailyMenus = React.lazy(() => {
    return import('../DailyMenus/DailyMenus');
})

const routes = (props) => {
    return (
        <Switch>
            <Route path="/home" render={() =>
                <div>
                    <ClientStatistics />
                    <Articles />
                </div>
            } />
            <Route path="/exercises" render={() => <Exercises />} />
            <Route path="/foods" render={() => <Foods />} />
            <Route path="/dailymenus" render={() => <DailyMenus />} />
            <Route path="/register" component={Register} />
            <Route path="/login" component={Login} />
            <Route path="/logout" component={Logout} />
            <Redirect to="/" />
        </Switch>
    )
}

export default routes;
