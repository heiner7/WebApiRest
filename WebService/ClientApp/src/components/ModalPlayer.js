
import { useState } from "react"
import { Modal, ModalBody, ModalHeader, Form, FormGroup, Label, Input, ModalFooter, Button  } from "reactstrap"

const modeloPlayer = {
    Id: 0,
    Name: "",
    LastName: "",
    Position: "",
    TeamId: 1
}

const ModalPlayer = ({mostrarModal, setMostrarModal, guardarProducto }) => {

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
        if (player.Id == 0) {
            guardarProducto(player)
        }
    }

    return (

        <Modal isOpen={mostrarModal}>
            <ModalHeader>
                Nuevo Player
            </ModalHeader>
            <ModalBody>
                <Form>
                    <FormGroup>
                        <Label>Nombre</Label>
                        <Input name="Name" onChange={(e) => actualizarDato(e)} value={player.Name} />
                    </FormGroup>
                    <FormGroup>
                        <Label>Apellidos</Label>
                        <Input name="LastName" onChange={(e) => actualizarDato(e)} value={player.LastName} />
                    </FormGroup>
                    <FormGroup>
                        <Label>Posición</Label>
                        <Input name="Position" onChange={(e) => actualizarDato(e)} value={player.Position} />
                    </FormGroup>
                </Form>
            </ModalBody>

            <ModalFooter>
                <Button color="primary" size="sm" onClick={enviarDatos}>Guardar</Button>
                <Button color="danger" size="sm" onClick={() => setMostrarModal(!mostrarModal)}>Cerrar</Button>
            </ModalFooter>

        </Modal>
    )
}

export default ModalPlayer;