//import React, {useState, useContext} from 'react';
import React, {Component} from 'react';
import TextField from '@material-ui/core/TextField';
import {ProfileContext} from '../../Context/PofileContext';



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
    this.setState({ [key]: value });
  }

  addItem() {
    const newItem = {
      compId: 1 + Math.random(),
      value: this.state.newItem.slice()
    };

    const list = [...this.state.list];
    list.push(newItem);

    this.setState({
      list,
      newItem: ""
    });
  }

  deleteItem(compId) {
    const list = [...this.state.list];
    const updatedList = list.filter(item => item.compId !== compId);

    this.setState({ list: updatedList });
  }
  
  render() {
    
     const profile = this.context;
    profile.competences = this.state.list;
    console.log(profile);

    return (
        <div>
            <TextField
                style={{display: 'block', margin: '10px'}}
                label="Kompetens"
                id="mui-theme-provider-standard-input"
                name='competences'
                type="text"
                value={this.state.newItem}
                onChange={e => this.updateInput("newItem", e.target.value)} 
            />
            <button
                className="add-btn"
                onClick={() => this.addItem()}
                disabled={!this.state.newItem.length}>Lägg till
            </button>
            <div className='competense-container'>
                {this.state.list.map(item => {
                return (
                  <div key={item.compId} className='competense-output'>
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
}

export default Competense;

