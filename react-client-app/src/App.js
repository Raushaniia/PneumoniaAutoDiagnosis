import React, { Component } from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route
} from "react-router-dom";
import Patients from "./components/patients";
import PatientCard from "./components/patient-card";
import PatientCardUpdate from "./components/patient-card-update";

const hashHistory = require('react-router-dom').hashHistory;

class App extends Component {
  render() {
    return (<Router history={hashHistory}>
      <div className="App">
        <div id="fon"></div>
            <Switch>
              <Route exact path='/' component={Patients} />          
              <Route path="/patients" component={Patients} />
              <Route path="/add-patient" component={PatientCard} />
              <Route path="/update-patient" component={PatientCardUpdate} />
            </Switch>
      </div></Router>
    );
  }
}

export default App;