
import { useEffect, useState } from "react"
import { Modal, ModalBody, ModalHeader, Form, FormGroup, Label, Input, ModalFooter, Button  } from "reactstrap"

const modeloPlayer = {
    id: 0,
    name: "",
    lastName: "",
    position: "",
    teamId: 1
}

const ModalPlayer = ({ mostrarModal, setMostrarModal, guardarProducto, edit, setEdit, editPlayer }) => {

    const [player, setPlayer] = useState(modeloPlayer);

    const actualizarDato = (e) => {
        setPlayer(
            {
                ...player,
                [e.target.name]: e.target.value
            }
        )
    }

    const enviarDatos = () => {
        if (player.id == 0) {
            guardarProducto(player)
        } else {
            editPlayer(player)
        }
    }

    useEffect(() => {
        if (edit != null) {
            setPlayer(edit)
        } else {
            setPlayer(modeloPlayer)
        }
    }, [edit])

    const closeModal = () => {
        setMostrarModal(!mostrarModal)
        setEdit(null)
    }

    return (

        <Modal isOpen={mostrarModal}>
            <ModalHeader>
                {player.id == 0 ? "Nuevo Jugador" : "Editar Jugador"}
            </ModalHeader>
            <ModalBody>
                <Form>
                    <FormGroup>
                        <Label>Nombre</Label>
                        <Input name="name" onChange={(e) => actualizarDato(e)} value={player.name} />
                    </FormGroup>
                    <FormGroup>
                        <Label>Apellidos</Label>
                        <Input name="lastName" onChange={(e) => actualizarDato(e)} value={player.lastName} />
                    </FormGroup>
                    <FormGroup>
                        <Label>Posición</Label>
                        <Input name="position" onChange={(e) => actualizarDato(e)} value={player.position} />
                    </FormGroup>
                </Form>
            </ModalBody>

            <ModalFooter>
                <Button color="primary" size="sm" onClick={enviarDatos}>Guardar</Button>
                <Button color="danger" size="sm" onClick={closeModal}>Cerrar</Button>
            </ModalFooter>

        </Modal>
    )
}

export default ModalPlayer;