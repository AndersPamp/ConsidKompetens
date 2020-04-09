import React, {useState} from 'react';
import NavMenu from '../Header/NavMenu';
import { Container } from 'reactstrap';
import Grid from '@material-ui/core/Grid';
import LinkedIn from '../../images/linkedin.png';
import '../../css/Employee.css';
import axios from 'axios';

const Employee = () => {

    const id = 11;
    const jwt = localStorage.getItem('secret');
    const baseUrl = 'https://localhost:44323/api/profile';
    

    function getUser(){
        axios.get(`${baseUrl}/${id}`,   { headers: { 'Authorization': `Bearer ${jwt}` }})
        .then((response) => {
            console.log(response);
        })
    }

    return(
        
    <div>
        <NavMenu/>
         <div>
                <button className='back-button'>
                <img className='arrow-icon' src="https://icons-for-free.com/iconfiles/png/512/arrow+left+chevron+chevronleft+left+left+icon+icon-1320185731545502691.png" alt=""/>
               
                </button>
            </div>
        <Container>
           
            <div className='emp-container'>
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
                        <h3 className='name'>John Persson</h3>
                        <h5 className='title'>Backend utvecklare</h5>
                    </Grid>
                </Grid>
                <h4 className='aboutMe'>Om mig</h4>
                <h5>Detta er jag...</h5>

                <img src="" alt="cv"/>
                <img src={LinkedIn} alt="linkedIn"/>
                <button onClick={getUser}>Get profile</button>
            </div>
        </Container>
    </div>
        
    )
}

export default Employee;
