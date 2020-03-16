import React from 'react';
import { Route } from 'react-router-dom';
import './App.css';
import HomePage from './components/Home/HomePage';
import LoginPage from './components/Login/LoginPage';
import RegisterPage from './components/Register/RegisterPage';
import Profile from './components/Pofile/Profile';
import DetailsPage from './components/Details/DetailsPage';
import Employee from './components/Employee/Employee';
import ProfileContextProvider from './Context/PofileContext';
//import NavMenu from './components/Header/NavMenu';
//import Authenticated from './components/Authenticated/Authenticated';
import { Footer } from '../src/components';

function App() {
  return (
    <div className='App-div'>
        
        <Route path="/login" component={() => <LoginPage />}/>
        <Route path="/register" component={RegisterPage}/>
        
           {/* <Authenticated> */}
              {/* <NavMenu/> */}
            <ProfileContextProvider>
              <Route exact path="/" component={HomePage}/>
              <Route path="/details" component={DetailsPage}/>
              <Route path="/employee" component={Employee}/>
              <Route path="/profile" component={() => <Profile/>}/>
            </ProfileContextProvider>
           {/* </Authenticated>    */}
      <Footer/>
    </div>
  );
}

export default App;
