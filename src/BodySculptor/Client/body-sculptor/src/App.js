import React from "react";

import Layout from "./components/Layout/Layout";
import Routes from './components/Routes/Routes';
import "./App.css";

const app = (props) => {
  return (
    <Layout>
      <Routes />
    </Layout>
  );
}

export default app;
