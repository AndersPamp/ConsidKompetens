import React, { useState, createContext } from 'react';

export const ProfileContext = createContext();

const ProfileContextProvider = ({children}) => {
    const [ profile, setProfile ] = useState({
            firstName: '', 
            lastName: '', 
            aboutMe: '',
            linkedInUrl: '',
            position: '',
            OfficeModelId: '',
            resumeUrl: '',
            imageModel: {
                url: '',
                alt: ''
            },
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

     const deleteCompeteces = (id) => {
         const list = [...profile.competences];
         const updateArray = list.filter(item => item.compId !== id);
         setProfile({...profile, competences: updateArray});
     }

    const handleChange = (event) => {
        event.preventDefault();
        setProfile({...profile, [event.target.name]: event.target.value}); 
     }

     const handleUploadResume = (resume) => {
         setProfile({...profile, resumeUrl: resume})
         debugger
     }

     const handleUploadImage = (image) => {
         setProfile({...profile, imageModel: {image}})
         console.log(profile)
         debugger
     }

    //  const actions = {
    //      updateCompetences,
    //      handleChange,
    //  }

    return(
        <ProfileContext.Provider value={{profile, 
            handleChange: handleChange, 
            initProfile: initProfile, 
            updateCompetences: updateCompetences,
            deleteCompeteces: deleteCompeteces,
            handleUploadResume: handleUploadResume,
            handleUploadImage: handleUploadImage}}>
                {children}
        </ProfileContext.Provider>
    )
}
 
export default ProfileContextProvider;