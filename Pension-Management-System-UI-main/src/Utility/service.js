import { config } from "./config";
const service = {
  SignIn,
  PensionAmountDeduction,
  EnterPensionDetail,
  SignUp,
  ProcessPension
};

var token = "";
try {
  // TOKEN = JSON.parse(JSON.parse(localStorage.getItem("persist:root")).user).currentUser.accessToken ;
  // var loginDetail = JSON.parse(localStorage.getItem("token"));
  token = localStorage.getItem("token");
} catch (err) {
  console.log(err);
}

export default service;
async function SignUp(userName, password) {
  const requestOptions = {
    method: "POST",
    headers: {
      "content-type": "application/json",
      "cache-control": "no-cache",
      //"x-access-key": sessionId,
    },
    body: JSON.stringify({
      username: userName,
      password: password,
    }),
  };

  return await fetch(
    config.apiUrl + "api/Authorization/Registration",
    requestOptions
  ).then((res) => {
    return res;
  });
}
async function SignIn(userName, password) {
  const requestOptions = {
    method: "POST",
    headers: {
      "content-type": "application/json",
      "cache-control": "no-cache",
      //"x-access-key": sessionId,
    },
    body: JSON.stringify({
      username: userName,
      password: password,
    }),
  };

  return await fetch(
    config.apiUrl + "api/Authorization/Login",
    requestOptions
  ).then((res) => {
    console.log("SignIn Fetch : ", res);
    return res;
  });
}

async function EnterPensionDetail(adharNumber, type) {
  console.log("Token : ", localStorage.getItem("token"));
  const requestOptions = {
    method: "GET",
    headers: {
      "content-type": "application/json",
      "cache-control": "no-cache",
      Authorization: `Bearer ${localStorage.getItem("token")}`,
      //"x-access-key": sessionId,
    },
    // body: JSON.stringify({
    //   adharNumber: adharNumber,
    //   type: type,
    // }),
  };

  return await fetch(
    config.apiUrl1 +
      "api/ProcessPension/PensionDetail?aadhaarNumber=" +
      adharNumber,
    requestOptions
  ).then((res) => {
    return res;
  });
}

async function PensionAmountDeduction(adharno) {
  const requestOptions = {
    method: "GET",
    headers: {
      "content-type": "application/json",
      "cache-control": "no-cache",
      Authorization: `Bearer ${localStorage.getItem("token")}`,
      //"x-access-key": sessionId,
    },
    // body: JSON.stringify({
    //   pensionID:pensionID
    // }),?aadhaarNumber=278738717139
  };

  return await fetch(
    config.apiUrl +
      "api/Pension/PensionAmountDeduction" +
      "?aadhaarNumber=" +
      { adharno },
    requestOptions
  ).then((res) => {
    return res;
  });
}

async function ProcessPension(adharNumber, pentionamount, bankCharge) {
  const requestOptions = {
    method: "POST",
    headers: {
      "content-type": "application/json",
      "cache-control": "no-cache",
      Authorization: `Bearer ${localStorage.getItem("token")}`,
      //"x-access-key": sessionId,
    },
    body: JSON.stringify({
      aadhaarNumber: adharNumber,
      pensionAmount: pentionamount,
      bankCharge: bankCharge,
    }),
  };

  return await fetch(
    config.apiUrl1 + "api/ProcessPension/ProcessPension",
    requestOptions
  ).then((res) => {
    return res;
  });
}
