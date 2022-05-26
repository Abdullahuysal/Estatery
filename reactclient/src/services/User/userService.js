import axios from "axios";
const url="https://localhost:44321/api/User";
export default class UserService{
    
    login(payload){
        return axios.post(url+"/login",payload);
    }
    signup(payload){
        return axios.post(url+"/signup",payload);
    }
    getuser(payload){
        return axios.get(`https://localhost:44321/api/User/getuserInfo?id=${payload}`)
    }
    update(payload){
        return axios.post(url+"/updateuser",payload);
    }
    delete(payload){
        return axios.delete(`https://localhost:44321/api/User/deleteuser?Userid=${payload}`);
    }
}