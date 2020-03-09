import React, {useState} from 'react';
import HomeImage from '../../images/hero-img3.jpg';
//import SearchIcon from '../../images/search-icon.png';
import {Redirect} from "react-router-dom";

const HomeHeader = () => {

    const [loggedOut, setLoggedOut] = useState(false);

    function handleLogoOut() {
            localStorage.removeItem('secret');
            localStorage.removeItem('profile');
            setLoggedOut({loggedOut: true});
    }
    
    return(
        <>
            {loggedOut ? <Redirect to="/login" /> : null} 
            <button className='min-sida-button'><a href="/profile">Min sida</a></button>   
            <button className='logga-ut-button' onClick={handleLogoOut}>Logga ut</button>
            {/* <input className="homeInput" type="text" placeholder="Sök.."/>
            <button className='search-button'><img src={SearchIcon} alt="Search-icon"/></button>
            <label className='home-welcome-label'>Vad letar du efter?</label> */}
            <img className="homeImg" src={HomeImage} alt="ConsidCoffee"/>
        </>
    )
}

export default HomeHeader;
