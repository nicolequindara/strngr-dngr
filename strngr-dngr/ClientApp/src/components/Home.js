import "../styles/App.css"

import { Link } from "react-router-dom"
import React from 'react';
import { connect } from 'react-redux';
import { default as logo } from '../img/stranger_danger.svg';

const Home = props => {
  return(
    <div 
      className="App"
    >
      <div className="App-header">
        <h1>Stranger Danger</h1>
          <Link to="/photos">
            <img src={logo} className="App-logo" alt="logo" />
          </Link>
      </div>
    </div>
  );
}

export default connect()(Home);