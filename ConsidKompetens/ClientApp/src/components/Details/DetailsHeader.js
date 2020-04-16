import React, {useState} from 'react';
import HomeImage from '../../images/hero-img6.jpg';
//import SearchIcon from '../../images/search-icon.png';
import {Redirect} from "react-router-dom";

const DetailsHeader = () => {

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
            <img className="homeImg" src={HomeImage} alt="ConsidCoffee"/>
        </>
    )
}

export default DetailsHeader;