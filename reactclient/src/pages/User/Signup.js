import alertify from 'alertifyjs';
import React, { useState } from 'react';
import { Col, Container, Form, Row } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import UserService from "../../services/User/userService";
export default function Signup() {
  const [email, setEmail] = useState([]);
  const [name,setName]=useState([]);
  const [secondname,setSecondname]=useState([]);
  const [password, setPassword] = useState([]);
  async function register(e){
    e.preventDefault();
    let userService=new UserService();
    var userRegister={
      "firstName":name,
      "secondName": secondname,
      "email": email,
      "password": password,
    }
    let response=await userService.signup(userRegister);
    if(response.data!=null){
      alertify.success('Kullanıcı eklenmiştir Giriş Yap Sayfasına giderek giriş yapabilirsiniz');
    }
    else{
      alertify.error('Kayıt olma işlemi başarısız '); 
    }
  }
  return (
    <div>
      <Container>
        <h1 className="shadow-sm text-success mt-5 p-3 text-center rounded">
           Kayıt Ol
        </h1>
        <Row className="mt-5">
          <Col
            lg={7}
            md={6}
            sm={12}
            className="p-5 m-auto shadow-sm rounded-lg"
          >
            <Form onSubmit={register}>
              <Form.Group>
                <Form.Label>İsim</Form.Label>
                <Form.Control 
                 onChange={(e)=>setName(e.target.value)}
                type="text" />
              </Form.Group>
              <Form.Group>
                <Form.Label>Soyisim</Form.Label>
                <Form.Control
                 onChange={(e)=>setSecondname(e.target.value)}
                type="text" />
              </Form.Group>
              <Form.Group>
                <Form.Label>Email adres</Form.Label>
                <Form.Control 
                onChange={(e) => setEmail(e.target.value)}
                type="email" placeholder="example@gmail.com" />
              </Form.Group>
              <Form.Group>
                <Form.Label>Şifre</Form.Label>
                <Form.Control 
                 onChange={(e)=>setPassword(e.target.value)}
                type="password" placeholder="Şifre" />
              </Form.Group>

              <Form.Group>
              <button style={{marginTop:"10px"}} className="btn btn-success"  >Kayıt Ol</button>
                <Form.Group>
                  <Form.Label>Hesabınız var mı?</Form.Label>
                </Form.Group>
                <Form.Group>
                  <Link onClick to="/Login" className="btn btn-success">
                    Giriş Yap
                  </Link>
                </Form.Group>
              </Form.Group>
            </Form>
          </Col>
        </Row>
      </Container>
    </div>
  )
}
