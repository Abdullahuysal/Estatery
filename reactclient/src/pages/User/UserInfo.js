import React, { useEffect, useState } from 'react';
import { Form } from 'react-bootstrap';
import profile from "../../images/profile.png";
import Navi from "../../layouts/Navi";
import UserService from "../../services/User/userService";
import alertify from "alertifyjs";
export default function UserInfo() {
  const [userInfo, setUserInfo] = useState([]);
  const [userfirstName, setuserfirstName] = useState([]);
  const [userSecondName, setuserSecondName] = useState([]);
  const [userEmail, setuserEmail] = useState([]);
  const [userpassword, setuserpassword] = useState([]);
  useEffect(() => {
    let userService = new UserService();
    userService.getuser(localStorage.getItem("userid"))
      .then((result) => setUserInfo(result.data));
  }, []);
  async function updateuser(e) {
    e.preventDefault();
    let userService = new UserService();
    var updateduser={
      "id": localStorage.getItem("userid"),
      "firstName": userfirstName,
      "secondName": userSecondName,
      "email": userEmail,
      "password": userpassword,
    };
    let result=await userService.update(updateduser);
    if(result.data!=null){
      alertify.success("Bilgiler Başarılı Bir Şekilde güncellenmiştir");
    }
    else{
      alertify.error("Güncelleme işlemi başarısız oldu");
    }

  }
  return (
    <div>
      <Navi />
      <div className="container rounded bg-white mt-5 mb-5">
        <div className="row">
          <div className="col-md-2 border-right">
          </div>
          <div className="col-md-4 border-right">
            <img style={{ maxWidth: "100%", paddingTop: "30px" }} alt="profile" src={profile}></img>
          </div>
          <div style={{ maxWidth: "100%", paddingTop: "30px" }} className="col-md-4 border-right" >
            <div>
              <Form onSubmit={updateuser} >
                <Form.Label style={{ color: "#017D89", fontSize: "20px", fontWeight: "bold", marginTop: "20px" }} >Kullanıcı Adı</Form.Label>
                <Form.Control
                  onChange={(e) => setuserfirstName(e.target.value)}
                  type="text"
                  placeholder={userInfo.firstName}
                />
                <Form.Label style={{ color: "#017D89", fontSize: "20px", fontWeight: "bold", marginTop: "20px" }} >Kullanıcı Soy-Adı</Form.Label>
                <Form.Control
                  onChange={(e) => setuserSecondName(e.target.value)}
                  type="text"
                  placeholder={userInfo.secondName}
                />
                <Form.Label style={{ color: "#017D89", fontSize: "20px", fontWeight: "bold", marginTop: "20px" }} >Kullanıcı Email</Form.Label>
                <Form.Control
                  onChange={(e) => setuserEmail(e.target.value)}
                  type="email"
                  placeholder={userInfo.email}
                />
                <Form.Label style={{ color: "#017D89", fontSize: "20px", fontWeight: "bold", marginTop: "20px" }} >Kullanıcı Şifre</Form.Label>
                <Form.Control
                  onChange={(e) => setuserpassword(e.target.value)}
                  type="password"
                  defaultValue={userInfo.password}
                  placeholder="Password"
                />
                <button
                  style={{ marginTop: "10px" }}
                  className="btn btn-success"
                >
                  Güncelle
                </button>
              </Form>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}
