import React, { Component } from 'react';
import { withRouter } from 'react-router-dom';

class Authenticated extends Component {
    constructor(props) {
        super(props);

        this.state = {
            user: undefined
        };
    }

    componentDidMount() {
        const jwt = localStorage.getItem('secret');
        if (jwt) {
            this.props.history.push('/');
        }
    }

    render() {
        return (
            <div>
                {this.props.children}
            </div>
        );
    }
}

export default withRouter(Authenticated);