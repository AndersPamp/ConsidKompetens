import React, {useContext} from 'react';
import { makeStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import {ProfileContext} from '../../Context/PofileContext';
import axios from 'axios';

const useStyles = makeStyles(theme => ({
  root: {
    display: 'flex',
    flexWrap: 'wrap',
  },
  margin: {
    margin: theme.spacing(1),
  },
  formControl: {
    margin: theme.spacing(1),
    minWidth: 120,
  }
}));

const UploadCV = () => {
    const classes = useStyles();
    const {profile, handleChange} = useContext(ProfileContext);
    const user = profile;
    const jwt = localStorage.getItem('secret');

    const handleUpload = () => {
      const file = user;
      const formdata = new FormData();
      formdata.append('image', file);

      axios.put('https://localhost:44323/api/profile/UploadResume', formdata, { headers: { 'Authorization': `Bearer ${jwt}` }})
       .then((response) => {
         console.log(response)
       }).catch(error => console.log(error))
    }

    return (
        <>
        <form onChange={() => handleUpload}>
            <TextField
                className={classes.margin}
                style={{display: 'block', margin: '25px 5px 5px 5px'}}
                type='file'
                id="mui-theme-provider-standard-input four"
                name='resumeUrl'
                value={profile.resumeUrl || ''}
                onChange={handleChange}  
                />
            <label className='load-cv'>Ladda upp CV</label>
        </form>
            
        </>
    )
}

// class UploadCV extends Component {

//   state = {
//     file: null
//   }

//   static contextType = ProfileContext;
  

//   handleFile(e){

//     let file = e.target.files[0];

//     this.setState({file: file});
//     console.log(file);
//   }

//   handleUpload(e){
//       const jwt = localStorage.getItem('secret');
//       let file = this.state.file;
//       let formdata = new FormData();
//       formdata.append('image', file);

//       axios.put('https://localhost:44323/api/profile/UploadResume', formdata, { headers: { 'Authorization': `Bearer ${jwt}` }})
//       .then((response) => {
//         console.log(response)
//       }).catch(error => console.log(error))
     
//   }

//   render(){
//     const profile = this.context;
//     profile.resumeUrl = this.state.file;

//     return(
//       <div>
//         <form onChange={e => this.handleFile(e)}>
//           <div>
//             <input type="file" name="resumeUrl" />
//             <button type='button' onClick={(e) => this.handleUpload(e)}>Upload</button>
//           </div>
//         </form>
//       </div>
//     )
//   }
// }

export default UploadCV;