import React from 'react';
import { connect } from 'react-redux';

const Home = props => (
  <div>
  <h1>Stranger Danger</h1>
  </div>
);

export default connect()(Home);
