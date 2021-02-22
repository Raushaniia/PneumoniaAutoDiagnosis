import React, { Component } from "react";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import Patients from './patients';
import { useHistory } from "react-router-dom"; 
const BrowserRouter = require('react-router-dom').BrowserRouter;
const hashHistory = require('react-router-dom').hashHistory;
const ReactDOM = require('react-dom');

export default class Login extends Component {
    render() {
        return ( 
            <Router history={hashHistory}>
            <Route
              path="/sign-in"
              exact
              render={(props) => (
                <div>
            <form>
                <h3>Sign In</h3>
               
                <div className="form-group">
                    <label>Email address</label>
                    <input type="email" id="inputEmail" className="form-control" placeholder="Enter email" />
                </div>

                <div className="form-group">
                    <label>Password</label>
                    <input type="password" id="inputPassword" className="form-control" placeholder="Enter password" />
                </div>
                <Link
                        class="btn btn-outline-success"
                        to="/patients"
                        type="submit"
                        onClick={() =>
                            logInUser(
                              document.getElementById("inputEmail").value,
                              document.getElementById("inputPassword").value
                            )}
                      >
                        Search
                      </Link>
                <p className="forgot-password text-right">
                    Already registered <a href="#">sign in?</a>
                </p>
            </form>
            </div>
          )}
        />
        <Route path="/patients" component={Patients} />
      </Router>
        );
    }
}
function logInUser(email, password) {
    const patient = {
      Email: email,
      Password: password   
    };
    fetch("https://localhost:44399/api/user/", {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
      //body: JSON.stringify(patient),
    })
    .catch(console.log);
  }



