import React from 'react';
import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import { ThemeProvider, makeStyles, createMuiTheme} from '@material-ui/core/styles';
import { red } from '@material-ui/core/colors';
import '../../css/Login.css';
import LoginImage from '../../images/consid.woman.jpg';

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

    return(
        <div> 
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
                                        label='E-post: '></TextField>
                                <TextField 
                                        className={classes.margin} 
                                        style={{display: 'block'}} 
                                        id='mui-theme-provider-standard-input' 
                                        label='Lösenord: '></TextField> 
                                <button className='login-button'>Logga in</button>
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