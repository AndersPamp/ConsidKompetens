import React, {useState, useContext} from 'react';
import {ProfileContext} from '../../Context/PofileContext';
import axios from 'axios';

const UploadImage = () => {

    const {handleUploadImage} = useContext(ProfileContext);
    const [image, setImage] = useState(null);
    const jwt = localStorage.getItem('secret');
    const previewImage = document.getElementById("image-preview__image");
    const previwDefaultText = document.getElementById('image-preview__default-text');
    const message = document.getElementById('message');

    

     function fileSelectedHandler(event) {
        const file = event.target.files[0]
        setImage(file);

        if(file){
          
          const reader = new FileReader();

          previwDefaultText.style.display = 'none';
          previewImage.style.display = 'block';

          reader.addEventListener('load', function() {
              previewImage.setAttribute('src', this.result)
          });

          reader.readAsDataURL(file);  
        }else{
            previwDefaultText.style.display = null;
            previewImage.style.display = null; 
            previewImage.setAttribute('src', '')
        }
    }

    function fileUploadHandler() {
        if(image === null){
                message.style.display = 'block';
            }else{
                
                const fd = new FormData();
                fd.append('file', image, image.name);
                handleUploadImage({url: image.name, alt: 'profile pic'})
                debugger
                message.style.display = 'none';
                axios.put('https://localhost:44323/api/profile/UploadImage', fd, { headers: { 'Authorization': `Bearer ${jwt}` }})
                .then((response) => {
                console.log(response)
                }).catch(error => console.log(error))
            }
    }

    return(
        <div>
            <div className='img-container'>
                <div className='image-preview' id='imagePreview'>
                    <img src='' alt="Image preview" id='image-preview__image' className='image-preview__image'/>
                    <span id='image-preview__default-text' className='image-preview__default-text'>Bild</span>
                </div>
                <div className='upload-img'>
                    <input style={{display: 'none'}}  type="file" id='inpFile' name='inpFile' accept='image/*' onChange={fileSelectedHandler}/>
                    <label className='img-input' style={{display:'block'}} htmlFor="inpFile">Välj bild</label>
                    <button className="add-btn" onClick={fileUploadHandler}>Lägg till</button>
                    <label className='message' id='message' style={{display: 'none'}}>Du måste välja bild först!</label>
                </div>
            </div>
        </div>
    )
}

export default UploadImage;