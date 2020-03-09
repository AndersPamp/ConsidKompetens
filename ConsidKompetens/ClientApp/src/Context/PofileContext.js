import React, { useState, createContext } from 'react';

export const ProfileContext = createContext();

const ProfileContextProvider = ({children}) => {
    const [ profile, setProfile ] = useState({
            firstName: '', 
            lastName: '', 
            aboutMe: '',
            linkedInUrl: '',
            position: '',
            office: '',
            resumeUrl: '',
            imageModel: '',
            competences: [
                {id: [0], 
                value: ''}
            ]
        });
        
    const initProfile = (user) => {
         setProfile(user);
     } 
    const handleChange = (event) => {
        event.preventDefault();
        setProfile({...profile, [event.target.name]: event.target.value}); 
     }

    return(
        <ProfileContext.Provider value={{...profile, handleChange: handleChange, initProfile: initProfile}}>
                {children}
        </ProfileContext.Provider>
    )
}
 
export default ProfileContextProvider;