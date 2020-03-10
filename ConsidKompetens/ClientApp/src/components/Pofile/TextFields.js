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
            name='firstName'
            value={user.firstName || ''}
            onChange={handleChange} 
            />
        <TextField
            className={classes.margin}
            style={{display: 'block'}}
            label="Efternamn"
            id="mui-theme-provider-standard-input two"
            name='lastName'
            value={user.lastName || ''}
            onChange={handleChange}   
            />
        <TextField
            className={classes.margin}
            style={{display: 'block'}}
            multiline
            label="Om mig"
            id="standard-multiline-static"
            name='aboutMe'
            value={user.aboutMe || ''}
            onChange={handleChange} 
            />
            </>
    )
}

export default TextFields;