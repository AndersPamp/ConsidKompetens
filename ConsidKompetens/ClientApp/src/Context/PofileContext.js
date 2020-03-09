import React, { useState, createContext } from 'react';

export const ProfileContext = createContext();

const ProfileContextProvider = ({children}) => {
    const [ profile, setProfile ] = useState({
            firstName: '', 
            lastName: '', 
            aboutMe: '',
            linkedIn: '',
            title: '',
            office: '',
            cv: '',
            imageModel: '',
            competense: []
        });
        
     
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