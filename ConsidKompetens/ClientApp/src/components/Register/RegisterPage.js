import React from 'react';
import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import { makeStyles } from '@material-ui/core/styles';
import '../../css/Login.css';
import LoginImage from '../../images/consid.woman.jpg';

const useStyles = makeStyles ({
    TextField: {
        color: 'green'
    }
})


const RegisterPage = () => {

   const classes = useStyles();
    
    return(
        <div> 
            <Grid container spacing={0}>
                <Grid item xs={6}>
                    <img className='login-img' src={LoginImage} alt="Consid woman"/>
                </Grid>
                <Grid item xs={6}>
                    <div className='login-box'>
                        <div className='login-inner-box'>
                            <label className='login-label'>Registrera</label>
                            <TextField error style={{display: 'block'}} id='standard-error' label='E-post: '></TextField>
                            <TextField error style={{display: 'block'}} type='password' id='standard-error' label='Lösenord: '></TextField> 
                            <button className='login-button'>Registrera</button>
                        </div>              
                    </div>
                </Grid>
            </Grid>
        </div>
    )
}

export default RegisterPage;