import React from 'react';
import { Container } from 'reactstrap';
import { ThemeProvider, createMuiTheme } from '@material-ui/core/styles';
import offices from '../../Helper/Offices.json';
import HomeHeader from './HomeHeader';
import '../../css/Home.css';
import FormGroup from '@material-ui/core/FormGroup';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';

const theme = createMuiTheme({
  typography: {
    htmlFontSize: 12,
    fontFamily: [
      'Montserrat', 'sans-serif'
    ]
  }
});

const HomePage = () => {
    
    return(
        <>
        <div className="homeContainer">
           <HomeHeader/>
             <Container>
             <div className='list-container'>
             <h2>Välj kontor</h2>
               {offices.map(list => {
                   return(
                        <ThemeProvider theme={theme}>
                            <FormGroup style={{display: 'inline'}}>
                                <FormControlLabel
                                    control={
                                    <Checkbox
                                        value={list.office}
                                        color="error"
                                    />
                                    }
                                    label={list.office}
                                />
                            </FormGroup>
                        </ThemeProvider>
                   )
               })}
               <br/>
               <button>Sök</button>
               </div>
            </Container>
        </div>
        </>
    )
}

export default HomePage;

// import React from 'react';
// import { Container } from 'reactstrap';
// import offices from '../../Helper/Offices.json';
// import HomeHeader from './HomeHeader';
// import '../../css/Home.css';


// const HomePage = () => {
    
    
//     return(
//         <>
//         <div className="homeContainer">
//            <HomeHeader/>
//              <Container>
//                {offices.map(list => {
//                    return(
//                        <a className='office-list-a' href="/details" key={list.id}>
//                        <div className='office-list'>
//                            <h3>{list.office}</h3>
//                            <h6>Kullagatan 3</h6>
//                            <h6>25 486 Göteborg</h6>
//                            <h6>Tel: 256 256 265</h6>
//                        </div>
//                        </a>
//                    )
//                })}
              
//             </Container>
//         </div>
//         </>
//     )
// }

// export default HomePage;