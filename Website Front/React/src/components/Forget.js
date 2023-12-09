import { useState } from 'react';
import React from 'react'
import { Modal, Button } from 'react-bootstrap'
import Otp from './OTP';


function Forgot() {
    const [validx1, setValid1] = useState({ emailval: "", passval: "" })
    const [loginx1, setLoginx] = useState({ email: "", pass: "" })

    const [OTP, setOTP] = useState("");

    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);



    var OnTextChanged = (args) => {
        var copyoflogin = { ...loginx1 };
        copyoflogin[args.target.name] = args.target.value;
        setLoginx(copyoflogin);
    }



    return (
        <div className='container d-flex justify-content-center'>
            <div className="shadow p-3 mb-5 bg-white rounded col-md-7 ">
                <div className='row' style={{ padding: "20px" }}>
                    <div style={{ textAlign: "left" }}> <label ><b>Email Address</b></label></div>
                    <input type="text" className="emailselect" name="email" placeholder="Enter New Password" onChange={OnTextChanged} value={loginx1.email} />
                    <div style={{ textAlign: "left", color: "red", marginBottom: "30px" }}>{validx1.emailval}</div>

                    <div style={{ textAlign: "left" }}> <label ><b>New Password</b></label></div>
                    <input type="text" className="emailselect" name="email" placeholder="Enter New Password" onChange={OnTextChanged} value={loginx1.email} />
                    <div style={{ textAlign: "left", color: "red", marginBottom: "30px" }}>{validx1.emailval}</div>

                    <div style={{ textAlign: "left" }}><label><b>Confirm Password</b></label></div>
                    <input type="password" placeholder="Enter Confirm Password" name="pass" value={loginx1.pass} onChange={OnTextChanged} />
                    <div style={{ textAlign: "left", color: "red", marginBottom: "30px" }}>{validx1.passval}</div>

                    <input type="button" value="SUBMIT" className="submitx" />

                    <Button variant="primary" onClick={handleShow}>
                        click modal
                    </Button>
                    <Modal show={show} onHide={handleClose}>
                        <Modal.Header closeButton>
                            <Modal.Title>OTP Verification</Modal.Title>
                        </Modal.Header>
                        <Modal.Body>
                            <div>
                                <Otp></Otp>
                            </div>


                        </Modal.Body>
                        <Modal.Footer>
                            <Button variant="secondary" onClick={handleClose}>
                                Close
                            </Button>
                            <Button variant="primary" onClick={handleClose}>
                                Save Changes
                            </Button>
                        </Modal.Footer>
                    </Modal>

                </div>
            </div>
        </div>



    );
}
export default Forgot;
