import React from 'react';
import { Container } from 'reactstrap';
import offices from '../../Helper/Offices.json';
import HomeHeader from './HomeHeader';
import '../../css/Home.css';


const HomePage = () => {
    
    return(
        <>
        <div className="homeContainer">
        
           <HomeHeader/>
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