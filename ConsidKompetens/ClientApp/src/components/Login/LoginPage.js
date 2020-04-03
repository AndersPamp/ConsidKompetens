import React, {useState} from 'react';
import TextField from '@material-ui/core/TextField';
//import Grid from '@material-ui/core/Grid';
import { ThemeProvider, makeStyles, createMuiTheme} from '@material-ui/core/styles';
import { red } from '@material-ui/core/colors';
import '../../css/Login.css';
import LoginImage from '../../images/consid.woman.jpg';
import axios from 'axios/index';
import {Redirect} from "react-router-dom";

const useStyles = makeStyles(theme => ({
  root: {
    display: 'flex',
    flexWrap: 'wrap',
  },
  margin: {
    margin: theme.spacing(1),
  },
}));

const theme = createMuiTheme({
  palette: {
    primary: red,
  },
  typography: {
    htmlFontSize: 12,
    fontFamily: [
      'Montserrat', 'sans-serif'
    ]
  }
});

const LoginPage = () => {
    const classes = useStyles();

    const [userLogin, setUserLogin] = useState({UserName: '', PassWord: ''});
    const [loggedIn, setLoggedIn] = useState(false);

    function submithandler(e) {
      e.preventDefault();
      axios.post('https://localhost:44323/api/login', userLogin )
          .then((response) => {

              let token = response.data.bearerToken;
              console.log(response);
              
          if (response.status === 200) 
          {
            localStorage.setItem('secret', token);
            setLoggedIn({loggedIn: true});
          }
        }).catch((error) => {
          console.log(error);
      });
    };



    const handleChange = (event) => {
      setUserLogin({...userLogin, [event.target.name]: event.target.value});
    }

    return(
        <div> 
            {loggedIn ? <Redirect to="/" /> : null} 
            <div className='container-login'>
              <ThemeProvider theme={theme}>  
                <img className='image' src={LoginImage} alt="Consid woman"/>
                <form onSubmit={submithandler}>
                        <div className='box'>
                            <div className='inner-box'>
                                <label className='login-label'>Inloggning</label>
                                <TextField 
                                        className={classes.margin} 
                                        style={{display: 'block'}} 
                                        id='mui-theme-provider-standard-input' 
                                        label='E-post:'
                                        name= 'UserName'
                                        value={userLogin.UserName}
                                        onChange={handleChange}  
                                        />
                                <TextField 
                                        className={classes.margin} 
                                        style={{display: 'block'}} 
                                        id='mui-theme-provider-standard-input' 
                                        label='Lösenord:'
                                        name= 'PassWord'
                                        type='password'
                                        value={userLogin.PassWord}
                                        onChange={handleChange}
                                        />
                                <button className='login-button'>Logga in</button>
                                <button className='login-password-button'>
                                    <a className='login-forgot-password' href="/">Glömt ditt lösenord?</a>
                                </button> 
                                <button className='login-password-button2'>
                                    <a className='login-forgot-password2' href="/register">Skapa profil</a>
                                </button> 
                            </div>              
                        </div>
                      </form> 
                  </ThemeProvider>    
            </div>
        </div>
    )
}

export default LoginPage;
