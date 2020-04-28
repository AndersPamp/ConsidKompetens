import React, {useState, useContext, useEffect} from 'react';
import NavMenu from '../Header/NavMenu';
import { Container } from 'reactstrap';
import Grid from '@material-ui/core/Grid';
import LinkedIn from '../../images/linkedin.png';
import {ProfileContext} from '../../Context/PofileContext';
import '../../css/Employee.css';
import axios from 'axios';
import placeholderImg from '../../images/img-person-placeholder.jpg';

const Employee = () => {

    const {profileId} = useContext(ProfileContext);
    const [employee, setEmployee] = useState([]);
    const [loading, setLoading] = useState(true);
    const id = profileId.id;
    const baseUrl = 'https://localhost:44323/api/profile';

    useEffect(() => {
        function getUser(){
            const jwt = localStorage.getItem('secret');
            axios.get(`${baseUrl}/${id}`, { headers: { 'Authorization': `Bearer ${jwt}` }})
            .then((response) => {
                const user = response.data.data.profileModels;
                setEmployee(user);
                setLoading(false);
        }).catch(error => console.log(error)); 
    }
        getUser();
    }, []); 


    return(   
        <div>
            <NavMenu/>
            <Container>
                {!loading ? (
                    employee.map((list, i) => {
                        return(
                            <div className='emp-container' key={i}>
                                <Grid container spacing={0}>
                                    <Grid item xs={7}>
                                        <h4 className='office'>Kontor</h4>
                                        <h3>Helsingborg</h3>
                                        <h4 className='competense'>Kompetens</h4>
                                        {list.competences.map((comp, x) => {
                                            return(<div key={x} className='competense-output'>{comp.value}</div>)
                                        })}
                                        <h4 className='aboutMe'>Om mig</h4>
                                        <h5 className='output-about'>{list.aboutMe}</h5>
                                        <h4 className='aboutMe'>LinkedIn</h4>
                                        <a className='linked' href={list.linkedInUrl}>{list.linkedInUrl}</a>
                                        <h4 className='aboutMe'>CV</h4>
                                        <a className='linked' href={list.resumeUrl}>{list.resumeUrl}</a>
                                    </Grid>
                                    <Grid item xs={5}>
                                        <div className='img-container'>
                                            <img className='user-img' src={placeholderImg} alt="employee"/>
                                        </div>
                                        <h3 className='name'>{list.firstName + ' ' + list.lastName}</h3>
                                        <h5 className='title'>{employee.position}</h5>
                                    </Grid>
                                </Grid>
                            </div>
                        )})
                        ): (<div className='loading'>
                                <div className="d-flex justify-content-center">
                                    <div className="spinner-border" role="status">
                                        <span className="sr-only">Loading...</span>
                                    </div>
                                </div>
                            </div>)}
            </Container>
        </div>
    )
}

export default Employee;
