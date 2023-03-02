
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';

import ViewPlayer from "./components/ViewPlayer";
import Login from "./components/Login";
import Home from "./components/Home";

function App() {
    return (
        <div>
            
            <BrowserRouter>
                <Routes>
                    <Route path='/' element={<Home />}></Route>
                    <Route path='/viewPlayer' element={<ViewPlayer />}></Route>
                    <Route path='/login' element={<Login />}></Route>
                </Routes>

            </BrowserRouter>

        </div>
    );
}
export default App;