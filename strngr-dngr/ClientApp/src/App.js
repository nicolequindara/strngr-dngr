import Disclaimer from './components/Disclaimer';
import Home from './components/Home';
import Layout from './components/Layout';
import React from 'react';
import { Route } from 'react-router';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route exact path='/disclaimer' component={Disclaimer} />
  </Layout>
);
