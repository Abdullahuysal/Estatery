import './App.css';
import Login from "./pages/User/Login";
import House from "./pages/RealEstate/HouseList"
import 'bootstrap/dist/css/bootstrap.min.css';
import { Route, Routes } from 'react-router-dom';
function App() {
  return (
    <div className="App">
      <Routes>
        <Route>
          <Route path='/' element={<House/>}/>
          <Route path='/Login' element={<Login/>}/>
        </Route>
      </Routes>
    </div>
  );
}

export default App;
