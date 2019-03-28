import React from 'react';
import { actionCreators } from '../store/Stranger';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

class Info extends React.PureComponent {

    constructor(props) {
        super(props);
        this.state = {
            name: "",
            street_line_1: "",
            street_line_2: "",
            city: "",
            state_code: "",
            postal_code: "",
            phone: "",
            email: ""
        }
    }

    onNameChange = (e) => {
        this.setState({ name: e.target.value });
    }

    onAddressLine1Change = (e) => {
        this.setState({ street_line_1: e.target.value });
    }

    onAddressLine2Change = (e) => {
        this.setState({ street_line_2: e.target.value });
    }

    onCityChange = (e) => {
        this.setState({ city: e.target.value });
    }

    onStateChange = (e) => {
        this.setState({ state: e.target.value });
    }

    onPostalCodeChange = (e) => {
        this.setState({ postal_code: e.target.value });
    }

    onPhoneChange = (e) => {
        this.setState({ phone: e.target.value });
    }    

    onEmailChange = (e) => {
        this.setState({ email: e.target.value });
    }

    onSubmit = (e) => {
        e.preventDefault();
        console.log("Info.state", this.state);
        this.props.addStrangerInfo(this.state);
    }

    render() {
        return (
            <div className="App">
                <div className="App-header">
                    <h1>Details</h1>
                    <form onSubmit={this.onSubmit}>
                        <div className="form-group">
                            <input className="form-control" type="text" name="Name" placeholder="Name" onChange={this.onNameChange} />
                            <input className="form-control" type="text" name="StreetLine1" placeholder="Address Line 1" onChange={this.onAddressLine1Change}/>
                            <input className="form-control" type="text" name="StreetLine2" placeholder="Address Line 2" onChange={this.onAddressLine2Change}/>                    
                            <input className="form-control" type="text" name="City" placeholder="City" onChange={this.onCityChange} />
                            <input className="form-control" type="text" name="StateCode" placeholder="State" onChange={this.onStateChange}/>
                            <input className="form-control" type="text" name="PostalCode" placeholder="Postal Code" onChange={this.onPostalCodeChange}/>                        
                            <input className="form-control" type="text" name="Phone" placeholder="Phone" onChange={this.onPhoneChange}/>
                            <input className="form-control" type="text" name="Email" placeholder="Email" onChange={this.onEmailChange} />
                            <input type="submit" className="btn btn-primary" value="Submit" />
                    </div>
                    </form>
                </div>

            </div>
        );
    }
}

export default connect(
    state => state.stranger,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Info);
