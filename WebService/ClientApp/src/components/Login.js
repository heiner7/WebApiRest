import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { toast } from "react-toastify";

const Login = () => {
    const usenavigate = useNavigate();
    const [email, emailupdate] = useState('');
    const [password, passwordupdate] = useState('');

   // const usenavigate = useNavigate();

    useEffect(() => {
        sessionStorage.clear();
        emailupdate("string3@gmail.com")
        passwordupdate("String12!")
    }, []);

    
    const ProceedLoginusingAPI = async (e) => {
        e.preventDefault();
        if (validate()) {
            ///implentation
            // console.log('proceed');
            let inputobj = {
                "Email": email,
                "Password": password
            };
            const response= await fetch("api/auth/Login", {
                method: "POST",
                
                headers: { 'content-type': 'application/json;charset=utf-8' },
                body: JSON.stringify(inputobj)
             })
            if (response.ok) {
                const data = await response.json();
                
                sessionStorage.setItem('username', email);
                sessionStorage.setItem('jwttoken', data.token);
                sessionStorage.setItem('rol', data.rol);
                usenavigate('/viewTask')
            } else if (response.status == 400) {
                const data = await response.json();
                toast.error("Error: "+ data.errors, {
                    position: "top-center",
                    autoClose: 5000,
                    hideProgressBar: false,
                    closeOnClick: true,
                    pauseOnHover: true,
                    draggable: true,
                    progress: undefined,
                    theme: "dark",
                });
            } else {
                toast.error('¡Error en la conexión con el servidor!', {
                    position: "top-center",
                    autoClose: 5000,
                    hideProgressBar: false,
                    closeOnClick: true,
                    pauseOnHover: true,
                    draggable: true,
                    progress: undefined,
                    theme: "dark",
                });              
            }
                    
                
        }
    }
    const validate = () => {
        let result = true;
        if (email === '' || email === null) {
            result = false;
            toast.warning('Ingrese el email');
        }
        if (password === '' || password === null) {
            result = false;
            toast.warning('Ingrese la contraseña');
        }
        return result;
    }
    return (
        <div className="row">
            <div className="offset-lg-3 col-lg-6" style={{ marginTop: '100px' }}>
                <form onSubmit={ProceedLoginusingAPI} className="container">
                    <div className="card">
                        <div className="card-header">
                            <h2>Inicio de sesión de usuario</h2>
                        </div>
                        <div className="card-body">
                            <div className="form-group">
                                <label>Correo electrónico <span className="errmsg">*</span></label>
                                <input value={email} onChange={e => emailupdate(e.target.value)} className="form-control"></input>
                            </div>
                            <div className="form-group">
                                <label>Contraseña <span className="errmsg">*</span></label>
                                <input type="password" value={password} onChange={e => passwordupdate(e.target.value)} className="form-control"></input>
                            </div>
                        </div>
                        <div className="card-footer">
                            <button type="submit" className="btn btn-primary">Login</button> |
                            <Link className="btn btn-success" to={'/register'}>New User</Link>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default Login;