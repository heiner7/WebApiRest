import { Table, Button } from "reactstrap"

const TablaTeam = ({ data, setEdit, mostrarModal, setMostrarModal, removeTeam }) => {

    const sendData = (team) => {
        setEdit(team)
        setMostrarModal(!mostrarModal)
    }

    return (

        <Table striped responsive>
            <thead>
                <tr>
                    <th>Nombre</th>
                    <th>Pundación</th>
                    <th>Ciudad</th>
                    <th>Entrenador</th>
                    <th>Opciones</th>
                </tr>
            </thead>
            <tbody>
                {
                    (data.length < 1) ? (
                        <tr>
                            <td colSpan="2">Sin registros</td>
                        </tr>
                    ) : (
                        data.map((item) => (
                            <tr key={item.id}>
                                <td>{item.name}</td>
                                <td>{item.foundation}</td>
                                <td>{item.city}</td>
                                <td>{item.coach}</td>
                                <td>
                                    <Button color="primary" size="sm" className="me-2" onClick={() => sendData(item)}
                                    >Editar</Button>
                                    <Button color="danger" size="sm" className="me-2" onClick={() => removeTeam(item.id)}>Eliminar</Button>
                                    <Button color="primary" size="sm" >Ver jugadores</Button>
                                </td>
                            </tr>
                        ))
                    )
                }
            </tbody>
        </Table>

    )
}

export default TablaTeam;