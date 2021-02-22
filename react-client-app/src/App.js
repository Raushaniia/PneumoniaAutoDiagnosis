import React, { Component } from 'react';
import Contacts from './components/contacts';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";
const ReactDOM = require('react-dom');
const BrowserRouter = require('react-router-dom').BrowserRouter;
const hashHistory = require('react-router-dom').hashHistory;


class App extends Component {
  state = {
    contacts: []
  }
  
  componentDidMount() {
    fetch('https://localhost:44399/api/patient')
    .then(res => res.json())
    .then((data) => {
      this.setState({ contacts: data })
    })
    .catch(console.log)
  }


  render() {
    return (
      <Contacts contacts={this.state.contacts} />  
          
    );
  }
}



export default App;