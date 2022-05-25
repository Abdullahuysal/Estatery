import alertify from "alertifyjs";
import React, { useState } from "react";
import { Col, Container,Form, Row } from "react-bootstrap";
import Navi from "../../layouts/Navi";
import HouseService from "../../services/RealEstate/houseService";
export default function Addhouse() {
  const [squareMeter, setsquareMeter] = useState([]);
  const [numberofBath, setnumberofBath] = useState([]);
  const [numberOfRooms, setnumberOfRoom] = useState([]);
  const [constructionYear, setconstructionYear] = useState([]);
  const [imageurl, setimageurl] = useState([]);
  const [cityname, setcityname] = useState([]);
  const [districtname, setdistrictname] = useState([]);
  const [salesCategory, setsalesCategory] = useState([]);
  const [salesType, setsalesType] = useState([]);
  async function addhouse(e) {
    e.preventDefault();
    let houseService = new HouseService();
    let advertiser=localStorage.getItem("username")+" "+ localStorage.getItem("usersecondname");
    var additionhouse = {
      "salesType": {
        "name": salesType,
      },
      "salesCategory": {
        name: salesCategory,
      },
      "location": {
        "cityName": cityname,
        "districtName": districtname,
      },
      "imageUrls": {
        "name": [imageurl],
      },
      "advertiser":advertiser,
      "constructionYear": constructionYear,
      "numberOfRooms": numberOfRooms,
      "numberOfBath": numberofBath,
      "squareMeter": squareMeter,
    };
    
    console.log(additionhouse);
    let result=await houseService.AddHouse(additionhouse);
    if(result.data!=null){
      alertify.success("Ev ilanı Başarılı Bir Şekilde Eklenmiştir");
      console.log(result.data);
    }
    else{
      alertify.error("Ev İlanı Ekleme İşlemi Başarısız Oldu");
      console.log(result.data);
    }
  }
  return (
    <div>
      <Navi />
      <Container>
        <h1 className="shadow-sm text-success mt-5 p-3 text-center rounded">
          Ev İlanı Ekle
        </h1>
        <Row className="mt-5">
          <Col
            lg={7}
            md={6}
            sm={12}
            className="p-5 m-auto shadow-sm rounded-lg"
          >
            <Form onSubmit={addhouse}>
              <Form.Group>
                <Form.Label>Toplam Oda Sayısı</Form.Label>
                <Form.Control
                  onChange={(e) => setnumberOfRoom(e.target.value)}
                  type="number"
                />
              </Form.Group>
              <Form.Group>
                <Form.Label>Toplam Banyo Sayısı</Form.Label>
                <Form.Control
                  onChange={(e) => setnumberofBath(e.target.value)}
                  type="number"
                />
              </Form.Group>
              <Form.Group>
                <Form.Label>Toplam Metre Kare(m²)</Form.Label>
                <Form.Control
                  onChange={(e) => setsquareMeter(e.target.value)}
                  type="number"
                />
              </Form.Group>
              <Form.Group>
                <Form.Label>Bina Yapım Yılı</Form.Label>
                <Form.Control
                  onChange={(e) => setconstructionYear(e.target.value)}
                  type="number"
                />
                </Form.Group>      
               <Form.Group>
                <Form.Label>Resim Url'i</Form.Label>
                <Form.Control
                  onChange={(e) => setimageurl(e.target.value)}
                  type="text"
                />
              </Form.Group>
              <Form.Group>
                <Form.Label>Lokasyom şehir adı</Form.Label>
                <Form.Control
                  onChange={(e) => setcityname(e.target.value)}
                  type="text"
                />
              </Form.Group>
              <Form.Group>
                <Form.Label>Lokasyon ilçe adı</Form.Label>
                <Form.Control
                  onChange={(e) => setdistrictname(e.target.value)}
                  type="text"
                />
              </Form.Group>
              <Form.Group>
                <Form.Label>Satış Tipi(satılık,kiralık,yıllık vs)</Form.Label>
                <Form.Control
                  onChange={(e) => setsalesType(e.target.value)}
                  type="text"
                />
              </Form.Group>
              <Form.Group>
                <Form.Label>Satış Kategorisi(apartman,daire,müstakil vs)</Form.Label>
                <Form.Control
                  onChange={(e) => setsalesCategory(e.target.value)}
                  type="text"
                />
              </Form.Group>
              <Form.Group>
                <button
                  style={{ marginTop: "10px" }}
                  className="btn btn-success"
                >
                  Ekle
                </button>
              </Form.Group>
            </Form>
          </Col>
        </Row>
      </Container>
    </div>
  );
}
