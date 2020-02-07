import React from 'react';
import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import '../../css/Login.css';
import LoginImage from '../../images/consid.woman.jpg';

const RegisterPage = () => {
    
    return(
        <div> 
            <Grid container spacing={0}>
                <Grid item xs={5}>
                    <img className='login-img' src={LoginImage} alt="Consid woman"/>
                </Grid>
                <Grid item xs={7}>
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