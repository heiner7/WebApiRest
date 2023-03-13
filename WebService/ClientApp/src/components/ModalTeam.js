import { useEffect, useState } from "react"
import { Modal, ModalBody, ModalHeader, Form, FormGroup, Label, Input, ModalFooter, Button } from "reactstrap"

const modeloTeam = {
    id: 0,
    name: "",
    foundation: 0,
    city: "",
    coach: ""
}

const ModalTeam = ({ data, mostrarModal, setMostrarModal, guardarTeam, edit, setEdit, editTeam }) => {

    const [team, setTeam] = useState(modeloTeam);

    const actualizarDato = (e) => {
        setTeam(
            {
                ...team,
                [e.target.name]: e.target.value
            }
        )
    }

    const enviarDatos = () => {
        if (team.id == 0) {
            guardarTeam(team)
        } else {
            editTeam(team)
        }
        setTeam(modeloTeam)
    }

    useEffect(() => {
        if (edit != null) {
            setTeam(edit)
        } else {
            setTeam(modeloTeam)
        }
    }, [edit])

    const closeModal = () => {
        setMostrarModal(!mostrarModal)
        setEdit(null)
    }

    return (

        <Modal isOpen={mostrarModal}>
            <ModalHeader>
                {team.id == 0 ? "Nuevo Team" : "Editar Team"}
            </ModalHeader>
            <ModalBody>
                <Form>
                    <FormGroup>
                        <Label>Nombre</Label>
                        <Input name="name" onChange={(e) => actualizarDato(e)} value={team.name} />
                    </FormGroup>
                    <FormGroup>
                        <Label>Fundación</Label>
                        <Input name="foundation" onChange={(e) => actualizarDato(e)} value={team.foundation} />
                    </FormGroup>
                    <FormGroup>
                        <Label>Ciudad</Label>
                        <Input name="city" onChange={(e) => actualizarDato(e)} value={team.city} />
                    </FormGroup>
                    <FormGroup>
                        <Label>Entrenador</Label>
                        <Input name="coach" onChange={(e) => actualizarDato(e)} value={team.coach} />
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

export default ModalTeam;