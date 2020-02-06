import React from 'react';
import { Route, Switch } from 'react-router-dom';
import './App.css';
import HomePage from './components/Home/HomePage';
import LoginPage from './components/Login/LoginPage';
import RegisterPage from './components/Register/RegisterPage';
import NavMenu from './components/Header/NavMenu';

function App() {
  return (
    <div>
      <NavMenu/>
      <Switch>
        <Route exact path='/' component={HomePage} />
        <Route path='/login' component={LoginPage}/>
        <Route path='/register' component={RegisterPage}/>
      </Switch>
    </div>
  );
}

export default App;
