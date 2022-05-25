import React, { useEffect, useState } from 'react';
import { Button, Card, ListGroup, ListGroupItem } from 'react-bootstrap';
import {FaSearchLocation} from "react-icons/fa";
import { useNavigate } from 'react-router-dom';
import Navi from '../../layouts/Navi';
import LandService from "../../services/RealEstate/landService";
export default function LandList() {
  let navigate=useNavigate();
const[lands,setLands]=useState([]);
useEffect(()=>{
  let landService=new LandService();
  landService.GetAll().then((result)=>setLands(result.data))
},[]);
function navigatelandDetailsPage(landid){
  localStorage.setItem("landid",landid);
  navigate("/LandDetail");
}
  return (
    <div>
      <Navi/>
      <div className="container rounded bg-white mt-5 mb-5">
        <div className="row">
      {lands.map((land) =>(
        <div
        key={land.id}
        style={{width:"400px"}}
        >
          <Card   style={{ marginTop: "3rem",textAlign:"center"}} >
        <Card.Img variant="top" src={land.landImageUrls[0].name} />
        <Card.Body >
          İlan Bilgileri 
        </Card.Body>
        <ListGroup className="list-group-flush">
          <ListGroupItem><FaSearchLocation/> Lokasyon : {land.location.cityName}/{land.location.districtName}</ListGroupItem>
          <ListGroupItem> Toplam {land.squareMeter} m² </ListGroupItem>
        </ListGroup>
        <Card.Body>
          <Button
          onClick={()=>navigatelandDetailsPage(land.id)}
          className="btn-success"
          >İlanı İncele</Button>
        </Card.Body>
      </Card>  
        </div>
      ))}
      </div>
    </div>
    </div>
  )
}
