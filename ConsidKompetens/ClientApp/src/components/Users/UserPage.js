import React from 'react';
import {
  ThemeProvider,
  makeStyles,
  createMuiTheme
} from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import { red } from '@material-ui/core/colors';
import Grid from '@material-ui/core/Grid';

const useStyles = makeStyles(theme => ({
  root: {
    display: 'flex',
    flexWrap: 'wrap',
  },
  margin: {
    margin: theme.spacing(1),
  },
}));

const theme = createMuiTheme({
  palette: {
    primary: red,
  },
});

const UserPage = () => {
  const classes = useStyles();

  return (
        <ThemeProvider theme={theme}>        
            <Grid container spacing={0}>
                <Grid item xs={7}>
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
                </Grid>
                <Grid item xs={5}>
                    <img src="" alt="ladda upp bild"/>
                    <button className='login-button'>Ladda upp bild</button>
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
  );
}

export default UserPage;

