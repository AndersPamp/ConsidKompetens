// import React, { Component } from 'react';
// import { ThemeProvider, makeStyles, createMuiTheme } from '@material-ui/core/styles';
// import TextField from '@material-ui/core/TextField';
// import { red } from '@material-ui/core/colors';
// import Grid from '@material-ui/core/Grid';
// import { Container } from 'reactstrap';
// import NavMenu from '../Header/NavMenu';
// import Competense from './Competense';
// import SelectForm from './SelectForm';
// import TextFields from './TextFields';
// import UploadImage from './UploadImage';
// import UploadCV from './UploadCV';
// import axios from 'axios';
// import { getJwt } from '../../Helper/jwt';
// import { ProfileContext } from '../../Context/PofileContext';
// import '../../css/User.css';

// const useStyles = makeStyles(theme => ({
//   root: {
//     display: 'flex',
//     flexWrap: 'wrap',
//   },
//   margin: {
//     margin: theme.spacing(1),
//   },
//   formControl: {
//     margin: theme.spacing(1),
//     minWidth: 120,
//   }
// }));

// const theme = createMuiTheme({
//   palette: {
//     primary: red,
//   },
//   typography: {
//     htmlFontSize: 12,
//     fontFamily: [
//       'Montserrat', 'sans-serif'
//     ]
//   }
// });

// class Profile extends Component {
//   constructor(props) {
//         super(props)
//         this.state = {
//             competense: [],
//             fistName: ''
//         }
//     }
  
//   static contextType = ProfileContext

//   toggleComplete(i) {
//       this.setState(
//         this.state.competense.map(
//           (competense, k) => k === i ? {...this.state.competense,
//                         completet: !this.state.competense.completet} : this.state.competense)
//       )
//   };  

//   clikk(){
//     const jwt = localStorage.getItem('secret');
//      axios.put('https://localhost:44323/api/profile/editprofile', { headers: { 'Authorization': `Bearer ${jwt}` } })
//      .then((res) => {
//     console.log(res);
//   })
//   }

//   handleChange(event) {
    
//      this.setState(event.target.value);
//   }

 
//   // function submitCompetense(event) {
//   //   console.log(profile);
//   //   event.preventDefault();
//   //   document.getElementById('display').innerHTML = profile.Competense;
//   // }
//   render() {
//     console.log(this.context);
//     const value = this.context;

//     return (
//       <>
//       <NavMenu/>
//       <div className='user-container'>
//         <Container>
//             <ThemeProvider theme={theme}>
//                 <Grid container spacing={0}>
//                     <Grid item xs={7}>
//                         <div className='textfield-container'>
//                           <TextFields/>
//                         </div>
//                     </Grid>
//                     <Grid item xs={5}>
//                     <UploadImage/>
//                     </Grid>
//                 </Grid>
//                 <Grid container spacing={0}>
//                     <Grid item xs={6}>
//                       <div className='grid-one'>
//                       <SelectForm/>
//                         <Grid container spacing={0}>
//                           <Grid item xs={12}>
//                           <Competense onSubmit={text => this.setState([{text, completet: false}, ...this.state.competense])}/>
//                           <div className='competense-container'>
//                             {this.state.competense.map(({text, completet}, i) => (
//                               <div className='competense-output'
//                               key={text} onClick={() => this.toggleComplete(i)} style={{display: completet ? 'none' : 'inline-block'}}>{text}
//                               </div>
//                             ))}
//                           </div>
//                           </Grid>
//                         </Grid>
//                       </div>
//                     </Grid>
//                     <Grid item xs={6}>
//                       <div className='grid-two'>
//                         <TextField
//                               style={{display: 'block'}}
//                               label="LinkedIn link"
//                               id="mui-theme-provider-standard-input three"
//                               name='LinkedIn'  
//                               value={value.FirstName}
//                               onChange={this.handleChange}
//                               />
//                         <UploadCV/>
//                         <label className='login-text'>Du är inloggad med e-postadressen: </label>
//                         <label className='login-email'>(email)</label>
//                         <button className='button'>Uppdatera</button>
//                       </div>
//                     </Grid>
//                 </Grid>
//                 <button onClick={this.clikk}>Clikk</button>
//             </ThemeProvider>
//         </Container>
//       </div>
//       </>
//     );
//   }
// }

// export default Profile;

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
  console.log(profile);
  
 
  const [competense, setCompetense] = useState([]);
  const [linkedInLink, setlinkedInLink] = useState({LinkedIn: ''});
  //const [profile, setProfiel] = useState({FirstName: '', LastName: '', AboutMe: '', Title: '', ProfileImage: '', Competense, Experience: '', Links: '', ProjektProfileRoles: ''})

   const handleChange = (event) => {
    setlinkedInLink({...linkedInLink, [event.target.name]: event.target.value});
  }

  const toggleComplete = (i) => {
      setCompetense(
        competense.map(
          (competense, k) => k === i ? {...competense,
                        completet: !competense.completet} : competense)
      )
  };  

  function clikk(){
     axios.put('https://localhost:44323/api/profile/editprofile',profile , { headers: { 'Authorization': `Bearer ${jwt}` } })
     .then((res) => {
    console.log(res);
  })
  }
 
  // function submitCompetense(event) {
  //   console.log(profile);
  //   event.preventDefault();
  //   document.getElementById('display').innerHTML = profile.Competense;
  // }

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
                            value={linkedInLink.LinkedIn}
                            onChange={handleChange}   
                            />
                      <UploadCV/>
                      <label className='login-text'>Du är inloggad med e-postadressen: </label>
                      <label className='login-email'>(email)</label>
                      <button className='button'>Uppdatera</button>
                    </div>
                  </Grid>
              </Grid>
              <button onClick={clikk}>Clikk</button>
          </ThemeProvider>
      </Container>
    </div>
    </>
  );
}

export default Profile;

