import axios from "axios";

const url="https://localhost:44321/api/Land";
export default class LandService{
    GetAll(){
        return axios.get(url+"/getallland");
    }
    GetById(payload){
        return axios.get(url+"/getbyId",payload);
    }
    AddLand(payload){
        return axios.post(url+"/addland",payload);
    }
    DeleteLand(payload){
        return axios.post(url+"/deleteland",payload);
    }
    UpdateLand(payload){
        return axios.post(url+"/updateland",payload);
    }
}