
import { Table, Button } from "reactstrap"

const TablaPlayer = ({ data }) => {
    return (

        <Table striped responsive>
            <thead>
                <tr>
                    <th>Nombre</th>
                    <th>Apellidos</th>
                    <th>Posición</th>
                    <th></th>
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
                                    <td>{item.lastName}</td>
                                    <td>{item.position}</td>
                                    <td>
                                        <Button color="primary" size="sm" className="me-2">Editar</Button>
                                        <Button color="danger" size="sm">Eliminar</Button>
                                    </td>
                                </tr>
                            ))
                    )
                }
            </tbody>
        </Table>

    )
}

export default TablaPlayer;