import React, { useEffect, useState } from "react";
import { Form } from "react-bootstrap";
import Navi from "../../layouts/Navi";
import HouseService from "../../services/RealEstate/houseService";
export default function HouseDetail() {
  const [houseDetails, setHouseDetails] = useState([]);
  const [houseimages, sethouseimages] = useState([]);
  useEffect(() => {
    let houseService = new HouseService();
    houseService
      .GetById(localStorage.getItem("houseid"))
      .then((result) => setHouseDetails(result.data));
      houseService
      .GetById(localStorage.getItem("houseid"))
      .then((result) => sethouseimages(result.data.houseImageUrls));
  }, []);
  return (
    <div>
      <Navi />
      <div className="container rounded bg-white mt-5 mb-5">
      <div  className="row">
      <div className="col-md-2 border-right">
          </div>
      {houseimages.map((house)=>
       <div key={house.id} className="row">{console.log(houseDetails)}
           <div  className="col-md-7 border-right">
       <img style={{maxWidth:"100%",width:"600px",height:"500px",paddingTop:"80px"}} alt="profile" src={houseDetails.houseImageUrls[0].name}></img>
       </div>
       <div style={{maxWidth:"30%",paddingTop:"30px"}} className="col-md-5 border-right" >
         <div>
         <Form.Group>
                <Form.Label>İlan Sahibi</Form.Label>
                <Form.Control
                  type="text"
                  value={houseDetails.advertiser}
                />
              </Form.Group>
              <Form.Group>
                <Form.Label>Toplam Oda Sayısı</Form.Label>
                <Form.Control
                  type="number"
                  value={houseDetails.numberOfRooms}
                />
              </Form.Group>
              <Form.Group>
                <Form.Label>Toplam Banyo Sayısı</Form.Label>
                <Form.Control
                  type="number"
                  value={houseDetails.numberOfBath}
                />
              </Form.Group>
              <Form.Group>
                <Form.Label>Toplam Metre Kare(m²)</Form.Label>
                <Form.Control
                  value={houseDetails.squareMeter}
                  type="number"
                />
              </Form.Group>
              <Form.Group>
                <Form.Label>Bina Yapım Yılı</Form.Label>
                <Form.Control
                  value={houseDetails.constructionYear}
                  type="number"
                />
                </Form.Group>      
              <Form.Group>
                <Form.Label>Lokasyonu şehir </Form.Label>
                <Form.Control
                  type="text"
                  value={houseDetails.location.cityName }
                />
              </Form.Group>
              <Form.Group>
                <Form.Label>Lokasyon İlçe adı</Form.Label>
                <Form.Control
                  type="text"
                  value={houseDetails.location.districtName}
                />
              </Form.Group>
      </div>
      </div>
      </div>
      )}
      </div>
      </div>
    </div>
  );
}

