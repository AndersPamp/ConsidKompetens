//import React, {useState, useContext} from 'react';
import React, {useState, useContext} from 'react';
import TextField from '@material-ui/core/TextField';
import {ProfileContext} from '../../Context/PofileContext';


const Competense = (props) => {
  const [newItem, setNewItem] = useState("");
  const {profile, updateCompetences} = useContext(ProfileContext);

  const handleButtonClick = () => {
    console.log("hello")
    const id = Math.floor(Math.random() * 10);
    updateCompetences({compid: id, value: newItem});
  }
  
  const competences = profile.competences || [];

  //  deleteItem(id) {
  //   const list = [...this.state.list];
  //   const updatedList = list.filter(item => item.id !== id);

  //   this.setState({ list: updatedList });
  // }


  return (
        <div>
            <TextField
                style={{display: 'block', margin: '10px'}}
                label="Kompetens"
                id="mui-theme-provider-standard-input"
                name='competences'
                type="text"
                value={newItem}
                onChange={e => setNewItem(e.target.value)} 
            />
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
                    <button className='delete-competense' onClick={() => this.deleteItem(item.compId)}>
                      X
                    </button>
                  </div>
                );
              })}
            </div>
        </div>
    );
}


// class Competense extends Component {
//   constructor(props) {
//     super(props);
//     this.state = {
//       newItem: "",
//       list: []
//     };
//   }

//   static contextType = ProfileContext;
 
//    updateInput(key, value) {
//     this.setState({ [key]: value });
//   }

//   addItem() {
//     const id = Math.floor(Math.random() * 10);
//     const newItem = {
//       value: this.state.newItem.slice()
//     };

//     const list = [...this.state.list];
//     list.push(newItem);
//     this.context.updateCompetences(newItem);

//     // this.setState({
//     //   newItem: "",
//     //   list: list
//     // });
//   }

//   componentWillUpdate(){
//     console.log("will update")
//     if(this.state.list.length !== this.context.competences.length){
//       this.setState({ list: this.context.competences});

//     }
//   }

//   deleteItem(compId) {
//     const list = [...this.state.list];
//     const updatedList = list.filter(item => item.compId !== compId);

//     this.setState({ list: updatedList });
//   }
  
//   const competences = this.context.competences;
//   console.log(comptences);
//   render() {
//     return (
//         <div>
//             <TextField
//                 style={{display: 'block', margin: '10px'}}
//                 label="Kompetens"
//                 id="mui-theme-provider-standard-input"
//                 name='competences'
//                 type="text"
//                 value={this.state.newItem}
//                 onChange={e => this.updateInput("newItem", e.target.value)} 
//             />
//             <button
//                 className="add-btn"
//                 onClick={() => this.addItem()}
//                 disabled={!this.state.newItem.length}>Lägg till
//             </button>
//             <div className='competense-container'>
//                 {competences.map((item, i) => {
//                 return (
//                   <div key={item.compId} className='competense-output'>
//                      {item.value}
//                     <button className='delete-competense' onClick={() => this.deleteItem(item.compId)}>
//                       X
//                     </button>
//                   </div>
//                 );
//               })}
//             </div>
//         </div>
//     );
//   }
// }

export default Competense;

