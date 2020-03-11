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
                {compId: '', 
                value: ''}
            ]
        });
        
    const initProfile = (user) => {

         setProfile(user);
         
     } 

     const updateCompetences = (competence) => {
         setProfile({...profile, competences: [...profile.competences, competence]})
     }

    const handleChange = (event) => {
        event.preventDefault();
        setProfile({...profile, [event.target.name]: event.target.value}); 
     }

     const actions = {
         updateCompetences,
         handleChange
     }

    return(
        <ProfileContext.Provider value={{profile, handleChange: handleChange, initProfile: initProfile, updateCompetences: updateCompetences}}>
                {children}
        </ProfileContext.Provider>
    )
}
 
export default ProfileContextProvider;