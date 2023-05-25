
import { Table, Button } from "reactstrap"
import React, { useState } from 'react';
import ReactPaginate from 'react-paginate';


const TablaPlayer = ({ data, setEdit, mostrarModal, setMostrarModal, removePlayer }) => {

    const [currentPage, setCurrentPage] = useState(0);
    const itemsPerPage = 5; // Cantidad de elementos por página
    const pageCount = Math.ceil(data.length / itemsPerPage); // Cantidad total de páginas


    const sendData = (player) => {
        setEdit(player)
        setMostrarModal(!mostrarModal)
    }

    const handlePageChange = ({ selected }) => {
        setCurrentPage(selected);
    };

    const offset = currentPage * itemsPerPage;
    const currentPageData = data.slice(offset, offset + itemsPerPage);

    return (

        <Table striped responsive>
            <thead>
                <tr>
                    <th>Nombre</th>
                    <th>Apellidos</th>
                    <th>Posición</th>
                    <th>Opciones</th>
                </tr>
            </thead>
            
            <tbody>
                {currentPageData.length < 1 ? (
                    <tr>
                        <td colSpan="4">Sin registros</td>
                    </tr>
                ) : (
                    currentPageData.map((item) => (
                        <tr key={item.id}>
                            <td>{item.name}</td>
                            <td>{item.lastName}</td>
                            <td>{item.position}</td>
                            <td>
                                <Button color="primary" size="sm" className="me-2" onClick={() => sendData(item)}>
                                    Editar
                                </Button>
                                <Button color="danger" size="sm" onClick={() => removePlayer(item.id)}>
                                    Eliminar
                                </Button>
                            </td>
                        </tr>
                    ))
                )}
            </tbody>
            <ReactPaginate
                previousLabel={'Anterior'}
                nextLabel={'Siguiente'}
                pageCount={pageCount}
                onPageChange={handlePageChange}
                containerClassName={'pagination'}
                activeClassName={'active'}
            />

        </Table>

    )
}

export default TablaPlayer;