import React, {useState} from 'react';
import { ThemeProvider, makeStyles, createMuiTheme } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import { red } from '@material-ui/core/colors';
import Grid from '@material-ui/core/Grid';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import { Container } from 'reactstrap';
import offices from '../../Helper/Offices.json';
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
  },
}));

const theme = createMuiTheme({
  palette: {
    primary: red,
  },
});

const UserPage = () => {
  const classes = useStyles();
  const [office, setOffice] = React.useState('');

  const handleChange = event => {
    setOffice(event.target.value);
  };

  return (
    <Container>
        <ThemeProvider theme={theme}>        
            <Grid container spacing={0}>
                <Grid item xs={7}>
                    <div className='textfield-container'>
                      <TextField
                          className={classes.margin}
                          style={{display: 'block'}}
                          label="Förnamn"
                          id="mui-theme-provider-standard-input"/>
                      <TextField
                          className={classes.margin}
                          style={{display: 'block'}}
                          label="Efternamn"
                          id="mui-theme-provider-standard-input"/>
                    </div> 
                </Grid>
                <Grid item xs={5}>
                    <div className='img-container'>
                        <img className='user-img' 
                             src="https://upload.wikimedia.org/wikipedia/commons/5/59/That_Poppy_profile_picture.jpg" 
                             alt="ladda upp bild"/>
                    </div>
                    <button className='load-img-button'>Ladda upp bild</button>
                </Grid>
            </Grid>
            <TextField
                className={classes.margin}
                style={{display: 'block'}}
                label="Om mig"
                id="mui-theme-provider-standard-input"/>
            <Grid container spacing={0}>
                <Grid item xs={6}>
                    <FormControl className={classes.formControl}>
                      <InputLabel id="demo-simple-select-label">Kontor</InputLabel>
                        <Select labelId="demo-simple-select-label" id="demo-simple-select">
                          {offices.map(list => {
                            return <MenuItem value={list.office} key={list.id}>{list.office}</MenuItem>
                          })}
                        </Select>
                    </FormControl>
                    <TextField
                        className={classes.margin}
                        style={{display: 'block'}}
                        label="Kompetens"
                        id="mui-theme-provider-standard-input"/>
                </Grid>
                <Grid item xs={6}>
                    <TextField
                        className={classes.margin}
                        style={{display: 'block'}}
                        label="LinkedIn link"
                        id="mui-theme-provider-standard-input"/>
                    <TextField
                        className={classes.margin}
                        style={{display: 'block'}}
                        label="Ladda upp CV"
                        id="mui-theme-provider-standard-input"/>
                </Grid>
            </Grid>
        </ThemeProvider>
    </Container>
  );
}

export default UserPage;

