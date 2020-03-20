import React, {useState, useEffect} from 'react';
import { Route, Redirect } from 'react-router-dom';
import { UseAuth } from '../../Context/AuthContext';

const Authenticated = ({ component: Component, ...rest}) => {
    const isAuthenticated = UseAuth();
  

    return(
        <Route {...rest} render={(props) => (
            isAuthenticated ? (
                 <Component {...props} />
            ) : (<Redirect to='/login'/>)
           
            )}
        />
    );
}

export default Authenticated;

// import React, { Component } from 'react';
// import { withRouter } from 'react-router-dom';

// class Authenticated extends Component {
//     constructor(props) {
//         super(props);

//         this.state = {
//             user: undefined
//         };
//     }

//     componentDidMount() {
//         const jwt = localStorage.getItem('secret');
//         if (jwt) {
//             this.props.history.push('/');
//         }
//     }

//     render() {
//         return (
//             <div>
//                 {this.props.children}
//             </div>
//         );
//     }
// }

// export default withRouter(Authenticated);