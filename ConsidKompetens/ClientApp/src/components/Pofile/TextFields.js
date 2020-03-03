import React, {useContext} from 'react';
import { makeStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import {ProfileContext} from '../../Context/PofileContext';

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

  const user = useContext(ProfileContext);
  const {handleChange} = useContext(ProfileContext);

    return(
        <>
        <TextField
            className={classes.margin}
            style={{display: 'block'}}
            label="Förnamn"
            id="mui-theme-provider-standard-input one"
            name='FirstName'
            value={user.FirstName}
            onChange={handleChange}  
            />
        <TextField
            className={classes.margin}
            style={{display: 'block'}}
            label="Efternamn"
            id="mui-theme-provider-standard-input two"
            name='LastName'
            value={user.LastName}
            onChange={handleChange}   
            />
        <TextField
            className={classes.margin}
            style={{display: 'block'}}
            multiline
            label="Om mig"
            id="standard-multiline-static"
            name='AboutMe'
            value={user.AboutMe}
            onChange={handleChange} 
            />
            </>
    )
}

export default TextFields;