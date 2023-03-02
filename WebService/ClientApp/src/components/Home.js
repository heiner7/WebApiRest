import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";

const Home = () => {
    const usenavigate = useNavigate();
    const [customerlist, listupdate] = useState(null);
    const [displayusername, displayusernameupdate] = useState('');
    useEffect(() => {
        let username = sessionStorage.getItem('username');
        if (username === '' || username === null) {
            usenavigate('/login');
        } else {
            displayusernameupdate(username);
        }

        let jwttoken = sessionStorage.getItem('jwttoken');
        fetch("https://localhost:5001/Auth/Login", {
            headers: {
                'Authorization': 'bearer ' + jwttoken
            }
        }).then((res) => {
            return res.json();
        }).then((resp) => {
            listupdate(resp);
        }).catch((err) => {
            console.log(err.messsage)
        });

    }, []);

    return (
        <div>
            <div className="header">
                <Link to={'/'}>Home</Link>
                <span style={{ marginLeft: '80%' }}>Welcome <b>{displayusername}</b></span>
                <Link style={{ float: 'right' }} to={'/login'}>Logout</Link>
            </div>
            <h1 className="text-center">Welcome to Nihira Techiees</h1>
            <table className="table table-bordered">
                <thead>
                    <tr>
                        <td>Code</td>
                        <td>Name</td>
                        <td>Email</td>
                        <td>Credit Limit</td>
                    </tr>
                </thead>
                <tbody>
                    {customerlist &&
                        customerlist.map(item => (
                            <tr key={item.id}>
                                <td>{item.id}</td>
                                <td>{item.name}</td>
                                <td>{item.email}</td>
                                <td>{item.creditLimit}</td>
                            </tr>

                        ))
                    }
                </tbody>

            </table>
        </div>
    );
}

export default Home;
