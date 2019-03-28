import React from 'react';
import { actionCreators } from '../store/Stranger';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

const Info = props => {

    return (
        <div className="App">
            <div className="App-header">
                <h1>Details</h1>
                <form>
                    <input className="form-control" type="text" placeholder="Name" />
                </form>
            </div>
        </div>
    );

}
export default connect(
    state => state.stranger,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Info);
