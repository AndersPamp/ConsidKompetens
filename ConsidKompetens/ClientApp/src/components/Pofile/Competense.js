//import React, {useState, useContext} from 'react';
import React, {Component} from 'react';
import TextField from '@material-ui/core/TextField';
import { makeStyles } from '@material-ui/core/styles';
import {ProfileContext} from '../../Context/PofileContext';

const useStyles = makeStyles(theme => ({
  root: {
    display: 'flex',
    flexWrap: 'wrap',
  },
  margin: {
    margin: theme.spacing(1),
  },
  formControl: {
    margin: theme.spacing(1),
    minWidth: 120,
  }
}));

class Competense extends Component {
  constructor(props) {
    super(props);
    this.state = {
      newItem: "",
      list: []
    };
  }

  static contextType = ProfileContext;
 
   updateInput(key, value) {
    // update react state
    this.setState({ [key]: value });
  }

  addItem() {
    // create a new item with unique id
    const newItem = {
      id: 1 + Math.random(),
      value: this.state.newItem.slice()
 
    };

    // copy current list of items
    const list = [...this.state.list];

    // add the new item to the list
    list.push(newItem);

    // update state with new list, reset the new item input
    this.setState({
      list,
      newItem: ""
    });
  }

  deleteItem(id) {
    // copy current list of items
    const list = [...this.state.list];
    // filter out the item being deleted
    const updatedList = list.filter(item => item.id !== id);

    this.setState({ list: updatedList });
  }
  
  render() {
    
     const profile = this.context;
    profile.competense = this.state.list;
    console.log(profile);

    return (
        <div>
         <TextField
                
                style={{display: 'block', margin: '10px'}}
                label="Kompetens"
                id="mui-theme-provider-standard-input"
                name='Competense'
                type="text"
                value={this.state.newItem}
                onChange={e => this.updateInput("newItem", e.target.value)} 
             />
          {/* <input
            type="text"
            placeholder="Type item here"
            value={this.state.newItem}
            onChange={e => this.updateInput("newItem", e.target.value)}
          /> */}
          <button
            className="add-btn btn-floating"
            onClick={() => this.addItem()}
            disabled={!this.state.newItem.length}
          >
           + 
          </button>
          <br /> <br />
          <ul>
            {this.state.list.map(item => {
              return (
                <li key={item.id}>
                  {item.value}
                  <button onClick={() => this.deleteItem(item.id)}>
                    x
                  </button>
                </li>
              );
            })}
          </ul>
        </div>
    );
  }
}

export default Competense;

// const Competense = () => {
//     const classes = useStyles();
//     const user = useContext(ProfileContext);
//     //const {handleChange} = useContext(ProfileContext);

//     const [newItem, setNewItem] = useState(''); //newItem
//     console.log(user.competense); //list

//     function updateInput(key, value) {
//       this.setNewItem({ [key]: value})
//     }

//     function addItem() {
//       const newItem = {
//         id: 1 + Math.random(),
//         value: newItem.slice()
//       }

//       const list = [...user.competense];
//       list.push(newItem);

//       setNewItem({
//         list,
//         newItem:""
//       });
//     }

//     function deleteItems(id) {
//         const list = [...user.competense];

//         const updateList = list.filter(item => item.id !== id);

//         setNewItem({list: updateList});
//     }

//   return(
//     <>
//             <TextField
//                className={classes.margin}
//                  style={{display: 'block'}}
//                  label="Kompetens"
//                  id="mui-theme-provider-standard-input"
//                  name='Competense'
//                  value={user.Competense}
//                  onChange={e => updateInput('newItem', e.target.value)}  
//              />
//              <button onClick={() => addItem()}>Add</button>
//              <div className='competense-container'>
//                     {user.competense.map(item => (
//                       <div className='competense-output' key={item.id}>
//                       {item.value}
//                       <button onClick={() => deleteItems(item.id)}>X</button>
//                       </div>
                      
//                     ))}
//               </div> 
//     </>
//   )
// }

// export default Competense;

// const useInputValue = initialValue => {
    
//     const [value, setValue] = useState(initialValue);

//     return{
//         value, 
//         onChange: e => setValue(e.target.value),
//         resetValue: () => setValue("")
//     };
// };

// const Competense = ({onSubmit}) => {
//     const classes = useStyles();
//     const { resetValue, ...text } = useInputValue('');

//     const user = useContext(ProfileContext);
//     const {handleChange} = useContext(ProfileContext);

//     function submitHandler(e) {
//         e.preventDefault();
//         onSubmit(text.value);
//         resetValue();
//     }

//     return(
//         <form onSubmit={submitHandler}>
//              <TextField
//                 className={classes.margin}
//                 style={{display: 'block'}}
//                 label="Kompetens"
//                 id="mui-theme-provider-standard-input"
//                 name='Competense'
//                 value={user.Competense}
//                 onChange={handleChange}  
//                 {...text}
//             />
//         </form>
//     )
// }

// export default Competense;


