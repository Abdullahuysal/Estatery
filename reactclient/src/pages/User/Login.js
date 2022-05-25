import React, { useState } from 'react'
import { Alert, Col, Container, Form, Row } from 'react-bootstrap';
import { Link, useNavigate } from 'react-router-dom';
import UserService from "../../services/User/userService";
export default function Login () {
    const [email, setEmail] = useState([]);
    const [password, setPassword] = useState([]);
    const [error, setError] = useState(false);
    let navigate=useNavigate();
    async function login(e){
        e.preventDefault();
        let userService = new UserService();
        var userdata={
                "email": email,
                "password": password}
        let value=await userService.login(userdata);
        if(value.data.data!=null){
            localStorage.setItem("username",value.data.data.firstName);
            localStorage.setItem("usersecondname",value.data.data.secondName);
            localStorage.setItem("userid",value.data.data.id);
            navigate("/HouseList");    
        }
        else{
            setError(true);
        }
    }
    return (
    <div>
    <Container>
        <h1 className="shadow-sm text-success mt-5 p-3 text-center rounded">
         Giriş Yap
        </h1>
        <Row className="mt-5">
          <Col
            lg={7}
            md={6}
            sm={12}
            className="p-5 m-auto shadow-sm rounded-lg">
       {error? <Alert variant="danger" > <Alert.Heading>E-mail veya Şifre Hatalıdır</Alert.Heading></Alert>:<p></p>}
          
            <Form onSubmit={login} 
    >
              <Form.Group>
                <Form.Label>Email adres</Form.Label>
                <Form.Control
                  onChange={(e) => setEmail(e.target.value)}
                  type="email"
                  placeholder="example@gmail.com"
                />
              </Form.Group>
              <Form.Group>
                <Form.Label>Şifre</Form.Label>
                <Form.Control
                  onChange={(e) => setPassword(e.target.value)}
                  type="password"
                  placeholder="Şifre"
                />
              </Form.Group>
              <button style={{marginTop:"10px"}} className="btn btn-success"  >Giriş Yap</button>

              <Link onClick to="/Signup" className="btn btn-success" style={{marginLeft:"10px" ,marginTop:"10px"}}>
                   Kayıt Ol
                  </Link>
            </Form>
          </Col>
        </Row>
      </Container>
    </div>
  )
}
