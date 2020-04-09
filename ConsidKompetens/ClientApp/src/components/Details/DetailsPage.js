import React, {useContext, useEffect, useState} from 'react';
import { Container } from 'reactstrap';
import Grid from '@material-ui/core/Grid';
import '../../css/Details.css';
import NavMenu from '../Header/NavMenu';
import {ProfileContext}  from '../../Context/PofileContext';
import axios from 'axios';

const DetailsPage = () => {

    const {chosenOffices, initProfileId} = useContext(ProfileContext);
    const [profiles, setProfiles] = useState([]);
    const [loading, setLoading] = useState(true);
    console.log(chosenOffices);


    useEffect(() => {
        function getOfficeId() {
            const officeids = chosenOffices.id;
            console.log(officeids)
            const jwt =localStorage.getItem('secret');
            axios.get('https://localhost:44323/api/office/profiles', {params: {officeids: officeids} ,headers: { 'Authorization': `Bearer ${jwt}` }})
            .then((response) => {
                console.log(response.data.data.profileModels);
                const user = response.data.data.profileModels;
                setProfiles(user);
                setLoading(false);
                initProfileId(profiles);
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
                        {!loading ? (profiles.map((user, i) =>
                        {
                            return(
                                <div className='container-list' key={i}>
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
                                    <h4 className='dev-name'>{user.firstName + ' ' + user.lastName}</h4>
                                    <h6>{user.position}</h6> 
                                    <h5 className='about'>Om mig:</h5>
                                    <label htmlFor="">{user.aboutMe}</label>
                                    <h5 className='about'>Kompetens:</h5>
                                    <div className='competense-output'>React</div>
                                    <div className='competense-output'>.Net</div>
                                    <div className='competense-output'>Episerver</div>
                                    <a className='more' href='/employee'>Mer info +</a>
                                </div>
                                </Grid>
                            </Grid>
                        </div>
                            )
                        }
                        )) : (<div className='loading'>
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

export default DetailsPage;
