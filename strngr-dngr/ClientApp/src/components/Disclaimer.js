import "../styles/App.css"

import { Link } from "react-router"
import React from 'react';
import { connect } from 'react-redux';

const Disclaimer = props => {

  return(
    <div 
      className="App"
    >
      <div className="App-header">
        <h1>How does it work?</h1>
          <p>You give us as much information as you can about the stranger you want to investigate!</p>
          <p>We'll validate their photos and information.</p>
      </div>
    </div>
  );
}

export default connect()(Disclaimer);