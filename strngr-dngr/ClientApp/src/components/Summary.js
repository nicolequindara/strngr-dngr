import "../styles/App.css"

import React from 'react';
import { actionCreators } from '../store/Stranger';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

const Summary = props => {
  const { processedPhotoResults, reverseImageSearchResults, identityCheckResults } = props;
  return(
    <div className="App">
      <div className="App-header">
        <h1>Summary</h1>
        <h3>Valid Address? {identityCheckResults.primary_address_checks.is_valid ? "true" : "false"}</h3>
        <h3>Identity Score: {identityCheckResults.identity_check_score / 500 * 100}%</h3>
      </div>
    </div>
  );
}
   
export default connect(
  state => state.stranger,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(Summary);