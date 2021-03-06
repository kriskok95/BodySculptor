import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import * as serviceWorker from './serviceWorker';
import 'bootstrap/dist/css/bootstrap.min.css';
import { BrowserRouter } from 'react-router-dom';
import { createStore, compose, applyMiddleware, combineReducers } from 'redux';
import thunk from 'redux-thunk';
import { Provider } from 'react-redux';

import authReducer from './store/reducers/auth';
import foodsReducer from './store/reducers/foods';
import articlesStatisticsReducer from './store/reducers/articlesStatistics';
import exercisesReducer from './store/reducers/exercises';
import dailyMenusReducer from './store/reducers/dailyMenus';

const composeEnhancers = process.env.NODE_ENV === 'development'
  ? window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__
  || compose : null;

const rootReducer = combineReducers({
  auth: authReducer,
  foods: foodsReducer,
  articlesStatistics:  articlesStatisticsReducer,
  exercises: exercisesReducer,
  dailymenus: dailyMenusReducer,
})

const store = createStore(rootReducer, composeEnhancers(
  applyMiddleware(thunk)
));

const app = (
  <React.StrictMode>
    <Provider store={store}>
      <BrowserRouter>
        <App />
      </BrowserRouter>
    </Provider>
  </React.StrictMode>
);

ReactDOM.render(app, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
