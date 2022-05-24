import React from "react";
import { Container, Nav, Navbar, NavDropdown } from "react-bootstrap";
export default function Navi() {
  return (
    <div>
      <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
        <Container>
          <Navbar.Brand href="#home">Real-Estatery</Navbar.Brand>
          <Navbar.Toggle aria-controls="responsive-navbar-nav" />
          <Navbar.Collapse id="responsive-navbar-nav">
            <Nav className="me-auto">
              <Nav.Link href="#features">Ev İlanları</Nav.Link>
              <Nav.Link href="#pricing">Arazi İlanları</Nav.Link>
              <Nav.Link href="#fd">İş Yeri İlanları</Nav.Link>
            </Nav>
            <Nav>
            <NavDropdown title="User Name" id="collasible-nav-dropdown">
                <NavDropdown.Item href="#action/3.2">
                  Kişisel Bilgiler
                </NavDropdown.Item>
                <NavDropdown.Item href="#action/3.3">
                  İlan Ekle
                </NavDropdown.Item>
                <NavDropdown.Item href="#action/3.4">
                  Favori İlanlarım
                </NavDropdown.Item>
                <NavDropdown.Divider />
                <NavDropdown.Item href="#action/3.5">
                  Çıkış Yap
                </NavDropdown.Item>
              </NavDropdown>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </div>
  );
}
