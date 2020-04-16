import React from 'react';
import '../../css/Footer.css';
import FacebookIcon from '../../images/facebook.png';
import TwitterIcon from '../../images/twitter.png';
import LinkedInIcon from '../../images/in.png';
import InstagramIcon from '../../images/instagram.png';
import FooterIcon from '../../images/footer.png';
import {Container} from 'reactstrap';

export const Footer = () => {
    return(
        <Container>
            <div className='footer-container'>
                <div>
                    <a href="https://www.facebook.com/consid.se"><img className='footer-img' src={FacebookIcon} alt="Facebook"/></a>
                    <a href="https://www.linkedin.com/company/consid-ab/"><img className='footer-img' src={LinkedInIcon} alt="LinkedIn"/></a>
                    <a href="https://www.instagram.com/consid_ab/"><img className='footer-img' src={InstagramIcon} alt="Instagram"/></a>
                    <a href="https://twitter.com/consid_ab/"><img className='footer-img' src={TwitterIcon} alt="Twitter"/></a>
                </div>
                <a href="https://consid.se/"><img className='botton' src={FooterIcon} alt="footer"/></a>
            </div>
        </Container>
    );
};