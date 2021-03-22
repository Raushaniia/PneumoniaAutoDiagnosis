import React from "react";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import PatientCard from "./patient-card";
import PatientCardUpdate from "./patient-card-update";
import { authProvider } from "./../auth/authProvider";


const BrowserRouter = require('react-router-dom').BrowserRouter;
const hashHistory = require('react-router-dom').hashHistory;
const ReactDOM = require('react-dom');

let patientId;
let patientName;
let patientDate;
let patientStatus;

function setPatient(id, name, date, status) {
  patientId = id;
  patientName = name;
  patientDate = date;
  patientStatus = status;
}

function deletePatient(id) {
  authProvider.getAccessToken().then(res => 
    fetch("https://pneumoniaautodiagnosis20210322205459.azurewebsites.net/api/patient/" + id,
    {
      method: "DELETE",
      headers: 
      { 
        'Authorization': `Bearer ${res.accessToken}`
       }
    }
    ))
      .then((res) => res.json())
      .then((data) => {
        this.setState({
            patients: data.filter((contact) => contact.id !== id),
        });
      })
      
      .catch(console.log);
  }

class Patients extends React.Component {
    constructor() {
      super()
      this.state = { 
        patients: [] }
    }
  

    componentDidMount() {
     authProvider.getAccessToken().then(res => 
        fetch('https://pneumoniaautodiagnosis20210322205459.azurewebsites.net/api/patient',//'https://localhost:44399/api/patient',
        {
          method: "GET",
          headers: 
          { 
            'Authorization': `Bearer ${res.accessToken}`, 
            'Accept': 'application/json',
           }
        }
        ))
        .then(res => res.json())
        .then((data) => {
          this.setState({ patients: data })
        })
        .catch(console.log)
      }

 render(){
  return (
      <body>
      <Router history={hashHistory}>
        <Route
          path="/patients"
          exact
          render= {() => (
            <div>
              <nav class="navbar navbar-expand-lg navbar-light bg-light">
                <div class="container-fluid">
                  <button
                    class="navbar-toggler"
                    type="button"
                    data-bs-toggle="collapse"
                    data-bs-target="#navbarTogglerDemo03"
                    aria-controls="navbarTogglerDemo03"
                    aria-expanded="false"
                    aria-label="Toggle navigation"
                  >
                    <span class="navbar-toggler-icon"></span>
                  </button>
                  <a class="navbar-brand" href="#">
                    Pneumonia Auto diagnosis
                  </a>
                  <Link
                    to="/add-patient"
                    class="btn btn-success me-md-2"
                    type="button"
                  >
                    Add a new patient
                  </Link>
                  <div
                    class="collapse navbar-collapse"
                    id="navbarTogglerDemo03"
                  >
                    <form class="col-12 d-flex  justify-content-end">
                      <input
                        class="form-control me-2"
                        type="search"
                        placeholder="Search"
                        aria-label="Search"
                      />
                      <Link
                        class="btn btn-outline-success"
                        to="/about"
                        type="submit"
                      >
                        Search
                      </Link>
                    </form>
                  </div>
                </div>
              </nav>
              <div class="container">
                <div class="row">
                  <div class="col-2"></div>
                  <div class="col-8">
                    <center>
                      <h1 class="h3 mb-3 fw-normal">Patient list:</h1>
                    </center>
                  </div>
                  <div class="col-2"></div>
                </div>
                <div class="row">
                  <div class="col-2"></div>
                  <div class="col-8">
                    <table class="table table-striped">
                      <thead>
                        <tr>
                          <th scope="col">#</th>
                          <th scope="col">Name</th>
                          <th scope="col">Date Of Birth</th>
                          <th scope="col">Status</th>
                          <th scope="col">Update</th>
                          <th scope="col">Remove</th>
                        </tr>
                      </thead>
                      <tbody>
                        {this.state.patients.map((contact) => (
                          <tr>
                            <th scope="row">1</th>
                            <td>{contact.name}</td>
                            <td>{contact.dateOfBirth}</td>
                            <td>{contact.status}</td>
                            <td>
                              {" "}
                              <Link
                                to="/update-patient/"
                                onClick={() =>
                                  setPatient(
                                    contact.id,
                                    contact.name,
                                    contact.dateOfBirth,
                                    contact.status
                                  )
                                }
                                class="btn btn-success"
                                type="button"
                              >
                                Update
                              </Link>
                            </td>
                            <td>
                              <button
                                onClick={() => deletePatient(contact.id)}
                                class="btn btn-danger"
                                type="button"
                              >
                                Remove
                              </button>
                            </td>
                          </tr>
                        ))}
                      </tbody>
                    </table>
                  </div>
                  <div class="col-2"></div>
                </div>
              </div>
            </div>
          )}
        />
        <Route path="/add-patient" component={PatientCard} />
        <Route
          path="/update-patient"
          render={() => (
            <PatientCardUpdate
              id={patientId}
              name={patientName}
              date={patientDate}
              status={patientStatus}
            ></PatientCardUpdate>
          )}
        />
      </Router>
      </body>
  )};
};

export default Patients
