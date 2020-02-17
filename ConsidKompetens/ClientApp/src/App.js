import React from 'react';
import { Route, Switch } from 'react-router-dom';
import './App.css';
import HomePage from './components/Home/HomePage';
import LoginPage from './components/Login/LoginPage';
import RegisterPage from './components/Register/RegisterPage';
import UserPage from './components/Users/UserPage';
import DetailsPage from './components/Details/DetailsPage';
import NavMenu from './components/Header/NavMenu';
// import {getJwt} from '../src/Helper/jwt';
// import jwt_decode from 'jwt-decode';
import { Footer } from '../src/components';

function App() {

  //const [ loggedIn, setLoggedIn ] = useState(false);
  
  //  getUser = () => {
  //       const jwt = getJwt();
  //       if(jwt !== null){
  //         let user = jwt_decode(jwt);
  //         return user;
  //       }
  //       return undefined;
  //   }

    // handleLogout = () => {
    //   localStorage.removeItem('secret');
    //   setLoggedIn({ loggedIn: false});
    //   alert('Successfully logged out');
    // };

 

  return (
    <div>
      <NavMenu/>
      <Switch>
        <Route exact path="/" component={() => <HomePage/>}/>
        <Route path="/login" component={() => <LoginPage />}/>
        <Route path="/register" component={RegisterPage}/>
        <Route path="/user" component={() => <UserPage />}/>
        <Route path="/details" component={DetailsPage}/>
        {/* <Route exact path='/' loggedIn = {loggedIn} component={HomePage} />
        <Route path='/login' success={this.loginHandle} failed={this.loginFailed} loggedIn = {loggedIn}  component={LoginPage}/>
        <Route path='/register' component={RegisterPage}/>
        <Route path='/user' component={() => user= {this.getUser()} UserPage}/> */}
      </Switch>
      <Footer/>
    </div>
  );
}

export default App;
