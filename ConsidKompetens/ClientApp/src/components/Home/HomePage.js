import React from 'react';
import HomeImage from '../../images/hero-image.jpg';
import '../../css/Home.css';
import SearchIcon from '../../images/search.png';
import { Footer } from '../../components';

const HomePage = () => {
    return(
        <div className="homeContainer">
            <input className="homeInput" type="text" placeholder="Sök.."/>
            <button className='search-button'><img src={SearchIcon} alt="Search-icon"/></button>
            <img className="homeImg" src={HomeImage} alt="ConsidCoffee"/>
            <div>
                <label>Välj kontor</label>
            </div>
            <Footer/>
        </div>
    )
}

export default HomePage;