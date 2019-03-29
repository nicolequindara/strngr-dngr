import React from 'react';
import { Redirect } from "react-router-dom"
import { actionCreators } from '../store/Stranger';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { default as photoButton } from "../img/photo_button.png"

class PhotoUpload extends React.PureComponent {
    constructor(props) {
        super(props);
    }

    componentDidMount() {
        this.props.init();
    }

    handleChange = (files) => {
        this.props.addPhoto(files);
    }

    render() {

        if (this.props.photos) {
            // Successfully uploaded a photo
            return <Redirect to="/info" />;
        }

        return (
            <div className="App">
                <div className="App-header">
                    <h1>Upload Photos</h1>

                    <div>
                        <label htmlFor="photoUploadButton" style={{ cursor: "pointer" }}>
                            <img src={photoButton} className="App-logo" alt="logo" />
                        </label>

                        <input type="file"
                            multiple
                            style={{ display: "none" }}
                            id="photoUploadButton"
                            className="btn btn-primary"
                            onChange={(e) => this.handleChange(e.target.files)} />
                    </div>
                </div>
            </div>
        );
    }

}
export default connect(
    state => state.stranger,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(PhotoUpload);