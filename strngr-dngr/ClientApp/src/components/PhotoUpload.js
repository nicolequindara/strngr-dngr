import React from 'react';
import { actionCreators } from '../store/Stranger';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { default as photoButton } from "../img/photo_button.png"

const PhotoUpload = props => {

   const uploadPhotos = (e) => {
    props.addPhoto(e.files);
  }

  return(
  <div className="App">
    <div className="App-header">
      <h1>Upload Photos</h1>    

      <div>
        <label htmlFor="photoUploadButton">
        <img src={photoButton} className="App-logo" alt="logo" />
      </label>
      
      <input type="file" 
        style={{display: "none"}}
        id="photoUploadButton"
        className="btn btn-primary"
        onChange={e => {uploadPhotos(e.target.files)}} />  
      </div>
    </div>
  </div>
);

}
export default connect(
  state => state.stranger,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(PhotoUpload);