import React from 'react';
import HomeHeader from '../Home/HomeHeader';
import { Container } from 'reactstrap';
import offices from '../../Helper/Offices.json';

const DetailsPage = () => {
    return (
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
        </div>
    )
}

export default DetailsPage;
