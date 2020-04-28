import React, {useState, useContext} from 'react';
import {ProfileContext} from '../../Context/PofileContext';
import axios from 'axios';

const UploadCV = () => {
    const [file, setFile] = useState(null);
    const {profile, handleUploadResume} = useContext(ProfileContext);
    const jwt = localStorage.getItem('secret');
    const cvMessage = document.getElementById('cvMessage');
    const cvdoneMessage = document.getElementById('cvdoneMessage');
    
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
          handleUploadResume(file.name);
          cvMessage.style.display = 'none';
          axios.put('https://localhost:44323/api/profile/UploadResume', fd, { headers: { 'Authorization': `Bearer ${jwt}` }})
          .then((res) => {
            cvdoneMessage.style.display = 'block';
        })
        }
    }

    return(
      <div className='cv-container'>
        <div className='input-container'>
            <input style={{display: 'none'}} id='upload' type="file" onChange={fileSelectedHandler}/>
            <label className='cv-input' htmlFor="upload">Ladda upp CV</label>
            {file ? 
                (<label className='uploaded-file'>{file.name}</label>)
              : (<label className='uploaded-file'>{profile.resumeUrl}</label>)
            }   
        </div>
        <div className='cv-button-container'>
            <button className="add-btn-cv" onClick={fileUploadHandler}>Lägg till</button>
             <label className='message' id='cvMessage' style={{display: 'none'}}>Du måste välja fil först!</label>
             <label className='doneMessage' id='cvdoneMessage' style={{display: 'none'}}>Din fil är sparad!</label>
        </div>  
      </div>
    )
}

export default UploadCV;