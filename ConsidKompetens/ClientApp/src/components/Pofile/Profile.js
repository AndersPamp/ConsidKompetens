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
  const updateMessage = document.getElementById('updateMessage');

  function submit(e){
      e.preventDefault();
      axios.put('https://localhost:44323/api/profile/editprofile',input , { headers: { 'Authorization': `Bearer ${jwt}` } })
        .then((response) => {
        updateMessage.style.display = 'block';
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
                        <TextField
                          className={classes.margin}
                          style={{display: 'block'}}
                          label="LinkedIn link"
                          id="mui-theme-provider-standard-input three"
                          name='linkedInUrl'
                          value={input.linkedInUrl || ''}
                          onChange={handleChange}/>
                        <TextField
                          className={classes.margin}
                          style={{display: 'block'}}
                          multiline
                          label="Om mig"
                          id="standard-multiline-static two"
                          name='aboutMe'
                          value={input.aboutMe || ''}
                          onChange={handleChange} />
                        <SelectForm/>
                        <Competense/>
                        <UploadCV/>
                      </div>
                  </Grid>
                  <Grid item xs={5}>
                    <UploadImage/>
                  </Grid>
              </Grid>
              <button className='button' onClick={submit}>Uppdatera din profil</button>
              <label className='updateMessage' id='updateMessage' style={{display: 'none'}}>Din profil är uppdaterad!</label>
            </ThemeProvider>
          </div>
      </Container>
    </div>
    </>
  );
}

export default Profile;

