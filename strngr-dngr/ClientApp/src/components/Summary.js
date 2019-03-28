import "../styles/App.css"

import React from 'react';
import { actionCreators } from '../store/Stranger';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

class Summary extends React.PureComponent {
  constructor(props) {
    super(props);
  }

    matchFound = (matchToName) => this.props.identityCheckResults.primary_address_checks.match_to_name === "Match";
    
    render() {
        const { info, identityCheckResults } = this.props;
        const { primary_address_checks, primary_phone_checks, primary_email_checks, identity_check_score } = identityCheckResults;
      
      return(     

        <div className="App">
          <div className="App-header">
            <h1>Summary</h1>
            {/* <div className="box">
              <div className="header">Photo Image Knowledge</div>
              <div className="body">Some knowledge about the photo</div>
            </div> */}

            <div className="box">
              <div className="header">Identity Check</div>
              <div className="body">
                <div className="section">
                  <div className="header">Address</div>
                  <div className="body">
                    The address provided by {info.name} is a <b>{primary_address_checks.is_valid ? "valid" : "invalid"}</b> address.

                    We <b>{this.matchFound(primary_address_checks.match_to_name) ? "found" : "did not find"} a match</b> for this stranger to the address provided at {info.street_line_1} in {info.city}, {info.state_code} {info.postal_code}.
                    {primary_address_checks.resident && `  The address ${this.matchFound(primary_address_checks.match_to_name) ? "indeed" : ""} belongs to ${primary_address_checks.resident.name}${primary_address_checks.resident.age_range ? `, aged between ${primary_address_checks.resident.age_range.from} and ${primary_address_checks.resident.age_range.to}.`: ""}`}
                    
                  </div>
                </div>
                
                <div className="section">
                  <div className="header">Phone</div>
                  <div className="body">
                    The phone number provided by {info.name} is probably <b>{primary_phone_checks.is_valid ? "valid" : "invalid"}</b>.

                    We <b>{this.matchFound(primary_phone_checks.match_to_address || primary_phone_checks.match_to_name) ? "found" : "did not find"} a match</b> for the number provided by this stranger at {info.phone}.
                    {primary_address_checks.subscriber && `The phone number ${this.matchFound(primary_phone_checks.match_to_name) ? "indeed" : ""} belongs to ${primary_phone_checks.subscriber.name}${primary_phone_checks.age_range && `, aged between ${primary_phone_checks.age_range.from} and ${primary_phone_checks.age_range.to}.`}`}
                  </div>
                </div>

                
                <div className="section">
                  <div className="header">Email</div>
                  <div className="body"></div>
                </div>
                
                          <h3>Overall Stranger Danger Score: {(100 - (identity_check_score / 500 * 100)).toFixed(2)}%</h3>
              </div>
            </div>         
          </div>
        </div>
      );
    }
}
   
export default connect(
  state => state.stranger,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(Summary);