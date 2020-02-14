import React, {useState} from 'react';
import TextField from '@material-ui/core/TextField';
import { ThemeProvider, makeStyles, createMuiTheme} from '@material-ui/core/styles';
import { red } from '@material-ui/core/colors';
import Grid from '@material-ui/core/Grid';
import '../../css/Login.css';
import LoginImage from '../../images/consid.woman.jpg';
import axios from 'axios/index';
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

const jwt = getJwt();

const RegisterPage = () => {
    const classes = useStyles();

    const [userName, setUserName] = useState('');
    const [passWord, setPassWord] = useState('');

    function submitHendler(e) {
        e.preventDefault();
        axios.post('https://localhost:44323/api/register', userName, passWord )
            .then(response => {
                alert('User has been registered');
                setUserName({userName: ''});
                setPassWord({passWord: ''});
            })
            .catch(error => {
                console.log(error);
            });
    };

    return(
        <div> 
            <ThemeProvider theme={theme}>
                <Grid container spacing={0}>
                    <Grid item xs={5}>
                        <img className='login-img' src={LoginImage} alt="Consid woman"/>
                    </Grid>
                    <Grid item xs={7}>
                      <form onSubmit={submitHendler}>
                        <div className='login-box'>
                            <div className='login-inner-box'>
                                <label className='login-label'>Registrera</label>
                                <TextField 
                                        className={classes.margin} 
                                        style={{display: 'block'}} 
                                        id='mui-theme-provider-standard-input' 
                                        label='E-post:'
                                        onChange={(event, newValue) => setUserName({ userName: newValue})}>
                                </TextField>
                                <TextField 
                                        className={classes.margin} 
                                        style={{display: 'block'}} 
                                        type='password' 
                                        id='mui-theme-provider-standard-input' 
                                        label='Lösenord:'
                                        onChange={(event, newValue) => setPassWord({ passWord: newValue})}>
                                </TextField> 
                                <button className='login-button'>Registrera</button>
                            </div>              
                        </div>
                        </form>
                    </Grid>
                </Grid>
            </ThemeProvider>    
        </div>
    )
}

export default RegisterPage;