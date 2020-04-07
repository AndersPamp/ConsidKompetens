import React, {useContext, useEffect} from 'react';
import { Container } from 'reactstrap';
import Grid from '@material-ui/core/Grid';
import '../../css/Details.css';
import NavMenu from '../Header/NavMenu';
import {ProfileContext}  from '../../Context/PofileContext';
import axios from 'axios';

const DetailsPage = () => {

    const {chosenOffices} = useContext(ProfileContext);
    console.log(chosenOffices);


    useEffect(() => {
        function getOfficeId() {
            //const officeIds = offices.map((i) => i.id);
            //const officeIds = [1, 2, 3];
            //const officeIds = chosenOffices.id;
            const jwt =localStorage.getItem('secret');
            axios.get('https://localhost:44323/api/office/profiles',  { headers: { 'Authorization': `Bearer ${jwt}` }})
            .then((response) => {
                console.log(response);
            }).catch(error => console.log(error));
        }
        getOfficeId();
    }, []);

    return (
          <div className="homeContainer">
            {/* <DetailsHeader/> */}
                <Container>
                <NavMenu/>
                        <h1 className='details-header'>{chosenOffices.city}</h1>
                        <div className='container-list'>
                            <Grid container spacing={0}>
                                <Grid item xs={5}>
                                    <div className='img-container'>
                                        <img className='user-img'
                                             src='https://upload.wikimedia.org/wikipedia/commons/5/59/That_Poppy_profile_picture.jpg'
                                             alt="developer"/>
                                    </div>
                                </Grid>
                                <Grid item xs={7}>
                                <div className='details'>
                                    <h4 className='dev-name'>Josefin Persson</h4>
                                    <h6>Backend utvecklare</h6>
                                    <h5 className='about'>Om mig:</h5>
                                    <label htmlFor="">Detta är jag...</label>
                                    <h5 className='about'>Kompetens:</h5>
                                    <div className='competense-output'>React</div>
                                    <div className='competense-output'>.Net</div>
                                    <div className='competense-output'>Episerver</div>
                                    <a className='more' href='/employee'>Mer info +</a>
                                </div>
                                </Grid>
                            </Grid>
                        </div>
                        <div className='container-list'>
                            <Grid container spacing={0}>
                                <Grid item xs={5}>
                                    <div className='img-container'>
                                        <img className='user-img'
                                             src='https://www.cfmoller.com/img/C-F-Moeller-Architects-establishes-presence-in-Malmo-img-10347-w400-h400.jpg'
                                             alt="developer"/>
                                    </div>
                                </Grid>
                                <Grid item xs={7}>
                                <div className='details'>
                                    <h4 className='dev-name'>David Persson</h4>
                                    <h6>Frontend utvecklare</h6>
                                    <h5 className='about'>Om mig:</h5>
                                    <label htmlFor="">Detta är jag...</label>
                                    <h5 className='about'>Kompetens:</h5>
                                    <div className='competense-output'>Angular</div>
                                    <div className='competense-output'>CSS</div>
                                    <div className='competense-output'>HTML</div>
                                    <a className='more' href='/employee'>Mer info +</a>
                                </div>
                                </Grid>
                            </Grid>
                        </div>
                        <div className='container-list'>
                            <Grid container spacing={0}>
                                <Grid item xs={5}>
                                    <div className='img-container'>
                                        <img className='user-img'
                                             src='https://accel-software.com/assets/pages/img/people/img3-large.jpg'
                                             alt="developer"/>
                                    </div>
                                </Grid>
                                <Grid item xs={7}>
                                <div className='details'>
                                    <h4 className='dev-name'>Cristofer Persson</h4>
                                    <h6>Säljare</h6>
                                    <h5 className='about'>Om mig:</h5>
                                    <label htmlFor="">Detta är jag...</label>
                                    <h5 className='about'>Kompetens:</h5>
                                    <div className='competense-output'>Sälj</div>
                                    <div className='competense-output'>...</div>
                                    <div className='competense-output'>...</div>
                                    <a className='more' href='/employee'>Mer info +</a>
                                </div>
                                </Grid>
                            </Grid>
                        </div>
                </Container>
        </div>
    )
}

export default DetailsPage;
