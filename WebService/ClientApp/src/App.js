
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import ViewPlayer from "./components/ViewPlayer";
import Login from "./components/Login";
import Home from "./components/Home";

function App() {
    return (
        <div>
            <ToastContainer
                position="top-center"
                autoClose={5000}
                limit={1}
                hideProgressBar={false}
                newestOnTop
                closeOnClick
                rtl={false}
                pauseOnFocusLoss={false}
                draggable
                pauseOnHover
                theme="dark"
            />
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