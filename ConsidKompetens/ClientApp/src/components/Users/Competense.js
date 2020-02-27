import React, {useState} from 'react';
import TextField from '@material-ui/core/TextField';
import { makeStyles } from '@material-ui/core/styles';

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
    const { resetValue, ...text } = useInputValue("");

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
                {...text}
            />
        </form>
    )
}

export default Competense;


