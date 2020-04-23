import React, { Component } from 'react';
import { Container, Navbar, NavbarBrand } from 'reactstrap';
import { Link } from 'react-router-dom';
import ConsidLogo from '../../images/consid_logo_big.png';
import '../../css/NavMenu.css';

class NavMenu extends Component {
    constructor(props) {
        super(props);

        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = {
            collapsed: true
        };
    }

    toggleNavbar () {
        this.setState({
            collapsed: !this.state.collapsed
        });
    }

    render(props) {
        return (
            <header>
                <Navbar className='navbar-expand-sm navbar-toggle-sm ng-white border-bottom box-shadow' light>
                    <Container>
                        <NavbarBrand className='NavbarLogo' tag={Link} to='/'><img className='ConsidLogoBig' src={ConsidLogo} alt="Consid logo"/></NavbarBrand>
                    </Container>
                </Navbar>
            </header>
        ) 
    } 
}

export default NavMenu;
