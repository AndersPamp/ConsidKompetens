import React, {useState} from 'react';
import TextField from '@material-ui/core/TextField';
import { ThemeProvider, makeStyles, createMuiTheme} from '@material-ui/core/styles';
import { red } from '@material-ui/core/colors';
import '../../css/Login.css';
import LoginImage from '../../images/consid.woman.jpg';
import {Redirect} from "react-router-dom";
import axios from 'axios/index';

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


const RegisterPage = () => {
    const classes = useStyles();

    const [userRegister, setUserRegister] = useState({UserName: '', PassWord: ''});
    const [registerad, setRegisterad] = useState(false);

    function submitHendler(e) {
        e.preventDefault();
        axios.post('https://localhost:44323/api/register', userRegister)
            .then(response => {
                setRegisterad({registerad: true});
            })
            .catch(error => {
                console.log(error);
            });
    };

    const handleChange = (event) => {
      setUserRegister({...userRegister, [event.target.name]: event.target.value});
    }

    return(
          <div className='container-login'>
            <ThemeProvider theme={theme}>
                <img className='image' src={LoginImage} alt="Consid woman"/>
                <form onSubmit={submitHendler}>
                        <div className='box'>
                            <div className='inner-box'>
                                <label className='login-label'>Registrera</label>
                                <TextField 
                                        className={classes.margin} 
                                        style={{display: 'block'}} 
                                        id='mui-theme-provider-standard-input 1' 
                                        label='E-post:'
                                        name= 'UserName'
                                        value={userRegister.userName}
                                        onChange={handleChange}>
                                </TextField>
                                <TextField 
                                        className={classes.margin} 
                                        style={{display: 'block'}} 
                                        type='password' 
                                        id='mui-theme-provider-standard-input 2' 
                                        label='Lösenord:'
                                        name= 'PassWord'
                                        value={userRegister.passWord}
                                        onChange={handleChange}>
                                </TextField> 
                                <button type='submit' className='login-button'>Registrera</button>
                            </div>              
                          </div>
                        </form>
            </ThemeProvider>  
           {registerad ? 
            ( <div className='popup-window-container'>
                <h1>Välkomen</h1>
                <h2>Du är registerad!</h2>
                <label>{userRegister.UserName}</label>
                <a href="/login">Klicka här för att logga in</a>
              </div>)
           : null} 
          </div> 
    )
}

export default RegisterPage;