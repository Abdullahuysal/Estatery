import './App.css';
import { Route, Routes } from 'react-router-dom';
import Login from "./pages/User/Login";
import Signup from "./pages/User/Signup";
import Userinfo from "./pages/User/UserInfo";
import House from "./pages/RealEstate/HouseList";
import HouseDetail from './pages/RealEstate/HouseDetail';
import Land  from "./pages/RealEstate/LandList";
import LandDetail from "./pages/RealEstate/LandDetail";
import WorkPlace from "./pages/RealEstate/WorkPlaceList";
import WorkPlaceDetail from "./pages/RealEstate/WorkPlaceDetail";
import Addhouse from './pages/RealEstate/Addhouse';
import Addland from './pages/RealEstate/Addland';
import Addworkplace from './pages/RealEstate/Addworkplace';
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {
  return (
    <div className="App">
      <Routes>
        <Route>
          <Route path='/' element={<House/>}/>
          <Route path='/HouseList' element={<House/>}/>
          <Route path='/HouseDetail' element={<HouseDetail/>}/>
          <Route path='/LandList' element={<Land/>}/>
          <Route path='/LandDetail' element={<LandDetail/>}/>
          <Route path='/WorkPlaceList' element={<WorkPlace/>}/>
          <Route path='/WorkPlaceDetail' element={<WorkPlaceDetail/>}/>
          <Route path='/Login' element={<Login/>}/>
          <Route path='/Signup' element={<Signup/>}/>
          <Route path='/UserInfo' element={<Userinfo/>}/>
          <Route path='/Addhouse' element={<Addhouse/>}/>
          <Route path='/Addland' element={<Addland/>}/>
          <Route path='/Addworkplace' element={<Addworkplace/>}/>
        </Route>
      </Routes>
    </div>
  );
}

export default App;
