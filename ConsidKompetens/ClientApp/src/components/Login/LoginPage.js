import React, {useState} from 'react';
import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import { ThemeProvider, makeStyles, createMuiTheme} from '@material-ui/core/styles';
import { red } from '@material-ui/core/colors';
import '../../css/Login.css';
import LoginImage from '../../images/consid.woman.jpg';
import axios from 'axios/index';
import {Redirect} from "react-router-dom";
import {getJwt} from '../../Helper/jwt';

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
});



const LoginPage = () => {
    const classes = useStyles();
    const token = getJwt();

    const [userLogin, setUserLogin] = useState({UserName: '', PassWord: ''});
    const [loggedIn, setLoggedIn] = useState(false);

    function loginHandle(token) {
      localStorage.setItem('secret', token);
      setLoggedIn({ loggedIn: true});
    };

    function loginFailed(){
        console.log('You could not login');
        setLoggedIn({ loggedIn: false });
    };


    function submithandler(e) {
      e.preventDefault();
      axios.post('https://localhost:44323/api/login', userLogin )
          .then((response) => {

        let succeeded = loginHandle();
        let failed = loginFailed();

        if(response.status === 200) {
          succeeded();
        }else if (response.status === 204) {
          failed('Username/Password is incorrect')
        }else {
          failed('Can´t connect to login-server');
        }
      }).catch((error) => {
        console.log(error);
      })
    };

    const handleChange = (event) => {
      setUserLogin({...userLogin, [event.target.name]: event.target.value});
    }

    return(
        <div> 
            {loggedIn ? <Redirect to="/" /> : null} 
            <ThemeProvider theme={theme}>
                <Grid container spacing={0}>
                    <Grid item xs={5}>
                        <img className='login-img' src={LoginImage} alt="Consid woman"/>
                    </Grid>
                    <Grid item xs={7}>
                      <form onSubmit={submithandler}>
                        <div className='login-box'>
                            <div className='login-inner-box'>
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
                                        value={userLogin.PassWord}
                                        onChange={handleChange}
                                        />
                                <button className='login-button'>Logga in</button>
                                <button className='login-password-button'>
                                    <a className='login-forgot-password' href="#">Glömt ditt lösenord?</a>
                                </button> 
                            </div>              
                        </div>
                      </form> 
                    </Grid>
                </Grid>
            </ThemeProvider>
        </div>
    )
}

export default LoginPage;