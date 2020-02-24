import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink} from 'reactstrap';
import { Link } from 'react-router-dom';
import ConsidLogo from '../../images/consid_logo_big.png';
import '../../css/NavMenu.css';

class NavMenu extends Component {
    constructor(props) {
        super(props);

        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = {
            collapsed: true,
            loggedIn: false
        };
    }

    toggleNavbar () {
        this.setState({
            collapsed: !this.state.collapsed
        });
    }

    handleLogOut() {
        localStorage.removeItem('secret');
        this.setState({loggedIn: false });
         alert('logged out');
        this.props.history.push('/login');
    }

    render(props) {

        const user = localStorage.getItem('secret');

        return (
            <header>
                <Navbar className='navbar-expand-sm navbar-toggle-sm ng-white border-bottom box-shadow' light>
                    <Container>
                        <NavbarBrand className='NavbarLogo' tag={Link} to='/'><img className='ConsidLogoBig' src={ConsidLogo} alt="Consid logo"/></NavbarBrand>
                        <NavbarToggler onClick={this.toggleNavbar} className='mr-2'/>
                        <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
                            <ul className='navbar-nav flex-grow'>
                                    <NavItem>
                                        <NavLink tag={Link} className='text-dark links' to='/user'>Min sida</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink tag={Link} className='text-dark links' to='/login'>Logout</NavLink>
                                    </NavItem>
                            </ul>
                        </Collapse>
                    </Container>
                </Navbar>
            </header>
        ) 
    }
   
}

export default NavMenu;
