import React, { useEffect, useState } from 'react'
import { Button, Card, ListGroup, ListGroupItem } from 'react-bootstrap';
import Navi from "../../layouts/Navi";
import { FaSearchLocation} from "react-icons/fa";
import { useNavigate } from 'react-router-dom';
import WorkPlaceService from "../../services/RealEstate/workPlaceService";
export default function WorkPlaceList() {
  let navigate=useNavigate();
  const[workplaces,setWorkPlaces]=useState([]);
  useEffect(()=>{
    let workPlaceService=new WorkPlaceService();
    workPlaceService.GetAll().then((result)=>setWorkPlaces(result.data))
  },[]);
  console.log(workplaces);
  function navigateWorkPlaceDetailsPage(workplaceid){
    localStorage.setItem("workplaceid",workplaceid);
    navigate("/WorkPlaceDetail");
  }

  return (
    <div>
      <Navi/>
      <div className="container rounded bg-white mt-5 mb-5">
        <div className="row">
      {workplaces.map((workplace) =>(
        <div
        key={workplace.id}
        style={{width:"400px"}}
        >
          <Card  style={{ marginTop: "3rem",textAlign:"center"}} >
        <Card.Img variant="top" src={workplace.workPlaceImageUrls[0].name} />
        <Card.Body >
          {workplace.salesType.name} {workplace.salesCategory.name}
        </Card.Body>
        <ListGroup className="list-group-flush">
          <ListGroupItem>İlan Sahibi {workplace.advertiser}</ListGroupItem>
          <ListGroupItem><FaSearchLocation/> Lokasyon : {workplace.location.cityName}/{workplace.location.districtName}</ListGroupItem>
        </ListGroup>
        <Card.Body>
          <Button
          onClick={()=>navigateWorkPlaceDetailsPage(workplace.id)}
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
