import React, { Component } from "react";
import "../style/Dashboard.scss";
import Button from "react-bootstrap/Button";
import service from "../Utility/service";
class Dashboard extends Component {
  constructor(props) {
    super(props);
    this.state = {
      adharNumber: "",
      type: 1,
      enter: true,
      pensionID: "",
      userID: "",
      userName: "",
      amount: "",
      planType: "",
      accountNumber: "",
      panNumber: "",
      adharNumber: "",
      isDeducted: false,
      isActive: false,
      show: false,
      bankCharge: 500,
      newamount: "",
    };
  }

  handleClose() {
    this.setState({
      show: false,
    });
  }

  handelAdharNumber = (e) => {
    this.setState(
      {
        adharNumber: e.target.value,
      },
      console.log("adhar", this.state.adharNumber)
    );
  };
  handelFamily = () => {
    console.log("adhar", this.state.adharNumber);
    this.setState({
      type: 2,
    });
  };
  handelSelf = () => {
    this.setState({
      type: 1,
    });
  };

  EnterPensionDetail = async () => {
    this.setState({
      enter: false,
    });
    if (this.state.adharNumber.length == 12) {
      service
        .EnterPensionDetail(this.state.adharNumber)
        .then((response) => response.json())
        .then((data) => {
          console.log("Data : ", data);
          //   if (data) {
          // "name": "Jesus",
          // "dateOfBirth": "23/04/1984",
          // "pan": "VINFU7854E",
          // "pensionType": 2,
          // "pensionAmount": 109500
          this.setState({
            enter: false,
            pensionID: data.pensionID,
            userID: data.userID,
            userName: data.name,
            amount: data.pensionAmount,
            planType: data.pensionType,
            accountNumber: data.accountNumber,
            panNumber: data.pan,
            //   adharNumber: data.adharNumber,
            isDeducted: data.isDeducted,
            isActive: data.isActive,
          });
          //   }
        });
      {
        console.log("wrong data");
      }
    } else {
      alert("pls enter required field");
    }
  };

  handelback = async () => {
    this.setState({
      show: false,
      //   newamount: this.state.amount - this.state.bankCharge,
    });
    // if (this.state.adharNumber) {
    //   service
    //     .ProcessPension(
    //       this.state.adharNumber,
    //       this.state.pensionAmount,
    //       this.state.bankCharge
    //     )
    //     .then((response) => response.json())
    //     .then((data) => {
    //       if (data.isSuccess) {
    //         this.setState({
    //           show: false,
    //         });
    //         alert("amount Detucted sucessfully");
    //         window.location.href = window.location.origin + "/Login";
    //       }
    //     });
    //   {
    //     console.log("wrong data");
    //   }
    // } else {
    //   alert("pls enter required field");
    // }
  };

  PensionAmountDeduction = () => {
    // this.setState({ show: true });

    if (this.state.adharNumber) {
      service
        .ProcessPension(
          this.state.adharNumber,
          this.state.amount,
          this.state.bankCharge
        )
        .then((response) => response.json())
        .then((data) => {
          if (data.isSuccess) {
            this.setState({
              show: true,
            });
            alert(data.message);
            //window.location.href = window.location.origin + "/Login";
          }
        });
      {
        console.log("wrong data");
      }
    } else {
      alert("pls enter required field");
    }

    // this.setState({
    //   show: true,
    //   newamount: this.state.amount - this.state.bankCharge,
    // });
  };

  render() {
    console.log("State : ", this.state);
    return (
      <React.Fragment>
        {
          this.state.enter ? (
            <div className="deshboard_container">
              <div className="welcome_pms">Enter Pensioner Details Here</div>
              <div className="login_input">
                <div className="username_wrap">
                  <label className="label_user pb-2">ADHAR NUMBER</label>
                  <input
                    type="text"
                    className="input_user py-1"
                    onChange={this.handelAdharNumber}
                    value={this.state.adharNumber}
                  />
                </div>
                <span className="field pt-2">Match the Adhar Formate</span>
                <div className="username_wrap">
                  <label className="label_user">PENTION TYPE</label>
                  <div className="pention_wrap row pt-2">
                    <div className="col-6  d-flex align-items-center">
                      <input
                        type="radio"
                        id="html"
                        name="fav_language"
                        value="HTML"
                      />
                      <label
                        for="html"
                        className="label_user ps-3"
                        onClick={this.handelSelf}
                      >
                        Self
                      </label>
                    </div>
                    <div className="col-6 d-flex align-items-center">
                      <input
                        type="radio"
                        id="css"
                        name="fav_language"
                        value="CSS"
                      />
                      <label
                        for="css"
                        className="label_user ps-3"
                        onClick={this.handelFamily}
                      >
                        Family
                      </label>
                    </div>
                  </div>
                </div>
                <span className="field">Field is require</span>
              </div>
              <div className="submit_btn_wrap">
                <input
                  type="submit"
                  value="Submit"
                  className="submit_btn"
                  onClick={this.EnterPensionDetail}
                />
              </div>
            </div>
          ) : (
            <div className="deshboard_container">
              <div className="welcome_pms">&#x20B9; {this.state.amount}</div>
              <div className="pention_detail_wrap row ">
                <div className="pention_detail_right col-6">
                  <h3 className="">Pentioner's Details</h3>
                  <p className="pt-2 pb-2">{this.state.userName}</p>
                  <div className="pention_detail_con row pt-3">
                    <div className="pention_detail_con_left col-6">
                      Plan Type
                    </div>
                    <div className="pention_detail_left col-6">
                      {this.state.planType == 1 ? "Self" : "Family"}
                    </div>
                  </div>
                  {/* <div className="pention_detail_con row pt-3">
                                        <div className="pention_detail_con_left col-6">
                                            Acount Number
                                        </div>
                                        <div className="pention_detail_left col-6 ">
                                            {this.state.accountNumber}
                                        </div>
                                    </div> */}
                  <div className="pention_detail_con row pt-3">
                    <div className="pention_detail_con_left col-6">
                      Adhar Number
                    </div>
                    <div className="pention_detail_left col-6">
                      {this.state.adharNumber}
                    </div>
                  </div>
                  <div className="pention_detail_con row pt-3">
                    <div className="pention_detail_con_left col-6">
                      Pan Number
                    </div>
                    <div className="pention_detail_left col-6">
                      {this.state.panNumber}
                    </div>
                  </div>
                </div>
                <div className="pention_detail_left_disburse col-6">
                  <p className="one_click m-0">Total Pention Amount</p>
                  <p className="amount_remain">{this.state.amount} &#x20B9; </p>
                  <p className="one_click"> You can disburse in one click</p>
                </div>
              </div>

              <div className="submit_btn_wrap_dis">
                <input
                  type="submit"
                  value="Disburse"
                  className="submit_btn"
                  onClick={this.PensionAmountDeduction}
                />
                {this.state.show ? (
                  <div className="disburse_wrap">
                    <div className="success">success...</div>
                    <div className="pention">
                      Service charge of {this.state.bankCharge} deducted from
                      Pention account ...
                    </div>
                    <div className="pention">
                      Amount of {this.state.newamount} will be transfered to
                      Pentioner account soon ...
                    </div>
                    <input
                      type="submit"
                      value="back"
                      className="back_btn"
                      onClick={this.handelback}
                    />
                  </div>
                ) : null}
              </div>
            </div>
          )
          // onClick={this.PensionAmountDeduction}
        }
      </React.Fragment>
    );
  }
}
export default Dashboard;
