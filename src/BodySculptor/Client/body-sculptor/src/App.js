import React, { Suspense } from "react";

import Layout from "./components/Layout/Layout";
import Routes from './components/Routes/Routes';
import "./App.css";

const app = (props) => {
  return (
    <Layout>
      <Suspense fallback={<p>Loading...</p>}>
        <Routes />
      </Suspense>
    </Layout>
  );
}

export default app;
