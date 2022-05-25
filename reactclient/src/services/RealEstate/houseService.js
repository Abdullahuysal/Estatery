import axios from "axios";

const url="https://localhost:44321/api/House";
export default class HouseService{

    GetAll(){
        return axios.get(url+"/getallhouse");
    }
    GetById(payload){
        return axios.get(`https://localhost:44321/api/House/gethousebyid?id=${payload}`);
    }
    AddHouse(payload){
        return axios.post(url+"/addhouse",payload);
    }
    DeleteHouse(payload){
        return axios.post(url+"/deletehouse",payload);
    }
    UpdateHouse(payload){
        return axios.post(url+"/updatehouse",payload);
    }
}