import React, {useState, useContext} from 'react';
import TextField from '@material-ui/core/TextField';
import {ProfileContext} from '../../Context/PofileContext';


const Competense = (props) => {
  const [newItem, setNewItem] = useState("");
  const {profile, updateCompetences, deleteCompeteces} = useContext(ProfileContext);

  const handleButtonClick = () => {
    const id = Math.floor(Math.random() * 10);
    updateCompetences({compid: id, value: newItem});
    setNewItem('')
  }

  const handleDelete = (compId) => {
    deleteCompeteces(compId);
  }
  
  const competences = profile.competences || [];

  return (
        <div>
            <TextField
              style={{display: 'block', margin: '10px'}}
              label="Kompetens"
              id="mui-theme-provider-standard-input"
              name='competences'
              type="text"
              value={newItem}
              onChange={e => setNewItem(e.target.value)} />
            <button
              className="add-btn"
              onClick={handleButtonClick}
              >Lägg till
            </button>
            <div className='competense-container'>
                {competences.map((item, i) => {
                return (
                  <div key={i} className='competense-output'>
                    {item.value}
                    <button 
                      className='delete-competense' 
                      onClick={() => handleDelete(item.compId)}>X
                      </button>
                  </div>
                );
              })}
            </div>
        </div>
    );
}

 export default Competense;

