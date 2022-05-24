import axios from "axios";

const url="https://localhost:44321/api/WorkPlace";
export default class WorkPlaceService{

    GetAll(){
        return axios.get(url+"/getallworkplace");
    }
    GetById(payload){
        return axios.get(url+"/getbyId",payload);
    }
    AddWorkPlace(payload){
        return axios.post(url+"/addworkplace",payload);
    }
    DeleteWorkPlace(payload){
        return axios.post(url+"deleteworkplace",payload);
    }
    UpdateWorkPlace(payload){
        return axios.post(url+"updateworkplace",payload);
    }
}