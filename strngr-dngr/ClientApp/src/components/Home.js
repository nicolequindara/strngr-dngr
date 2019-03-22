import "../styles/App.css"

import React from 'react';
import { connect } from 'react-redux';
import { default as logo } from '../img/stranger_danger.svg';

const Home = props => (
  <div 
    className="App"
   >
    <div className="App-header">
      <h1>Stranger Danger</h1>
      <img src={logo} className="App-logo" alt="logo" />
    </div>
  </div>
);

export default connect()(Home);
