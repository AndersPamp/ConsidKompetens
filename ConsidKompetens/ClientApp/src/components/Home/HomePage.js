import React, {useState, useContext, useEffect} from 'react';
import Grid from '@material-ui/core/Grid';
import { ThemeProvider, createMuiTheme } from '@material-ui/core/styles';
//port offices from '../../Helper/Offices.json';
import HomeHeader from './HomeHeader';
import '../../css/Home.css';
import FormGroup from '@material-ui/core/FormGroup';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';
import {ProfileContext} from '../../Context/PofileContext';
import axios from 'axios';

const theme = createMuiTheme({
  typography: {
    htmlFontSize: 15,
    fontFamily: [
      'Montserrat', 'sans-serif'
    ]
  }
});

const HomePage = () => {
    
    const [offices, setOffices] = useState([]);
    const [loading, setLoading] = useState(true);
    const {profile} = useContext(ProfileContext);
    const user = profile;
    console.log(user)
    const jwt =localStorage.getItem('secret');

    useEffect(() => {
   const getOffices = () => {
        axios.get('https://localhost:44323/api/office/offices', { headers: { 'Authorization': `Bearer ${jwt}` } })
        .then((response) => {
          console.log(response.data);
          const list = response.data.data.officeModels;
          setOffices(list)
          setLoading(false)
        }).catch(error => console.log(error));
    }
  getOffices();
}, []);


  const getOfficeId = () => {
        axios.get('https://localhost:44323/api/office', offices, { headers: { 'Authorization': `Bearer ${jwt}` } })
        .then((response) => {
          console.log(response);
        }).catch(error => console.log(error));
    }

    return(
        <>
        <div className="homeContainer">
          <Grid container spacing={0}>
            <Grid item xs={7}>
              <HomeHeader/>
            </Grid>
            <Grid item xs={5}>
            </Grid>
              <div className='list-container'>
              <h2>Välj kontor</h2>
                {!loading ? (offices.map((list, i) => {
                    return(
                      <ThemeProvider theme={theme} key={i}>
                        <FormGroup style={{display: 'inline'}}>
                          <div className='diven'>
                              <FormControlLabel 
                                  control={
                                  <Checkbox
                                      value={list.id}
                                  />
                                  }
                                  label={list.city}
                              />
                              </div>
                          </FormGroup>
                      </ThemeProvider>
                    )
                  })
                
                ): (<div className='loading'>
                      <div className="d-flex justify-content-center">
                        <div className="spinner-border" role="status">
                          <span className="sr-only">Loading...</span>
                        </div>
                      </div>
                    </div>)}
              <br/>
              <button>Sök</button>
              <button onClick={getOfficeId}>Get office</button>
            </div>
          </Grid>      
      </div>
      </>
    )
}

export default HomePage;

