import Rract, { Component } from "react";
import "../style/login.scss";
import Button from "react-bootstrap/Button";
import service from "../Utility/service";

class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      userName: "",
      password: "",
      enter: true,
    };
  }

  handelUserName = (e) => {
    this.setState({
      userName: e.target.value,
    });
  };
  handelPassword = (e) => {
    this.setState({
      password: e.target.value,
    });
  };
  handelSighin = async () => {
    if (this.state.userName !== "" && this.state.password !== "") {
      service
        .SignIn(this.state.userName, this.state.password)
        .then((response) => response.json())
        .then((data) => {
          console.log("Data : ", data);
          if (data.isSuccess) {
            localStorage.setItem("token", data.token);
            console.log(("Token : ", data.token));
            window.location.href = window.location.origin + "/Dashboard";
          }
        })
        .catch((error) => {
          console.log("Error : ", error);
        });
      {
        console.log("wrong data");
      }
    } else {
      alert("pls enter required field");
    }
  };

  enter = () => {
    this.setState({
      enter: false,
    });
  };

  render() {
    return (
      <div className="login_container">
        {this.state.enter ? (
          <div className="welcome_wrap">
            <div className="welcome_pms">Welcome to PMS Portal</div>
            <div className="enter" onClick={this.enter}>
              Enter
            </div>
          </div>
        ) : (
          <div className="loginForm_container">
            <div className="login_pannel">LOGIN PANEL</div>
            <div className="login_input">
              <div className="username_wrap">
                <label className="label_user">User Name </label>
                <input
                  type="text"
                  className="input_user"
                  onChange={this.handelUserName}
                  value={this.state.userName}
                />
              </div>

              <span className="field">Field is require</span>
              <div className="username_wrap">
                <label className="label_user">Password </label>
                <input
                  type="password"
                  className="input_user"
                  onChange={this.handelPassword}
                  value={this.state.password}
                />
              </div>
              <span className="field">Field is require</span>
            </div>
            <div className="submit_btn_wrap">
              <input
                type="submit"
                value="Submit"
                className="submit_btn"
                onClick={this.handelSighin}
              />
            </div>
          </div>
        )}
      </div>
    );
  }
}
export default Login;
