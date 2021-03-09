import React, { Component } from "react";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import Patients from './patients';

class SignUp extends Component {
    
    render() {
        return ( 
            <Router>
            <Route
              path="/sign-up"
              exact
              render={(props) => (
                <div className="auth-wrapper">
                <div className="auth-inner">
            <form>
                <h3>Sign Up</h3>
                <div className="form-group">
                    <label>First name</label>
                    <input type="text" id="inputFirstName" className="form-control" placeholder="First name" />
                </div>

                <div className="form-group">
                    <label>Last name</label>
                    <input type="text" id="inputLastName" className="form-control" placeholder="Last name" />
                </div>

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
                            addUser(
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
            </div>
          )}
        />
        <Route path="/patients" component={Patients} />
      </Router>
        );
    }
}

function addUser(email, password) {
    const patient = {
      Email: email,
      Password: password   
    };
    fetch("https://localhost:44399/api/user/", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(patient),
    })
    .catch(console.log);
  }


  export default SignUp;