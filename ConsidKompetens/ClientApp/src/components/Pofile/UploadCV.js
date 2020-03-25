import React, {useState, useContext} from 'react';
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
    const [file, setFile] = useState(null);
    const {profile, handleUploadResume} = useContext(ProfileContext);
    const resume = profile.resumeUrl || '';
    
    const jwt = localStorage.getItem('secret');
    const cvMessage = document.getElementById('cvMessage');
    
    function fileSelectedHandler(event) {
      const file = event.target.files[0];
      setFile(file);
    }

    function fileUploadHandler() {
       if(file === null){
                cvMessage.style.display = 'block';
          }else{
            const fd = new FormData();
            fd.append('file', file, file.name);
            handleUploadResume(file);
            cvMessage.style.display = 'none';
            axios.put('https://localhost:44323/api/profile/UploadResume', fd, { headers: { 'Authorization': `Bearer ${jwt}` }})
            .then((res) => {
            console.log(res.data.data.profileModels)
          })
        }
    }

    return(
      <div className='cv-container'>
       <label className='load-cv'>Ladda upp CV</label>
        <div className='input-container'>
            <input style={{display: 'none'}} id='upload' type="file" onChange={fileSelectedHandler}/>
            <label className='cv-input' htmlFor="upload">Välj fil</label>
            {file ? (<label className='uploaded-file'>{file.name}</label>): null}
        </div>
        <div className='cv-button-container'>
            <button className="add-btn" onClick={fileUploadHandler}>Lägg till</button>
             <label className='message' id='cvMessage' style={{display: 'none'}}>Du måste välja fil först!</label>
        </div>
        
      </div>
    )


}


export default UploadCV;