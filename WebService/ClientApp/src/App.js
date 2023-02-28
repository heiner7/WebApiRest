
import { Col, Container, Row, Card, CardHeader, CardBody, Button } from "reactstrap"
import { BrowserRouter, Route, Routes } from 'react-router-dom';

import { ToastContainer } from 'react-toastify';
import TablaPlayer from "./components/TablaPlayer";
import { useEffect, useState } from "react";
import ModalPlayer from "./components/ModalPlayer";

const App = () => {

    const [player, setPlayer] = useState([])
    const [mostrarModal, setMostrarModal] = useState(false);

    const mostrarProduct = async () => {
        const response = await fetch("api/player/obtenerPlayer");
        console.log(response)
        if (response.ok) {
            const data = await response.json();
            setPlayer(data)
        } else {
            console.log("error")
        }
    }

    useEffect(() => {
        mostrarProduct()
    }, [])

    const guardarProducto = async (player) => {
        const response = await fetch("api/player/savePlayer", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=uft-8'
            },
            body: JSON.stringify(player)
        })

        if (response.ok) {
            setMostrarModal(!mostrarModal);
            mostrarProduct();
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
                            <TablaPlayer data={player} />
                        </CardBody>
                    </Card>
                </Col>

            </Row>

            <ModalPlayer
                mostrarModal={mostrarModal}
                setMostrarModal={setMostrarModal}
                guardarProducto={guardarProducto}
            />
        </Container>
    )
}
export default App;