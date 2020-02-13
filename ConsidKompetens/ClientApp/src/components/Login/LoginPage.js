import React, {useState} from 'react';
import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
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
});

const LoginPage = () => {
    const classes = useStyles();

    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [loggedIn, setLoggedIn] = useState(false);

    function handleClick(event) {
      let baseUrl = 'https://localhost:.../api/login';
      let succeeded = this.props.succeeded;
      let failed = this.props.failed;

      axios.post(baseUrl).then((response) => {
        let token = response.data.value;

        if(response.status === 200) {
          succeeded(token);
        }else if (response.status === 204) {
          failed('Username/Password is incorrect')
        }else {
          failed('Can´t connect to login-server');
        }
      }).catch((error) => {
        console.log(error);
      })

    };

    return(
        <div> 
          {this.props.loggedIn ? <Redirect to="/" /> : null}
            <ThemeProvider theme={theme}>
                <Grid container spacing={0}>
                    <Grid item xs={5}>
                        <img className='login-img' src={LoginImage} alt="Consid woman"/>
                    </Grid>
                    <Grid item xs={7}>
                        <div className='login-box'>
                            <div className='login-inner-box'>
                                <label className='login-label'>Inloggning</label>
                                <TextField 
                                        className={classes.margin} 
                                        style={{display: 'block'}} 
                                        id='mui-theme-provider-standard-input' 
                                        label='E-post:'
                                        onChange={(event, newValue) => setUsername({ username: newValue})}  
                                        />
                                <TextField 
                                        className={classes.margin} 
                                        style={{display: 'block'}} 
                                        id='mui-theme-provider-standard-input' 
                                        label='Lösenord:'
                                        onChange={(event, newValue) => setPassword({ password: newValue})}
                                        />
                                <button className='login-button' onClick={(event) => handleClick(event)}>Logga in</button>
                                <button className='login-password-button'>
                                    <a className='login-forgot-password' href="#">Glömt ditt lösenord?</a>
                                </button> 
                            </div>              
                        </div>
                    </Grid>
                </Grid>
            </ThemeProvider>
        </div>
    )
}

export default LoginPage;