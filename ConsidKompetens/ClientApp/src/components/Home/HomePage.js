import React from 'react';
import Grid from '@material-ui/core/Grid';
import { Container } from 'reactstrap';
import HomeImage from '../../images/hero-img5.jpg';
import SearchIcon from '../../images/search.png';
import '../../css/Home.css';

const officeList = [
    {id: 1, officeOne: "Jönköping", officeTwo: "Stockholm" , officeThree: "Uppsala" },
    {id: 2, officeOne: "Göteborg" , officeTwo: "Malmö" , officeThree: "Linköping" },
    {id: 3, officeOne: "Norrköping", officeTwo: "Värnamo", officeThree: "Växjö" },
    {id: 4, officeOne: "Ljungby" , officeTwo: "Örebro" , officeThree: "Sundsvall" },
    {id: 5, officeOne: "Helsingborg" , officeTwo: "Karlshamn" , officeThree: "Karlskrona" },
    {id: 6, officeOne: "Gävle", officeTwo: "Nyköping" , officeThree: "Borås" }
]


const HomePage = () => {
    return(
        <div className="homeContainer">
            <input className="homeInput" type="text" placeholder="Sök.."/>
            <button className='search-button'><img src={SearchIcon} alt="Search-icon"/></button>
            <label className='home-welcome-label'>Vad letar du efter idag?</label>
            <img className="homeImg" src={HomeImage} alt="ConsidCoffee"/>
            <div>
                <label className='home-label'>Välj kontor</label>
            </div>
            <Container>
               {officeList.map(list => {
                   return(
                       <Grid container spacing={0}>
                            <Grid item xs={4}>
                                <a className='home-item' href="#" key={list.id}>{list.officeOne}</a>
                            </Grid>
                            <Grid item xs={4}>
                                <a className='home-item' href="#" key={list.id}>{list.officeTwo}</a>
                            </Grid>
                            <Grid item xs={4}>
                                <a className='home-item' href="#" key={list.id}>{list.officeThree}</a>
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
            </Container>
        </div>
    )
}

export default HomePage;