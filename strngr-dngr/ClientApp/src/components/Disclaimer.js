import "../styles/App.css"

import { default as Jeremy } from "../img/Jeremy.jpg";
import { Link } from "react-router-dom"
import { default as Nicole } from "../img/Nicole.jpg";
import React from 'react';
import { connect } from 'react-redux';

const Disclaimer = props => {

    return (
        <div className="App">
            <div className="App-header">
                <div className="flex-column">
                    <h1>FAQ</h1>

                    <div className="faq-section flex-column">
                        <h4>How does it work?</h4>
                        <p>You give us as much information as you can about the stranger you want to investigate!</p>
                        <p>We'll validate their photos and data against publicly available, open-source data, providing you with a Stranger Danger score to prepare you for your encounter.</p>
                    </div>   

                    <div className="faq-section flex-column">
                        <h4>Technology</h4>
                                                
                        <div>                            
                            <h6>Stack</h6>
                            <ul class="list-group">
                                <li class="list-group-item">ReactJS front-end</li>
                                <li class="list-group-item">.NET Core API</li>
                                <li class="list-group-item">Hosted on Azure</li>
                            </ul>
                        </div>

                        <div>
                            <h6>APIs</h6>
                            <ul class="list-group">
                                <a  class="list-group-item list-group-item-action" href="https://pro.whitepages.com/apis/">White Pages API for identity checking</a>
                                <a  class="list-group-item list-group-item-action"href="https://www.goodhire.com/api">Background Pages API for criminal offender checking</a>
                                <a  class="list-group-item list-group-item-action"href="https://azure.microsoft.com/en-us/services/cognitive-services/bing-image-search-api/">Bing Image Search API</a>
                            </ul>
                        </div>                
                    </div>

                    <div className="faq-section flex-column">
                        <h4>Team</h4>
                        <div className="flex-row">
                            <div className="flex-column profile">
                                <img src={Jeremy} className="float-left avatar" />
                                <h4>Jeremy Bradford</h4>
                                <h6>Software Engineer, Core API</h6>
                            </div>
                            <div className="flex-column profile">
                                <img src={Nicole} className="float-right avatar" />    
                                <h4>Nicole Quindara</h4>
                                <h6>Software Engineer, Match Affinity</h6>
                            </div>
                        </div>                        
                    </div>
                    <Link to="/photos" className="btn btn-primary">Let's start!</Link>
                </div>
            </div>
        </div>
    );
}

export default connect()(Disclaimer);