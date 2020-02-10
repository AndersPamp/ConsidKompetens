import React from 'react';
import { ThemeProvider, makeStyles, createMuiTheme } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import { red } from '@material-ui/core/colors';
import Grid from '@material-ui/core/Grid';
import { Container } from 'reactstrap';
import '../../css/User.css';

const useStyles = makeStyles(theme => ({
  root: {
    display: 'flex',
    flexWrap: 'wrap',
  },
  margin: {
    margin: theme.spacing(1),
  }
}));

const theme = createMuiTheme({
  palette: {
    primary: red,
  },
});

const UserPage = () => {
  const classes = useStyles();

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
                    <TextField
                        className={classes.margin}
                        style={{display: 'block'}}
                        label="Kontor"
                        id="mui-theme-provider-standard-input"/>
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

