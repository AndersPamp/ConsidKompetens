import React, { useState, createContext } from 'react';

export const ProfileContext = createContext();

const ProfileContextProvider = ({children}) => {
    const [ profile, setProfile ] = useState({
            FirstName: '', 
            LastName: '', 
            AboutMe: '',
            LinkedIn: '',
            Title: '',
            Office: '',
            Cv: '',
            Competense: []
        })
     
    const handleChange = (event) => {
        event.preventDefault();
        setProfile({...profile, [event.target.name]: event.target.value});
     }

    return(
        <ProfileContext.Provider value={{...profile, handleChange: handleChange}}>
                {children}
        </ProfileContext.Provider>
    )
}
 
export default ProfileContextProvider;