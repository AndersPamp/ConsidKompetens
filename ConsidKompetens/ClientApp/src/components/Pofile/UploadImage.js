import React from 'react';

const UploadImage = () => {
    return(
        <>
        <div className='img-container'>
            <img className='user-img'
                src='https://upload.wikimedia.org/wikipedia/commons/5/59/That_Poppy_profile_picture.jpg'
                alt="ladda upp bild"/>
        </div>
        <div>
            <form >
                {/* <input type="file" /> */}
                <button type='submit' className='load-img-button'>Ladda upp bild</button>
            </form>
        </div>
        </>
    )
}

export default UploadImage;