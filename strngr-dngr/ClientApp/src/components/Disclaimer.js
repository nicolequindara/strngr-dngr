import "../styles/App.css"

import { Link } from "react-router-dom"
import React from 'react';
import { connect } from 'react-redux';

const Disclaimer = props => {

    return (
        <div className="App">
            <div className="App-header">
                <div style={{ display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center", height: "100%"}}>
                    <h1>FAQ</h1>
                    
                    <h4>How does it work?</h4>
                    <p>You give us as much information as you can about the stranger you want to investigate!</p>
                    <p>We'll validate their photos and data against publicly available data on the inter-webs, providing you with a Stranger Danger score to prepare you for your encounter.</p>

                    <Link to="photos">Let's start!</Link>
                </div>
            </div>
        </div>
    );
}

export default connect()(Disclaimer);