import { Route, Routes } from 'react-router-dom';
import LoginPage from "./Pages/Login-Signup/LoginPage";
import SignupPage from "./Pages/Login-Signup/SignupPage";


function App() {
  return (
    <div className="App">
     <Routes>
       <Route>
       <Route path='/' element={<LoginPage />} />
       <Route path='/Loginpage' element={<LoginPage />} />
       <Route path='/Signuppage' element={<SignupPage/>} />
       </Route>
     </Routes>
    </div>
  );
}

export default App;
