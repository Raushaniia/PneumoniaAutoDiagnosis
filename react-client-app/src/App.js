import React, { Component } from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";
import Login from "./components/login.component";
import SignUp from "./components/signup.component";
import Patients from "./components/patients";
import PatientCard from "./components/patient-card";
import PatientCardUpdate from "./components/patient-card-update";
import { useHistory } from "react-router-dom"; 

const ReactDOM = require('react-dom');
const BrowserRouter = require('react-router-dom').BrowserRouter;
const hashHistory = require('react-router-dom').hashHistory;

class App extends Component {
  render() {
    return (<Router history={hashHistory}>
      <div className="App">
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
              <ul className="navbar-nav ml-auto">
                <li className="nav-item">
                  <Link className="nav-link" to={"/sign-in"}>Login</Link>
                </li>
                <li className="nav-item">
                  <Link className="nav-link" to={"/sign-up"}>Sign up</Link>
                </li>
              </ul>
        </nav>
        <div className="auth-wrapper">
          <div className="auth-inner">
            <Switch>
              <Route exact path='/' component={SignUp} />
              <Route path="/sign-in" component={Login} />
              <Route path="/sign-up" component={SignUp} />
              <Route path="/patients" component={Patients} />
              <Route path="/add-patient" component={PatientCard} />
              <Route path="/update-patient" component={PatientCardUpdate} />
            </Switch>
          </div>
        </div>
      </div></Router>
    );
  }
}



export default App;