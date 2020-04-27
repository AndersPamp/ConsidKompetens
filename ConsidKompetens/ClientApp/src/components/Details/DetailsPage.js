import React, {useContext, useEffect, useState} from 'react';
import { Container } from 'reactstrap';
import Grid from '@material-ui/core/Grid';
import '../../css/Details.css';
import NavMenu from '../Header/NavMenu';
import {ProfileContext}  from '../../Context/PofileContext';
import SearchIcon from '../../images/SearchIconDark.png';
import { useHistory } from 'react-router-dom';
import axios from 'axios';

const DetailsPage = () => {

    const {chosenOffices, initProfileId, profile, initProfile} = useContext(ProfileContext);
    const [selected, setSelected] = useState([{id: ''}])
    const [loading, setLoading] = useState(true);
    const [input, setInput] = useState('');
    const [result, setResult] = useState([]);
    const [isReasult, setIsResult] = useState(false);
    const [dots, setDots] = useState(true);
    const baseUrlSerach = 'https://localhost:44323/api/search';
    
    const history = useHistory();
    useEffect(() => {
        function getOfficeId() {
            const officeids = chosenOffices.id;
            const jwt =localStorage.getItem('secret');
            axios.get('https://localhost:44323/api/office/profiles', {params: {officeids: officeids} ,headers: { 'Authorization': `Bearer ${jwt}` }})
            .then((response) => {
                const user = response.data.data.profileModels;
                initProfile(user);
                setLoading(false);
            }).catch(error => console.log(error));
        }
        getOfficeId();
    }, []);
 
   
        function getSearch() {
            const jwt = localStorage.getItem('secret');
            const officeids = [1];
            //const officeids = chosenOffices.id;
            const config = {
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${jwt}`
                }
            };
            const data = {
                officeids: officeids, input: input
            } ;
            
             
            axios.post('https://localhost:44323/api/search', data, config)
            .then((response) => {
                console.log(response.data.data.profileModels);
                setResult(response.data.data.profileModels);
                setIsResult(true);
            })
        }

    function getId(){
        const id = selected.id;
        initProfileId({id: id});
        setDots(false)
        history.push("/employee");
    }

    function handleChange(e) {
        setInput(e.target.value);
        console.log(input);
    }
    
    return (
          <div className="homeContainer">
            {!isReasult ? (<Container>
                <NavMenu/>
                    <h1 className='details-header'>{chosenOffices.city}</h1>
                    <input onChange={handleChange} className="homeInput" type="text" placeholder="Sök.."/>
                    <button className='search-button' onClick={getSearch}><img src={SearchIcon} alt="Search-icon"/></button>
                    {!loading ? (profile.map((user, i) =>
                    {
                        return(
                            <div className='container-list' key={i}>
                                <Grid container spacing={0}>
                                    <Grid item xs={5}>
                                        <div className='img-container'>
                                            <img className='user-img'
                                                    src='https://upload.wikimedia.org/wikipedia/commons/5/59/That_Poppy_profile_picture.jpg'
                                                    alt="developer"/>
                                        </div>
                                    </Grid>
                                    <Grid item xs={7}>
                                    <div className='details'>
                                        <h4 className='dev-name'>{user.firstName + ' ' + user.lastName}</h4>
                                        <h6>{user.position}</h6> 
                                        <h5 className='about'>Om mig:</h5>
                                        <label className='output-aboutMe' htmlFor="">{user.aboutMe}</label>
                                        <h5 className='about'>Kompetens:</h5>
                                        {user.competences.map((comp, x) => {
                                            return(<div key={x} className='competense-output'>{comp.value}</div>)})}
                                        {dots ? <button className='info-button' onClick={() => setSelected({id: user.id}, setDots(false))}>. . .</button> :
                                         <button className='info-button-more' onClick={getId}>Mer info +</button> } 
                                    </div>
                                    </Grid>
                                </Grid>
                            </div>
                        )}
                    )) : (
                        <div className='loading'>
                            <div className="d-flex justify-content-center">
                                <div className="spinner-border" role="status">
                                <span className="sr-only">Loading...</span>
                                </div>
                            </div>
                        </div>
                    )}
            </Container>) : 
            (<Container>
                <NavMenu/>
                    <h1 className='details-header'>{chosenOffices.city}</h1>
                    <input onChange={handleChange} className="homeInput" type="text" placeholder="Sök.."/>
                    <button className='search-button' onClick={getSearch}><img src={SearchIcon} alt="Search-icon"/></button>
                    {!loading ? (result.map((user, i) =>
                    {
                        return(
                            <div className='container-list' key={i}>
                                <Grid container spacing={0}>
                                    <Grid item xs={5}>
                                        <div className='img-container'>
                                            <img className='user-img'
                                                    src='https://upload.wikimedia.org/wikipedia/commons/5/59/That_Poppy_profile_picture.jpg'
                                                    alt="developer"/>
                                        </div>
                                    </Grid>
                                    <Grid item xs={7}>
                                    <div className='details'>
                                        <h4 className='dev-name'>{user.firstName + ' ' + user.lastName}</h4>
                                        <h6>{user.position}</h6> 
                                        <h5 className='about'>Om mig:</h5>
                                        <label className='output-aboutMe' htmlFor="">{user.aboutMe}</label>
                                        <h5 className='about'>Kompetens:</h5>
                                        {user.competences.map((comp, x) => {
                                            return(<div key={x} className='competense-output'>{comp.value}</div>)})}
                                        {dots ? <button className='info-button' onClick={() => setSelected({id: user.id}, setDots(false))}>. . .</button> :
                                         <button className='info-button-more' onClick={getId}>Mer info +</button> } 
                                    </div>
                                    </Grid>
                                </Grid>
                            </div>
                        )}
                    )) : (
                        <div className='loading'>
                            <div className="d-flex justify-content-center">
                                <div className="spinner-border" role="status">
                                <span className="sr-only">Loading...</span>
                                </div>
                            </div>
                        </div>
                    )}
            </Container>)
            }
        </div>
    )
}

export default DetailsPage;
