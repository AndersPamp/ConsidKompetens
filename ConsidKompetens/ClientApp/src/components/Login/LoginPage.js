import React from 'react';
import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import '../../css/Login.css';
import LoginImage from '../../images/consid.woman.jpg';



const LoginPage = () => {

   //const classes = useStyles();
    
    return(
        <div> 
            <Grid container spacing={0}>
                <Grid item xs={5}>
                    <img className='login-img' src={LoginImage} alt="Consid woman"/>
                </Grid>
                <Grid item xs={7}>
                    <div className='login-box'>
                        <div className='login-inner-box'>
                            <label className='login-label'>Inloggning</label>
                            <TextField error style={{display: 'block'}} id='standard-error' label='E-post: '></TextField>
                            <TextField error style={{display: 'block'}} id='standard-error' label='Lösenord: '></TextField> 
                            <button className='login-button'>Logga in</button>
                            <button className='login-password-button'><a className='login-forgot-password' href="#">Glömt ditt lösenord?</a></button> 
                        </div>              
                    </div>
                </Grid>
            </Grid>
        </div>
    )
}

export default LoginPage;