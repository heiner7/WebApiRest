import { Col, Container, Row, Card, CardHeader, CardBody, Button } from "reactstrap"
import { toast } from "react-toastify";
import { useEffect, useState } from "react";
import TablaTeam from "./TablaTeam";
import ModalTeam from "./ModalTeam";

const ViewTeam = () => {

    const [teams, setTeams] = useState([])
    const [mostrarModal, setMostrarModal] = useState(false);
    //Variable que almacena la informacion a editar
    const [edit, setEdit] = useState(null)

    const mostrarTeam = async () => {
        const response = await fetch("api/team/obtenerTeam");
        if (response.ok) {

            const data = await response.json();
            setTeams(data)
        } else {
            toast.info('¡No hay datos para mostrar!', {
                position: "top-center",
                autoClose: 3000,
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
        mostrarTeam()
    }, [])

    return (
        <Container>
            {/* Espacio entre sección */}
            <div style={{ height: '70px' }}></div>

            <Row className="mt-5">

                <Col sm="12">
                    <Card>
                        <CardHeader>
                            <h5>Lista de equipos</h5>
                        </CardHeader>
                        <CardBody>
                            <Button size="sm" color="success" onClick={() => setMostrarModal(!mostrarModal)}>Nuevo equipo</Button>
                            <hr></hr>
                            <TablaTeam data={teams}
                                setEdit={setEdit}
                                mostrarModal={mostrarModal}
                                setMostrarModal={setMostrarModal}

                                //removeTeam={removeTeam}
                            />
                        </CardBody>
                    </Card>
                </Col>

            </Row>

            <ModalTeam data={teams}
                mostrarModal={mostrarModal}
                setMostrarModal={setMostrarModal}
                //guardarTeam={salveTeam}

                edit={edit}
                setEdit={setEdit}
                //editTeam={editTeam}
            />
        </Container>
    )

}

export default ViewTeam;