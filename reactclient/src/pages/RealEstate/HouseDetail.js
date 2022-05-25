import React, { useEffect, useState } from "react";
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
      {houseimages.map((house)=>
      <div key={house.id} className="row">{console.log(houseDetails)}
      <div  className="col-md-8 border-right">
      <img style={{maxWidth:"100%",width:"600px",height:"500px",paddingTop:"40px"}} alt="profile" src={houseDetails.houseImageUrls[0].name}></img>
      </div>
      <div style={{maxWidth:"100%",paddingTop:"40px"}} className="col-md-4 border-right">
      <div style={{fontSize:"30px",fontFamily:"sans-serif"}} >İlan Hakkında Bilgiler</div>
      <div style={{fontSize:"30px",fontFamily:"sans-serif"}} >İlan Sahibi : {houseDetails.advertiser}</div>
      <div style={{fontSize:"30px",fontFamily:"sans-serif"}} >Konumu :{houseDetails.location.cityName}/{houseDetails.location.districtName}</div>
      <div style={{fontSize:"30px",fontFamily:""}} >İlan Hakkında Bilgiler</div>
      <div style={{fontSize:"30px",fontFamily:"initial"}} >İlan Hakkında Bilgiler</div>
      </div>
      </div>
      )}
      </div>
    </div>
  );
}
