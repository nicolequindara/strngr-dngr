import Disclaimer from './components/Disclaimer';
import Home from './components/Home';
import Info from './components/Info';
import Layout from './components/Layout';
import Loading from './components/Loading';
import PhotoUpload from './components/PhotoUpload';
import React from 'react';
import { Route } from 'react-router';
import Summary from './components/Summary';
import  Test  from './components/Test';

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/disclaimer' component={Disclaimer} />
        <Route exact path='/photos' component={PhotoUpload} />
        <Route exact path='/info' component={Info} />
        <Route exact path='/loading' component={Loading} />
        <Route exact path='/summary' component={Summary} />
        <Route exact path='/test' component={Test} />
    </Layout>
);
