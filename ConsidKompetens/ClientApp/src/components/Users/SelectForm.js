import React from 'react';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import { makeStyles } from '@material-ui/core/styles';
import offices from '../../Helper/Offices.json';
import role from '../../Helper/Roles.json';

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

    return (
        <>
         <FormControl className={classes.formControl}>
                          <InputLabel id="demo-simple-select-label">Kontor</InputLabel>
                            <Select labelId="demo-simple-select-label" id="demo-simple-select">
                              {offices.map(list => {
                                return <MenuItem value={list.office} key={list.id}>{list.office}</MenuItem>
                              })}
                            </Select>
                      </FormControl>
                      <FormControl className={classes.formControl}>
                          <InputLabel id="demo-simple-select-label">Min titel</InputLabel>
                            <Select labelId="demo-simple-select-label" id="demo-simple-select">
                              {role.map(list => {
                                return <MenuItem value={list.role} key={list.id}>{list.role}</MenuItem>
                              })}
                            </Select>
                      </FormControl>
                    </>
    )
}

export default SelectForm;