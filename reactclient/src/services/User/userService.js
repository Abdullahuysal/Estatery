import axios from "axios";
const url="https://localhost:44321/api/User";
export default class UserService{
    
    login(payload){
        return axios.post(url+"/login",payload);
    }
    signup(payload){
        return axios.post(url+"/signup",payload);
    }
}