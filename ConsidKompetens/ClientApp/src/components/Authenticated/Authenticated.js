import React from 'react';
import { Redirect, Route } from 'react-router-dom';

 const Authenticated = ({component: Component, ...rest}) => (

 <Route
     {...rest}
     render={props => 
     localStorage.getItem('secret') ? (
         <Component {...props} />
     ):(
         <Redirect to={{
             pathname: '/login',
             state: {from: props.location}
         }}/>
     
     )}
 />
)

export default Authenticated;
