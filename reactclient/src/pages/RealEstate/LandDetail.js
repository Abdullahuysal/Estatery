import React, { useEffect, useState } from 'react'
import { Form } from 'react-bootstrap';
import Navi from '../../layouts/Navi'
import LandService from "../../services/RealEstate/landService";
export default function LandDetail() {
  const [landDetails, setlandDetails] = useState([]);
  const [landimages, setlandimages] = useState([]);
  useEffect(()=>{
    let landService=new LandService();
    landService.GetById(localStorage.getItem("landid"))
    .then((result)=>setlandDetails(result.data));
    landService.GetById(localStorage.getItem("landid"))
    .then((result)=>setlandimages(result.data.landImageUrls));
  },[]);
  return (
    <div>
      <Navi/> 
      <div className="container rounded bg-white mt-5 mb-5">
      <div  className="row">
      <div className="col-md-2 border-right">
          </div>
      {landimages.map((land)=>
       <div key={land.id} className="row">{console.log(landDetails)}
           <div  className="col-md-7 border-right">
       <img style={{maxWidth:"100%",width:"600px",height:"500px",paddingTop:"20px"}} alt="profile" src={landDetails.landImageUrls[0].name}></img>
       </div>
       <div style={{maxWidth:"30%",paddingTop:"30px"}} className="col-md-5 border-right" >
         <div>
         <Form.Group>
                <Form.Label>İlan Sahibi</Form.Label>
                <Form.Control
                  type="text"
                  value={landDetails.advertiser}
                />
              </Form.Group>
              <Form.Group>
                <Form.Label>Toplam Metre Kare(m²)</Form.Label>
                <Form.Control
                  value={landDetails.squareMeter}
                  type="number"
                />
              </Form.Group>     
              <Form.Group>
                <Form.Label>Lokasyonu şehir </Form.Label>
                <Form.Control
                  type="text"
                  value={landDetails.location.cityName }
                />
              </Form.Group>
              <Form.Group>
                <Form.Label>Lokasyon İlçe adı</Form.Label>
                <Form.Control
                  type="text"
                  value={landDetails.location.districtName}
                />
              </Form.Group>
      </div>
      </div>
      </div>
      )}
      </div>
      </div>
    </div>
  )
}
