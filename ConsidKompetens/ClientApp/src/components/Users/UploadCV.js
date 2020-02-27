import React from 'react';
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


const UploadCV = () => {
    const classes = useStyles();

    return (
        <>
            <TextField
                className={classes.margin}
                style={{display: 'block'}}
                label="CV"
                id="mui-theme-provider-standard-input four"/>
            <label className='load-cv'>Ladda upp CV</label>
        </>
    )
}

export default UploadCV;