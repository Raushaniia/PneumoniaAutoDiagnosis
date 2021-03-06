import React, { Component } from 'react';
import { authProvider } from "./../auth/authProvider";
import * as Constants from './../appsettings';

const ReactDOM = require('react-dom');
const Route = require('react-router-dom').Route;
const BrowserRouter = require('react-router-dom').BrowserRouter;
const hashHistory = require('react-router-dom').hashHistory;

class PatientCard extends Component {
  constructor(props) {
    super(props);
  }
  render() {
    return (
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
            <div
              class="collapse navbar-collapse"
              id="navbarTogglerDemo03"
            ></div>
          </div>
        </nav>
        <div class="container">
          <div class="row">
            <div class="col-2"></div>
            <div class="col-8">
              <center>
                <h1 class="h3 mb-3 fw-normal">Add patient:</h1>
              </center>
            </div>
            <div class="col-2"></div>
          </div>
          <div class="row">
            <div class="col-2"></div>
            <div class="col-8">
              <form class="row g-5">
                <div class="col-12">
                  <label for="inputAddress" class="form-label">
                    Full Name
                  </label>
                  <input
                    type="text"
                    class="form-control"
                    id="inputName"
                    placeholder="Sam Smith"
                  />
                </div>
                <div class="col-12">
                  <label for="inputAddress" class="form-label">
                    Date Of Birth
                  </label>
                  <input
                    type="text"
                    class="form-control"
                    id="inputDate"
                    placeholder="01/31/2000"
                  />
                </div>
                <div class="col-9">
                  <div class="form-check">
                    <input
                      class="form-check-input"
                      type="checkbox"
                      id="gridCheck"
                    />
                    <label class="form-check-label" for="gridCheck">
                      Pneumonia status
                    </label>
                  </div>
                </div>
                <div class="col-9">
                  <button
                    onClick={() =>
                      addPatient(
                        document.getElementById("inputName").value,
                        document.getElementById("inputDate").value,
                        document.getElementById("gridCheck").checked ? 1 : 0
                      )
                    }
                    type="submit" class="btn btn-success">
                    Save
                  </button>
                </div>
              </form>
            </div>
            <div class="col-2"></div>
          </div>
        </div>
      </div>
    );
  }
}
 
function addPatient(newName, newDateOfBirh, status) {
  const patient = {
    Name: newName,
    DateOfBirth: new Date(),
    Status: status,
  };
  var d = authProvider.getAccessToken().catch(console.log);
  authProvider.getAccessToken().then(res => 
    fetch(Constants.url +"api/patient/",
    {
      method: "POST",
      headers: 
      { 
        "Content-Type": "application/json",
        'Authorization': `Bearer ${res.accessToken}`, 
       },
       body: JSON.stringify(patient),
    }
    ))
    .catch(console.log);

}

export default PatientCard;