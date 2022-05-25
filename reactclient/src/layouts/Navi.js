import React from "react";
import { ImExit } from "react-icons/im";
import { Container, Nav, Navbar, NavDropdown } from "react-bootstrap";
export default function Navi() {
  function exit(){
    localStorage.clear();
  }
  return (
    <div>
      <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
        <Container>
          <Navbar.Brand href="#home">Real-Estatery</Navbar.Brand>
          <Navbar.Toggle aria-controls="responsive-navbar-nav" />
          <Navbar.Collapse id="responsive-navbar-nav">
            <Nav className="me-auto">
              <Nav.Link href="/HouseList">Ev İlanları</Nav.Link>
              <Nav.Link href="/LandList">Arazi İlanları</Nav.Link>
              <Nav.Link href="/WorkPlaceList">İş Yeri İlanları</Nav.Link>
            </Nav>
            <Nav>
            <NavDropdown title={localStorage.getItem("username")+" "+localStorage.getItem("usersecondname")} id="collasible-nav-dropdown">
                <NavDropdown.Item href="/UserInfo">
                  Kişisel Bilgiler
                </NavDropdown.Item>
                <NavDropdown.Item href="/Addhouse">
                  Ev İlanı Ekle
                </NavDropdown.Item>
                <NavDropdown.Item href="/Addland">
                  Arazi İlanı Ekle
                </NavDropdown.Item>
                <NavDropdown.Item href="/Addworkplace">
                  İş yeri İlanı Ekle
                </NavDropdown.Item>
                <NavDropdown.Divider />
                <NavDropdown.Item onClick={exit} href="Login" >
                  Çıkış Yap <ImExit/>
                </NavDropdown.Item>
              </NavDropdown>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </div>
  );
}
