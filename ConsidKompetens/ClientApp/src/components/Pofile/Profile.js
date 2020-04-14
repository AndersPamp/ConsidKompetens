import React, { useContext, useEffect } from 'react';
import { ThemeProvider, makeStyles, createMuiTheme } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import { red } from '@material-ui/core/colors';
import Grid from '@material-ui/core/Grid';
import { Container } from 'reactstrap';
import NavMenu from '../Header/NavMenu';
import Competense from './Competense';
import SelectForm from './SelectForm';
import TextFields from './TextFields';
import UploadImage from './UploadImage';
import UploadCV from './UploadCV';
import axios from 'axios';
import {ProfileContext}  from '../../Context/PofileContext';
import '../../css/User.css';

const useStyles = makeStyles(theme => ({
  root: {
    display: 'flex',
    flexWrap: 'wrap',
  },
  margin: {
    margin: theme.spacing(1),
  },
  formControl: {
    margin: theme.spacing(1),
    minWidth: 120,
  }
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
const Profile = () => {
  const classes = useStyles();
  const jwt = localStorage.getItem('secret');

const {profile } = useContext(ProfileContext);
  const input = profile;
  const {handleChange, initProfile} = useContext(ProfileContext);

  function submit(e){
      e.preventDefault();
      axios.put('https://localhost:44323/api/profile/editprofile',input , { headers: { 'Authorization': `Bearer ${jwt}` } })
        .then((response) => {
        const result = response.data;
        console.log(result)

        if(response.status === 200)
        {
          localStorage.setItem('profile', result);
          alert('You have updated your profile');
          console.log(result);
          console.log(response);
        }
    }).catch((error) => {
      console.log(error);
    })
  }

  useEffect(() => {
    function getProfile() {
          const jwt = localStorage.getItem('secret');
          axios.get('https://localhost:44323/api/profile/ownerid', { headers: { 'Authorization': `Bearer ${jwt}` } })
          .then((response) => {
          const user = response.data.data.profileModels[0];
          console.log(user)
          initProfile(user);
      }).catch(error => console.log(error))
  }
    getProfile();
  }, [])

  return (
    <>
    <NavMenu/>
    <div className='user-container'>
      <Container>
      <div className='profile-container'>
          <ThemeProvider theme={theme}>
              <Grid container spacing={0}>
                  <Grid item xs={7}>
                      <div className='textfield-container'>
                        <TextFields/>
                      </div>
                  </Grid>
                  <Grid item xs={5}>
                  <UploadImage/>
                  </Grid>
              </Grid>
              <Grid container spacing={0}>
                  <Grid item xs={6}>
                    <div className='grid-one'>
                     <SelectForm/>
                      <Grid container spacing={0}>
                        <Grid item xs={12}>
                        <Competense/>
                        <div></div>
                        </Grid>
                      </Grid>
                    </div>
                  </Grid>
                  <Grid item xs={6}>
                    <div className='grid-two'>
                      <TextField
                            className={classes.margin}
                            style={{display: 'block'}}
                            label="LinkedIn link"
                            id="mui-theme-provider-standard-input three"
                            name='linkedInUrl'
                            value={input.linkedInUrl || ''}
                            onChange={handleChange}  
                            
                            />
                      <UploadCV/>
                      {/* <label className='login-text'>Du är inloggad med e-postadressen: </label>
                      <label className='login-email'>(email)</label> */}
                    </div>
                  </Grid>
              </Grid>
              <button className='button' onClick={submit}>Uppdatera din profil</button>
          </ThemeProvider>
          </div>
      </Container>
    </div>
    </>
  );
}

export default Profile;

