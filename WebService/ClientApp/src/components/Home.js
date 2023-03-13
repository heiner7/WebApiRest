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

    const eventos = [
        {
            fecha: '25 de marzo',
            equipoLocal: 'Real Madrid',
            equipoVisitante: 'Barcelona',
            estadio: 'Santiago Bernabéu',
        },
        {
            fecha: '28 de marzo',
            equipoLocal: 'Manchester United',
            equipoVisitante: 'Liverpool',
            estadio: 'Old Trafford',
        },
        {
            fecha: '2 de abril',
            equipoLocal: 'Paris Saint-Germain',
            equipoVisitante: 'Marsella',
            estadio: 'Parc des Princes',
        },
    ];

    const resultados = [
        { equipo1: "Real Madrid", equipo2: "Barcelona", resultado: "2-1" },
        { equipo1: "Atletico Madrid", equipo2: "Sevilla", resultado: "0-0" },
        { equipo1: "Valencia", equipo2: "Villarreal", resultado: "3-2" }
    ];

    const clasificacion = [
        { equipo: "Real Madrid", puntos: 12 },
        { equipo: "Barcelona", puntos: 10 },
        { equipo: "Atletico Madrid", puntos: 8 },
        { equipo: "Sevilla", puntos: 8 },
        { equipo: "Valencia", puntos: 6 },
        { equipo: "Villarreal", puntos: 4 }
    ];


    return (
        <div>
            {/* Espacio entre sección */}
            <div style={{ height: '70px' }}></div>

            <h1 className="text-center">!Bienvenidos¡</h1>
            
            {/* Espacio entre sección */}
            <div style={{ height: '30px' }}></div>

            <section className="ftco-section ftco-no-pb ftco-no-pt text-white" style={{ backgroundColor: '#1C2D3F', height: '450px' }}>
                <div className="container">
                    <div className="row justify-content-center mb-5 pb-3">
                        <div className="col-md-7 heading-section text-center">
                            <h2 className="mb-4">Proximos Eventos</h2>
                        </div>
                    </div>
                    <div className="row">
                        {eventos.map((evento, index) => (
                            <div key={index} className="col-md-4 d-flex ftco-animate">
                                <div className="blog-entry align-self-stretch">
                                    <div className="card" style={{ border: '1px solid #fff', backgroundColor: 'transparent' }}>
                                        <div className="card-body">
                                            <a href="#" className="block-20 rounded" style={{ backgroundImage: "url('images/image_1.jpg')" }}></a>
                                            <div className="text mt-3">
                                                <div className="posted mb-3 d-flex">
                                                    <div className="desc pl-3">
                                                        <span>{evento.fecha}</span>
                                                        <span className="mx-2">/</span>
                                                        <span>Deportes</span>
                                                    </div>
                                                </div>
                                                <h3 className="heading">{evento.equipoLocal} vs {evento.equipoVisitante}</h3>
                                                <p>{evento.estadio}</p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        ))}
                    </div>
                </div>
            </section>

            {/* Espacio entre sección */}
            <div style={{ height: '50px' }}></div>

            {/* SECCIÓN DE TABLA DE PUNTOS Y ÚLTIMO RESULTADO */}
            <section className="results-section">
                <div className="container">
                    <div className="row">
                        <div className="col-md-6">
                            <h2>Último resultados</h2>
                            <table className="table table-bordered">
                                <thead>
                                    <tr>
                                        <th>Equipo 1</th>
                                        <th>Equipo 2</th>
                                        <th>Resultado</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {resultados.map((resultado, index) => (
                                        <tr key={index}>
                                            <td>{resultado.equipo1}</td>
                                            <td>{resultado.equipo2}</td>
                                            <td>{resultado.resultado}</td>
                                        </tr>
                                    ))}
                                </tbody>
                            </table>
                        </div>
                        <div className="col-md-6">
                            <h2>Tabla de puntos</h2>
                            <table className="table table-bordered">
                                <thead>
                                    <tr>
                                        <th>Equipo</th>
                                        <th>Puntos</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {clasificacion.map((equipo, index) => (
                                        <tr key={index}>
                                            <td>{equipo.equipo}</td>
                                            <td>{equipo.puntos}</td>
                                        </tr>
                                    ))}
                                </tbody>
                            </table>
                        </div>
                    </div>             
                </div>
            </section>

        </div>
    );
}

export default Home;
