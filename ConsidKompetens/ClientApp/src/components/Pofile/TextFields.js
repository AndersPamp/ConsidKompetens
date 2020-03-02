import React, {useState} from 'react';
import { makeStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';

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

const TextFields = () => {
    const classes = useStyles();

   const [profile, setProfile] = useState({FirstName: '', LastName: '', AboutMe: ''});

   const handleChange = (event) => {
    setProfile({...profile, [event.target.name]: event.target.value});
  }

    return(
        <>
        <TextField
            className={classes.margin}
            style={{display: 'block'}}
            label="Förnamn"
            id="mui-theme-provider-standard-input one"
            name='FirstName'
            value={profile.FirstName}
            onChange={handleChange}  
            />
        <TextField
            className={classes.margin}
            style={{display: 'block'}}
            label="Efternamn"
            id="mui-theme-provider-standard-input two"
            name='LastName'
            value={profile.LastName}
            onChange={handleChange}   
            />
        <TextField
            className={classes.margin}
            style={{display: 'block'}}
            multiline
            label="Om mig"
            id="standard-multiline-static"
            name='AboutMe'
            value={profile.AboutMe}
            onChange={handleChange} 
            />
            </>
    )
}

export default TextFields;