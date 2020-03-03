import React, {useContext} from 'react';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import { makeStyles } from '@material-ui/core/styles';
import officeList from '../../Helper/Offices.json';
import role from '../../Helper/Roles.json';
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

const SelectForm = () => {
    const classes = useStyles();
    const user = useContext(ProfileContext);
    const {handleChange} = useContext(ProfileContext);

    return (
        <>
         <FormControl className={classes.formControl}>
                          <InputLabel id="demo-simple-select-label">Kontor</InputLabel>
                            <Select name='Office' value={user.Office} onChange={handleChange} labelId="demo-simple-select-label" id="demo-simple-select">
                              {officeList.map(list => {
                                return <MenuItem  value={list.office} key={list.id}>{list.office}</MenuItem>
                              })}
                            </Select>
                      </FormControl>
                      <FormControl className={classes.formControl}>
                          <InputLabel id="demo-simple-select-label">Min titel</InputLabel>
                            <Select name='Title' value={user.Title} onChange={handleChange} labelId="demo-simple-select-label" id="demo-simple-select">
                              {role.map(list => {
                                return <MenuItem value={list.role} key={list.id}>{list.role}</MenuItem>
                              })}
                            </Select>
                      </FormControl>
                    </>
    )
}

export default SelectForm;