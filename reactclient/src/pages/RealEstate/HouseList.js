import React, { useEffect, useState } from "react";
import { Button, Card, ListGroup, ListGroupItem } from "react-bootstrap";
import Navi from "../../layouts/Navi";
import HouseService from "../../services/RealEstate/houseService";
import { FaBath ,FaHome,FaSearchLocation} from "react-icons/fa";
import { MdConstruction } from "react-icons/md";
import { useNavigate } from "react-router-dom";
export default function HouseList() {
  let navigate=useNavigate();
  const[houses,setHouses]=useState([]);
  useEffect(()=>{
    let houseService=new HouseService();
    houseService.GetAll().then((result)=>setHouses(result.data))
    
  },[]);
  function navigatehouseDetailsPage(houseid){
    localStorage.setItem("houseid",houseid);
    navigate("/HouseDetail");
  }
  return (
    <div>
      <Navi />
      <div className="container rounded bg-white mt-5 mb-5">
        <div className="row">
      {houses.map((house) =>(
        <div
        key={house.id}
        style={{width:"400px"}}
        >
          <Card   style={{ marginTop: "3rem",textAlign:"center"}} >
        <Card.Img variant="top" src={house.houseImageUrls[0].name} />
        <Card.Body >
          İlan Bilgileri 
        </Card.Body>
        <ListGroup className="list-group-flush">
          <ListGroupItem><MdConstruction/> Bina Yapım Yılı : {house.constructionYear}</ListGroupItem>
          <ListGroupItem><FaSearchLocation/> Lokasyon : {house.location.cityName}/{house.location.districtName}</ListGroupItem>
          <ListGroupItem><FaHome/> Oda Sayısı: {house.numberOfRooms} </ListGroupItem>
          <ListGroupItem><FaBath/> Banyo Sayısı: {house.numberOfRooms} </ListGroupItem>
          <ListGroupItem> Toplam {house.squareMeter} m² </ListGroupItem>
        </ListGroup>
        <Card.Body>
          <Button
          onClick={()=>navigatehouseDetailsPage(house.id)}
          className="btn-success"
          >İlanı İncele</Button>
        </Card.Body>
      </Card>  
        </div>
      ))}
      </div>
    </div>
    </div>
  );
}
