
import "../style/intxt.css"
import "../style/myDiv.css"
import "../style/myfont.css"
import "../style/font.css"
import "../style/tdMenu.css"
import "../fonts/natraj.ttf"
import { Link, Route, Switch } from 'react-router-dom';
import Header from "../HeaderV1"
import Home from "./Home"
import logo from '../images/natraj123.png';
import { useHistory } from "react-router-dom";
import { useState } from 'react';
import { Context } from "react-responsive"
import Landing from "../LandingV1";
import axios from "axios";

function Login() {
    var history = useHistory();

    const [loginx1, setLoginx] = useState({ email: "", pass: "" })
    const [validx1, setValid1] = useState({ emailval: "", passval: "" })
    const [selectuser, setUser] = useState("u");

    var handleDropdownChange = (e) => {
        setUser(e.target.value);
    }

    var OnTextChanged = (args) => {
        var copyoflogin = { ...loginx1 };
        copyoflogin[args.target.name] = args.target.value;
        setLoginx(copyoflogin);
    }

    const handleSubmit = () => {
        const userData = {
            name: loginx1.email,
            job: loginx1.pass
        };
        axios
            .post("http://localhost:9898/login", userData)
            .then(response => {
                console.log(response.data)
                debugger
                if (response.data.length == 1) {
                    window.localStorage.setItem("isUserLoggedIn", "true");
                    window.localStorage.setItem("first", response.data[0].f_name);
                    window.localStorage.setItem("last", response.data[0].l_name);
                    window.sessionStorage.setItem("emailID", response.data[0].email);
                    window.sessionStorage.setItem("pass", response.data[0].pass_w);
                    window.sessionStorage.setItem("address", response.data[0].usraddress);
                    window.sessionStorage.setItem("pincode", response.data[0].pincode);
                    window.sessionStorage.setItem("utype", response.data[0].user_type);
                    window.sessionStorage.setItem("city", response.data[0].city);
                    window.sessionStorage.setItem("statex", response.data[0].statex);
                    window.sessionStorage.setItem("country", response.data[0].country);

                }
                else {
                    console.log('Not OK');
                }
            })
            .catch(error => console.log(error));
    };

    var onSubmit = () => {
        var i = 0;
        if (loginx1.email == "") {
            setValid1(prevState => ({
                ...prevState,
                emailval: "Please enter Email"
            }));
            i = 0;
        }
        else {
            setValid1(prevState => ({
                ...prevState,
                emailval: ""
            }));
            i = i + 1;
        }

        if (loginx1.pass == "") {
            setValid1(prevState => ({
                ...prevState,
                passval: "Please enter Password"
            }));
            i = 0;
        }
        else {
            setValid1(prevState => ({
                ...prevState,
                passval: ""
            }));
            i = i + 1;
        }

        if (i == 2) {
            login();
        }
    }

    var login = () => {
        const userData = {
            email: loginx1.email,
            pass_wt: loginx1.pass
        };
        axios
            .post("http://localhost:9898/login", userData)
            .then(response => {
                console.log(response.data)
                debugger
                if (response.data.length == 1) {
                    window.localStorage.setItem("isUserLoggedIn", "true");
                    window.localStorage.setItem("first", response.data[0].f_name);
                    window.localStorage.setItem("last", response.data[0].l_name);
                    window.localStorage.setItem("emailID", response.data[0].email);
                    window.localStorage.setItem("pass", response.data[0].pass_w);
                    window.localStorage.setItem("address", response.data[0].usraddress);
                    window.localStorage.setItem("pincode", response.data[0].pincode);
                    window.localStorage.setItem("utype", response.data[0].user_type);
                    window.localStorage.setItem("city", response.data[0].city);
                    window.localStorage.setItem("statex", response.data[0].statex);
                    window.localStorage.setItem("country", response.data[0].country);
                    history.push("/home");
                    history.go("/home");
                }
                else {
                    console.log('Not OK');
                }
            })
            .catch(error => console.log(error));
        // window.sessionStorage.setItem("usermobi", data[0].mobileno);
        // window.sessionStorage.setItem("userpin", data[0].pin);
    }

    return (
        <div>
            <center>
                <div className="mydiv" >
                    <center>
                        <h1 className="headx" >Login</h1>
                    </center>


                    <center><img src={logo} width="300" height="300" /></center>

                    <center>
                        <h1 className="minhead">Timeless Treasure</h1>
                    </center>

                    <div style={{ textAlign: "left" }}> <label ><b>Email Address</b></label></div>
                    <input type="text" className="emailselect" name="email" placeholder="Enter Your Email Address" onChange={OnTextChanged} value={loginx1.email} />
                    <div style={{ textAlign: "left", color: "red", marginBottom: "30px" }}>{validx1.emailval}</div>

                    <div style={{ textAlign: "left" }}><label><b>Password</b></label></div>
                    <input type="password" placeholder="Enter Password" name="pass" value={loginx1.pass} onChange={OnTextChanged} />
                    <div style={{ textAlign: "left", color: "red", marginBottom: "30px" }}>{validx1.passval}</div>

                    <p style={{ marginTop: "-25px", textAlign: "right", color: "dimgrey" }} onClick={() => { history.push("/forget") }}>Forgot Password ? </p>
                    <div style={{ textAlign: "left" }}><label><b>User Type</b></label></div>
                     <select style={{ width: "100%" }} name='user' className="userselect" onChange={handleDropdownChange}>
                        <option value="u">Customer</option>
                        <option value="a">Artist</option>
                        <option value="c">Coin Seller</option>
                        <option value="p">Painter</option>
                    </select> 

                    <input type="button" value="SUBMIT" className="submitx" onClick={onSubmit} />

                    <div style={{ textAlign: "center", color: "dimgrey", textDecoration: "none" }}>Need an account? <div onClick={() => { history.push("/reg") }}>SIGN UP</div></div>
                </div>
            </center>
        </div>
    )
}
export default Login