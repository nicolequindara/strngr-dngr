import Disclaimer from './components/Disclaimer';
import FetchData from './components/FetchData';
import Home from './components/Home';
import Layout from './components/Layout';
import PhotoUpload from './components/PhotoUpload';
import React from 'react';
import { Route } from 'react-router';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route exact path='/disclaimer' component={Disclaimer} />
    <Route exact path='/photos' component={PhotoUpload} />
    <Route path='/fetch-data/:startDateIndex?' component={FetchData} />
  </Layout>
);
