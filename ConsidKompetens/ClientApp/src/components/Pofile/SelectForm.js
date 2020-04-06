import React, {useContext, useState, useEffect} from 'react';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import { makeStyles } from '@material-ui/core/styles';
import role from '../../Helper/Roles.json';
import {ProfileContext} from '../../Context/PofileContext';
import axios from 'axios';

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
    const [offices, setOffices] = useState([]);
    const {profile} = useContext(ProfileContext);
    const user = profile;
    const {handleChange} = useContext(ProfileContext);
    

useEffect(() => {
   const getOffices = () => {
        const jwt = localStorage.getItem('secret');
        axios.get('https://localhost:44323/api/office/offices', { headers: { 'Authorization': `Bearer ${jwt}` } })
        .then((response) => {
          console.log(response.data);
          const list = response.data.data.officeModels;
          setOffices(list)
         
        }).catch(error => console.log(error));
    }
  getOffices();
}, []);
   

    return (
        <>
         <FormControl className={classes.formControl}>
                          <InputLabel id="demo-simple-select-label">Kontor</InputLabel>
                            <Select name='OfficeModelId' value={user.OfficeModelId || ''} onChange={handleChange} labelId="demo-simple-select-label" id="demo-simple-select">
                              {offices.map((item, i) => {
                                return <MenuItem  value={item.id} key={i}>{item.city}</MenuItem>
                              })}
                            </Select>
                      </FormControl>
                      <FormControl className={classes.formControl}>
                          <InputLabel id="demo-simple-select-label">Min titel</InputLabel>
                            <Select name='position' value={user.position || ''} onChange={handleChange} labelId="demo-simple-select-label" id="demo-simple-select">
                              {role.map(list => {
                                return <MenuItem value={list.role} key={list.id}>{list.role}</MenuItem>
                              })}
                            </Select>
                      </FormControl>
                    </>
    )
}

export default SelectForm;