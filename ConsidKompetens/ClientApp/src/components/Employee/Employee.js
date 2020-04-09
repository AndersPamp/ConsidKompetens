import React, {useState, useContext, useEffect} from 'react';
import NavMenu from '../Header/NavMenu';
import { Container } from 'reactstrap';
import Grid from '@material-ui/core/Grid';
import LinkedIn from '../../images/linkedin.png';
import {ProfileContext} from '../../Context/PofileContext';
import '../../css/Employee.css';
import axios from 'axios';

const Employee = () => {

    const {profileId, chosenOffice} = useContext(ProfileContext);
    const [employee, setEmployee] = useState([]);
    const [loading, setLoading] = useState(true);
    const id = 10;
    const jwt = localStorage.getItem('secret');
    const baseUrl = 'https://localhost:44323/api/profile';
 
    useEffect(() => {
        function getUser(){
        axios.get(`${baseUrl}/${id}`, { headers: { 'Authorization': `Bearer ${jwt}` }})
        .then((response) => {
            const user = response.data.data.profileModels;
            console.log(user)
            setEmployee(user);
            setLoading(false);
        }).catch(error => console.log(error));
        
    }
        getUser();
    }, []) 

    return(   
        <div>
            <NavMenu/>
            <div>
                <button className='back-button'>
                <img className='arrow-icon' src="https://icons-for-free.com/iconfiles/png/512/arrow+left+chevron+chevronleft+left+left+icon+icon-1320185731545502691.png" alt=""/>
                </button>
            </div>
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
                            <div className='competense-output'>React</div>
                            <div className='competense-output'>Episerver</div>
                            <div className='competense-output'>.Net</div>
                            <div className='competense-output'>CSS</div>
                            <div className='competense-output'>HTML</div>
                            <div className='competense-output'>C#</div>
                            <div className='competense-output'>JavaScript</div>
                            <div className='competense-output'>Java</div>
                        </Grid>
                        <Grid item xs={5}>
                            <div className='img-container'>
                                <img className='user-img' src="https://accel-software.com/assets/pages/img/people/img3-large.jpg" alt="employee"/>
                            </div>
                            <h3 className='name'>{list.firstName + ' ' + list.lastName}</h3>
                            <h5 className='title'>{employee.position}</h5>
                        </Grid>
                    </Grid>
                    <h4 className='aboutMe'>Om mig</h4>
                    <h5>{list.aboutMe}</h5>

                    <img src="" alt="cv"/>
                    <img src={LinkedIn} alt="linkedIn"/>
                </div>
                    )
                })
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
