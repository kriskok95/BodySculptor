import React, { Suspense, useEffect } from "react";
import { connect } from 'react-redux';

import Layout from "./components/Layout/Layout";
import Routes from './components/Routes/Routes';
import "./App.css";
import { isAuthenticated } from "./store/actions";

const App = (props) => {
  useEffect(() => {
    props.isAuthenticated();
  });

  return (
    <Layout>
      <Suspense fallback={<p>Loading...</p>}>
        <Routes />
      </Suspense>
    </Layout>
  );
}

const mapDispatchToProps = dispatch => {
  return {
    isAuthenticated: () => dispatch(isAuthenticated()),
  }
}

export default connect(null, mapDispatchToProps)(App);
