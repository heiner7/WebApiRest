import { Col, Container, Row, Card, CardHeader, CardBody, Button } from "reactstrap"
import { toast } from "react-toastify";
import TablaPlayer from "./TablaPlayer";
import { useEffect, useState } from "react";
import ModalPlayer from "./ModalPlayer";

const ViewPlayer = () => {

    const [players, setPlayer] = useState([])
    const [mostrarModal, setMostrarModal] = useState(false);
    //Variable que almacena la informacion a editar
    const [edit, setEdit] = useState(null)

    const mostrarPlayer = async () => {
        const response = await fetch("api/player/obtenerPlayer");
        console.log(response)
        if (response.ok) {
            const data = await response.json();
            setPlayer(data)
        } else {
            toast.info('¡No hay datos para mostrar!', {
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

    useEffect(() => {
        mostrarPlayer()
    }, [])

    const salvePlayer = async (player) => {
        let jwttoken = sessionStorage.getItem('jwttoken');

        const response = await fetch("api/player/savePlayer", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8',
                'Authorization': jwttoken
            },
            body: JSON.stringify(player)
        })

        if (response.ok) {
            setMostrarModal(!mostrarModal);
            mostrarPlayer();
        } else if (response.status == 401) {
            setMostrarModal(!mostrarModal);
            toast.error('¡No esta autorizado!', {
                position: "top-center",
                autoClose: 5000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
                theme: "dark",
            });
        } else if (response.status == 500) {
            setMostrarModal(!mostrarModal);
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
        } else {
            setMostrarModal(!mostrarModal);
            toast.error('¡Posible campos vacios!', {
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

    const editPlayer = async (player) => {
        let jwttoken = sessionStorage.getItem('jwttoken');
        console.log("Token: " + jwttoken)
        const response = await fetch("api/player/editPlayer", {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json;charset=utf-8',
                'Authorization': jwttoken
            },
            body: JSON.stringify(player)
        })

        if (response.ok) {
            setMostrarModal(!mostrarModal);
            mostrarPlayer();
        } else if (response.status == 401) {
            setMostrarModal(!mostrarModal);
            toast.error('¡No esta autorizado!', {
                position: "top-center",
                autoClose: 5000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
                theme: "dark",
            });
        } else if (response.status == 500) {
            setMostrarModal(!mostrarModal);
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
        } else {
            setMostrarModal(!mostrarModal);
            toast.error('¡Posible campos vacios!', {
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

    const removePlayer = async (id) => {

        const responseWindow = window.confirm("¿Desea eliminar el jugador?")

        if (!responseWindow) {
            return;
        }

        const response = await fetch("api/player/removePlayer/" + id, {
            method: 'DELETE'
        })

        if (response.ok) {
            mostrarPlayer();
        } else if (response.status == 400) {
            console.log("error con el formato")
        } else {
            console.log("error con el servidor")
        }
    }

    return (
        <Container>
            <Row className="mt-5">

                <Col sm="12">
                    <Card>
                        <CardHeader>
                            <h5>Lista de productos</h5>
                        </CardHeader>
                        <CardBody>
                            <Button size="sm" color="success" onClick={() => setMostrarModal(!mostrarModal)}>Nuevo producto</Button>
                            <hr></hr>
                            <TablaPlayer data={players}
                                setEdit={setEdit}
                                mostrarModal={mostrarModal}
                                setMostrarModal={setMostrarModal}

                                removePlayer={removePlayer}
                            />
                        </CardBody>
                    </Card>
                </Col>

            </Row>

            <ModalPlayer
                mostrarModal={mostrarModal}
                setMostrarModal={setMostrarModal}
                guardarProducto={salvePlayer}

                edit={edit}
                setEdit={setEdit}
                editPlayer={editPlayer}
            />
        </Container>
    )
}
export default ViewPlayer;