import "../styles/App.css"

import React from 'react';
import _ from "lodash";
import { actionCreators } from '../store/Stranger';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

class Summary extends React.PureComponent {
  constructor(props) {
    super(props);
  }    
  
    render() {              
      const {info, reverseImageSearchResults, processedPhotoResults, identityCheckResults, offenderLookupResults, photos} = this.props;

      console.log("Summary.props", this.props);
      
      return(             
        <div className="App">
          <div className="App-header">
            <h1>Summary</h1>
                  {photos ? <PhotoSummary processedPhotoResults={processedPhotoResults} photos={photos} /> : <React.Fragment />}
                  {info ? <React.Fragment>
                      <IdentityCheckSummary info={info} identityCheckResults={identityCheckResults} /> 
                      <CriminalCheckSummary info={info} offenderLookupResults={offenderLookupResults} />
                    </React.Fragment>
                    : <React.Fragment />}
          </div>
        </div>
      );
    }
}

const PhotoSummary = (props) => {
  const { processedPhotoResults, photos } = props;

  const getImgThumbnail = (result) => result.tags[0].actions[0].data && result.tags[0].actions[0].data.value && result.tags[0].actions[0].data.value.length > 0 && result.tags[0].actions[0].data.value[0].thumbnailUrl;
  
  const getReferencedPages = (result) => 
  {
    var pagesIncluding = _.find(result.tags[0].actions, {actionType: "PagesIncluding"})
    if(pagesIncluding) return pagesIncluding.data.value;
    else return [];
  }
  
    return (
        <div className="box">
          <div className="header">Photo Image Knowledge</div>
          {
            processedPhotoResults.map((results, index) => {           

            if(getImgThumbnail(results))
            {
              return (                
              <div key={results.image.imageInsightsToken} className="body">                
                  <img src={getImgThumbnail(results)} style={{maxWidth:"50%"}} />

                  This image was found in the following places:                
                  {
                    getReferencedPages(results).map(x => {
                    return <a key={x.imageInsightsToken} style={{display: "block"}} href={x.hostPageUrl}>{x.hostPageUrl}</a>
                  })}
              </div>);
            }
            else return <div><b>Did not</b> find any other instances of the uploaded image on the internet!</div>;

            })
          }
            
    </div>
    );
}

const CriminalCheckSummary = (props) => {
  const {info, offenderLookupResults } = props;
  
  return (
    <div className="box">
      <div className="header">Offender Lookup</div>
      <div className="body">
          {offenderLookupResults.firstname}{offenderLookupResults.lastname ? ` ${offenderLookupResults.lastname}` : ""}, born {offenderLookupResults.birth_year} committed the following crime: {offenderLookupResults.crime_description}.  This crime occurred in {offenderLookupResults.city}, {offenderLookupResults.state}.
      </div>
    </div>
  )
}

const IdentityCheckSummary = (props) => {
    const { 
      info,
      identityCheckResults : {
        primary_address_checks, primary_phone_checks, primary_email_address_checks, identity_check_score
      }
    } = props;

    const matchFound = (matchToName) => props.identityCheckResults.primary_address_checks.match_to_name === "Match";

    return (
        <div className="box">
            <div className="header">Identity Check</div>
            <div className="body">
                <div className="section">
                    <div className="header">Address</div>
                    <div className="body">
                        The address provided by {info.name} is a <b>{primary_address_checks.is_valid ? "valid" : "invalid"}</b> address.
    
                    We <b>{matchFound(primary_address_checks.match_to_name) ? "found" : "did not find"} a match</b> for this stranger to the address provided at {info.street_line_1} in {info.city}, {info.state_code} {info.postal_code}.
                    {primary_address_checks.resident && `  The address ${matchFound(primary_address_checks.match_to_name) ? "indeed" : ""} belongs to ${primary_address_checks.resident.name}${primary_address_checks.resident.age_range ? `, aged between ${primary_address_checks.resident.age_range.from} and ${primary_address_checks.resident.age_range.to}.` : ""}`}

                    </div>
                </div>

                <div className="section">
                    <div className="header">Phone</div>
                    <div className="body">
                        The phone number provided by {info.name} is probably <b>{primary_phone_checks.is_valid ? "valid" : "invalid"}</b>.  It is registered under the carrier {primary_phone_checks.carrier}.
    
                    We <b>{matchFound(primary_phone_checks.match_to_address || primary_phone_checks.match_to_name) ? "found" : "did not find"} a match</b> for the number provided by this stranger at {info.phone}.
                    {primary_address_checks.subscriber && `The phone number ${matchFound(primary_phone_checks.match_to_name) ? "indeed" : ""} belongs to ${primary_phone_checks.subscriber.name}${primary_phone_checks.age_range && `, aged between ${primary_phone_checks.age_range.from} and ${primary_phone_checks.age_range.to}.`}`}
                    </div>
                </div>


                <div className="section">
                    <div className="header">Email</div>
                    <div className="body">
                    The email provided by {info.name} is probably <b>{primary_email_address_checks.is_valid ? "valid" : "invalid"}</b>.  
                    It was created {primary_email_address_checks.email_first_seen_days} days ago and was{primary_email_address_checks.is_autogenerated ? " " : " not"} autogenerated and is{primary_email_address_checks.is_disposable ? " " : " not"} disposable.
    
                    We <b>{matchFound(primary_email_address_checks.match_to_address || primary_email_address_checks.match_to_name) ? "found" : "did not find"} a match</b> for the email provided by this stranger at {info.email}.
                    {primary_address_checks.registered_owner && `The email ${matchFound(primary_email_address_checks.match_to_name) ? "indeed" : ""} belongs to ${primary_email_address_checks.registered_owner.name}`}
                    </div>
                </div>

                <h3>Overall Stranger Danger Score: {((identity_check_score / 5.0)).toFixed(2)}%</h3>
            </div>
        </div>         
        );
}
   
export default connect(
  state => state.stranger,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(Summary);