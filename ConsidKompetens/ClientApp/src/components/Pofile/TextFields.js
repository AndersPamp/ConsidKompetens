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
    width: 450
  }
}));

const TextFields = () => {
    const classes = useStyles();
    const {profile} = useContext(ProfileContext);
    const user = profile;
    const {handleChange} = useContext(ProfileContext);

    return(
        <>
          <TextField
            className={classes.margin, classes.formControl}
            style={{display: 'block'}}
            label="Förnamn"
            fullWidth
            id="mui-theme-provider-standard-input one"
            name='firstName'
            value={user.firstName || ''}
            onChange={handleChange} 
          />
          <TextField
            className={classes.margin, classes.formControl}
            style={{display: 'block'}}
            label="Efternamn"
            fullWidth
            id="mui-theme-provider-standard-input two"
            name='lastName'
            value={user.lastName || ''}
            onChange={handleChange}   
          />
        </>
    )
}

export default TextFields;