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

const UploadCV = () => {
    const classes = useStyles();
    const profile = useContext(ProfileContext);
    const {handleChange} = useContext(ProfileContext);

    return (
        <>
            <TextField
                className={classes.margin}
                style={{display: 'block', margin: '25px 5px 5px 5px'}}
                type='file'
                id="mui-theme-provider-standard-input four"
                name='cv'
                value={profile.cv}
                onChange={handleChange}  
                />
            <label className='load-cv'>Ladda upp CV</label>
        </>
    )
}

export default UploadCV;