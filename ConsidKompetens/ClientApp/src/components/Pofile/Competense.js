import React, {useState, useContext} from 'react';
import TextField from '@material-ui/core/TextField';
import { makeStyles } from '@material-ui/core/styles';
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
// const Competense = () => {
//   return(
//       <form onSubmit={submitHandler}>
//              <TextField
//                className={classes.margin}
//                  style={{display: 'block'}}
//                  label="Kompetens"
//                  id="mui-theme-provider-standard-input"
//                  name='Competense'
//                  value={user.Competense}
//                  onChange={handleChange}  
//                  {...text}
//              />
//          </form>
//   )
// }

// export default Competense;

const useInputValue = initialValue => {
    
    const [value, setValue] = useState(initialValue);

    return{
        value, 
        onChange: e => setValue(e.target.value),
        resetValue: () => setValue("")
    };
};

const Competense = ({onSubmit}) => {
    const classes = useStyles();
    const { resetValue, ...text } = useInputValue('');

    const user = useContext(ProfileContext);
    const {handleChange} = useContext(ProfileContext);

    function submitHandler(e) {
        e.preventDefault();
        onSubmit(text.value);
        resetValue();
    }

    return(
        <form onSubmit={submitHandler}>
             <TextField
                className={classes.margin}
                style={{display: 'block'}}
                label="Kompetens"
                id="mui-theme-provider-standard-input"
                name='Competense'
                value={user.Competense}
                onChange={handleChange}  
                {...text}
            />
        </form>
    )
}

export default Competense;


