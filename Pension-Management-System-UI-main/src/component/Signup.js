import Rract, { Component } from "react";
import "../style/login.scss";
import Button from "react-bootstrap/Button";
import service from "../Utility/service";

class Signup extends Component {
  constructor(props) {
    super(props);
    this.state = {
      userName: "",
      password: "",
      Confirmpassword: "",
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
  handelConfirmPassword = (e) => {
    this.setState({
      Confirmpassword: e.target.value,
    });
  };

  handelSignup = async () => {
    console.log(
      "state : ",
      this.state.userName,
      " Password : ",
      this.state.password,
      this.state.Confirmpassword
    );
    if (
      this.state.userName !== "" &&
      this.state.password !== "" &&
      this.state.Confirmpassword !== ""
    ) {
      if (this.state.password === this.state.Confirmpassword) {
        service
          .SignUp(this.state.userName, this.state.password)
          .then((response) => response.json())
          .then((data) => {
            if (data) {
              alert("Sign Up Successful");
              window.location.href = window.location.origin + '/Login';
              //localStorage.setItem("data", JSON.stringify(data));
            }
          });
        {
          console.log("wrong data");
        }
      } else {
        alert("password not matched");
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
        <div className="loginForm_container">
          <div className="login_pannel">SignUp PANEL</div>
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
            <div className="username_wrap">
              <label className="label_user">Confirm Password </label>
              <input
                type="password"
                className="input_user"
                onChange={this.handelConfirmPassword}
                value={this.state.Confirmpassword}
              />
            </div>
            <span className="field">Field is require</span>
          </div>
          <div className="submit_btn_wrap">
            <input
              type="submit"
              value="Submit"
              className="submit_btn"
              onClick={this.handelSignup}
            />
          </div>
        </div>
      </div>
    );
  }
}
export default Signup;
