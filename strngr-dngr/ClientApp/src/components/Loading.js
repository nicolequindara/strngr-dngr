import "../styles/App.css"

import React from 'react';
import { Redirect } from "react-router-dom";
import { actionCreators } from '../store/Stranger';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { default as logo } from '../img/stranger_danger.svg';

class Loading extends React.PureComponent {
    constructor(props) {
        super(props);
    }

    photosDone = () => !this.props.photos || (this.props.photos && this.props.processedPhotoResults);
    infoDone = () => !this.props.info || (this.props.info && this.props.identityCheckResults);

    render() {
        if(this.photosDone() && this.infoDone())
        {
            return <Redirect to="/summary" />
        }

        return (
            <div className="App" >
                <div className="App-header">
                <h1> Gathering Results </h1>
                <h3> Please wait...</h3>
                    <img src={logo} className="App-logo" alt="logo" />
                </div>  
            </div>
        );
    }
}
                
export default connect(
    state => state.stranger,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Loading);