import React, {useState} from 'react';
//import Grid from '@material-ui/core/Grid';
import { Container } from 'reactstrap';
import HomeImage from '../../images/hero-img6.jpg';
import SearchIcon from '../../images/search-icon.png';
import offices from '../../Helper/Offices.json';
//import NavMenu from '../Header/NavMenu';
import {Redirect} from "react-router-dom";
//import axios from 'axios/index';
import '../../css/Home.css';


const HomePage = () => {

    const [loggedOut, setLoggedOut] = useState(false);
    // const user = localStorage.getItem('secret');

    // function handleLogoOut(e) {
    //     e.preventDefault();
    //     axios.post('https://localhost:44323/api/logout', user)
    //     .then((response) => {

    //         if(response.data.success === true){
    //             localStorage.removeItem('secret');
    //             setLoggedOut({loggedOut: true});
    //         }
    //     }) 
    // }

    // function handleLogoOut(e) {
    //     e.preventDefault();
    //     axios.post('https://localhost:44323/api/logout')
    //     {
    //         localStorage.removeItem('secret');
    //         setLoggedOut({loggedOut: true});
    //     } 
    // }

    function handleLogoOut() {
            localStorage.removeItem('secret');
            setLoggedOut({loggedOut: true});
    }
    
    return(
        <>
        <div className="homeContainer">
        {loggedOut ? <Redirect to="/login" /> : null} 
            <button className='min-sida-button'><a href="/profile">Min sida</a></button>   
            <button className='logga-ut-button' onClick={handleLogoOut}>Logga ut</button>
            <input className="homeInput" type="text" placeholder="Sök.."/>
            <button className='search-button'><img src={SearchIcon} alt="Search-icon"/></button>
            <label className='home-welcome-label'>Vad letar du efter?</label>
            <img className="homeImg" src={HomeImage} alt="ConsidCoffee"/>
             <Container>
               {offices.map(list => {
                   return(
                       <a className='office-list-a' href="/details" key={list.id}>
                       <div className='office-list'>
                           <h3>{list.office}</h3>
                           <h6>Kullagatan 3</h6>
                           <h6>25 486 Göteborg</h6>
                           <h6>Tel: 256 256 265</h6>
                       </div>
                       </a>
                   )
               })}
              
            </Container>
            {/* <Container>
               {officeList.map(list => {
                   return(
                       <Grid container spacing={0}>
                            <Grid item xs={4}>
                                <a className='home-item' href="/details" key={list.officeOne}>{list.officeOne}</a>
                            </Grid>
                            <Grid item xs={4}>
                                <a className='home-item' href="/details" key={list.officeTwo}>{list.officeTwo}</a>
                            </Grid>
                            <Grid item xs={4}>
                                <a className='home-item' href="/details" key={list.officeThree}>{list.officeThree}</a>
                            </Grid>
                        </Grid>
                   )
               })}
               <Grid container spacing={0}>
                            <Grid item xs={4}>
                                <a className='home-item-extra' href="#" >Kalmar</a>
                            </Grid>
                            <Grid item xs={4}>
                                <a className='home-item-extra' href="#" >Västerås</a>
                            </Grid>
                        </Grid>
            </Container> */}
        </div>
        </>
    )
}

export default HomePage;