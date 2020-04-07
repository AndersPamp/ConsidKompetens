import React, { useState, createContext } from 'react';

export const ProfileContext = createContext();

const ProfileContextProvider = ({children}) => {
    const [ chosenOffices, setChosenOffices ] = useState({
            
            office:    {id: '', 
                city: ''}
            
    });
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

     const initChosenOffice = (offices) => {
         setChosenOffices(offices);
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
     }

     const handleUploadImage = (image) => {
         setProfile({...profile, imageModel: {image}})
     }

    //  const actions = {
    //      updateCompetences,
    //      handleChange,
    //  }

    return(
        <ProfileContext.Provider value={{profile, chosenOffices, 
            handleChange: handleChange, 
            initProfile: initProfile, 
            updateCompetences: updateCompetences,
            deleteCompeteces: deleteCompeteces,
            handleUploadResume: handleUploadResume,
            handleUploadImage: handleUploadImage,
            initChosenOffice: initChosenOffice}}>
                {children}
        </ProfileContext.Provider>
    )
}
 
export default ProfileContextProvider;