import React, {useState, useContext} from 'react';
import {ProfileContext} from '../../Context/PofileContext';
import axios from 'axios';



const UploadCV = () => {
    const [file, setFile] = useState(null);
    const {handleUploadResume} = useContext(ProfileContext);
    
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
            handleUploadResume(file.name);
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