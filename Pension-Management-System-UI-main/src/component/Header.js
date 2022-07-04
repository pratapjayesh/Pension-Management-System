import React, { Component } from "react";
import "../style/Header.scss";
import Button from "react-bootstrap/Button";
class Header extends Component {
  constructor(props) {
    super(props);
    this.state = {
      userName: "",
      token: localStorage.getItem("token"),
    };
  }
  handelLogin = () => {
    window.location.href = window.location.origin + "/Login";
  };
  handelSignUp = () => {
    window.location.href = window.location.origin + "/";
  };

  handelLogout = () => {
    localStorage.clear();
    sessionStorage.clear();
    this.clearCookie();
    window.location.href = window.location.origin + "/Login";
  };

  clearCookie = () => {
    document.cookie.split(";").forEach(function (c) {
      document.cookie = c
        .replace(/^ +/, "")
        .replace(/=.*/, "=;expires=" + new Date().toUTCString() + ";path=/");
    });
  };

  render() {
    return (
      <div className="header_container px-3">
        <nav class="navbar navbar-expand-lg navbar-light ">
          <span class="navbar-brand">PENTION MANAGEMENT SYSTEM</span>
          <button
            class="navbar-toggler"
            type="button"
            data-toggle="collapse"
            data-target="#navbarNavAltMarkup"
            aria-controls="navbarNavAltMarkup"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span class="navbar-toggler-icon"></span>
          </button>
          <div
            class="collapse navbar-collapse header_right"
            id="navbarNavAltMarkup"
          >
            <div class="navbar-nav">
              {this.state.token === null  ? (
                <React.Fragment>
                  <Button
                    className="login_btn me-3"
                    onClick={this.handelSignUp}
                  >
                    SignUp
                  </Button>
                  <Button className="login_btn" onClick={this.handelLogin}>
                    Login
                  </Button>
                </React.Fragment>
              ) : (
                <React.Fragment>
                  {/* <Button className='home'>
                                        home
                                </Button> */}
                  <Button className="login_btn" onClick={this.handelLogout}>
                    Logout
                  </Button>
                </React.Fragment>
              )}
            </div>
          </div>
        </nav>
      </div>
    );
  }
}
export default Header;
