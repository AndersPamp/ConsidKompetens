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
import { Footer } from '../src/components';
import Authenticated from './components/Authenticated/Authenticated';

function App() {

  

  return (
    <div className='App-div'>
        <Route path="/login" component={() => <LoginPage />}/>
        <Route path="/register" component={RegisterPage}/>
            <ProfileContextProvider>
              <Authenticated exact path="/" component={HomePage}/>
              <Authenticated path="/details" component={DetailsPage}/>
              <Authenticated path="/employee" component={Employee}/>
              <Authenticated path="/profile" component={() => <Profile/>}/>
            </ProfileContextProvider>
      <Footer/>
    </div>
  );
}

export default App;
