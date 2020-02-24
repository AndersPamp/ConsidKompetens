import React from 'react';
import { Route, Switch } from 'react-router-dom';
import './App.css';
import HomePage from './components/Home/HomePage';
import LoginPage from './components/Login/LoginPage';
import RegisterPage from './components/Register/RegisterPage';
import UserPage from './components/Users/UserPage';
import DetailsPage from './components/Details/DetailsPage';
import NavMenu from './components/Header/NavMenu';
import Authenticated from './components/Authenticated/Authenticated';
// import {getJwt} from '../src/Helper/jwt';
// import jwt_decode from 'jwt-decode';
import { Footer } from '../src/components';

function App() {


  return (
    <div className='App-div'>
        
        <Route path="/login" component={() => <LoginPage />}/>
        <Route path="/register" component={RegisterPage}/>
        
           {/* <Authenticated> */}
              {/* <NavMenu/> */}
            <Route exact path="/" component={HomePage}/>
            <Route path="/details" component={DetailsPage}/>
            <Route path="/user" component={() => <UserPage/>}/>
           {/* </Authenticated> */}   
      <Footer/>
    </div>
  );
}

export default App;
