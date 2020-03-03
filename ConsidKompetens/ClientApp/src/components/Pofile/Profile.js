import React, {useState, useContext} from 'react';
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

  const profile = useContext(ProfileContext);
  const {handleChange} = useContext(ProfileContext);
  console.log(profile);
  
  const [competense, setCompetense] = useState([]);
  
  const toggleComplete = (i) => {
      setCompetense(
        competense.map(
          (competense, k) => k === i ? {...competense,
                        completet: !competense.completet} : competense)
      )
  };  

  function submit(){
      axios.put('https://localhost:44323/api/profile/editprofile',profile , { headers: { 'Authorization': `Bearer ${jwt}` } })
      .then((res) => {
      console.log(res);
    })
  }

  return (
    <>
    <NavMenu/>
    <div className='user-container'>
      <Container>
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
                        <Competense onSubmit={text => setCompetense([{text, completet: false}, ...competense])}/>
                         <div className='competense-container'>
                          {competense.map(({text, completet}, i) => (
                            <div className='competense-output'
                            key={text} onClick={() => toggleComplete(i)} style={{display: completet ? 'none' : 'inline-block'}}>{text}
                            </div>
                          ))}
                        </div>
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
                            name='LinkedIn'
                            value={profile.LinkedIn}
                            onChange={handleChange}   
                            />
                      <UploadCV/>
                      <label className='login-text'>Du är inloggad med e-postadressen: </label>
                      <label className='login-email'>(email)</label>
                      <button className='button' onClick={submit}>Uppdatera</button>
                    </div>
                  </Grid>
              </Grid>
          </ThemeProvider>
      </Container>
    </div>
    </>
  );
}

export default Profile;

