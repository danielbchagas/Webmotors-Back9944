import React, { useState, useEffect } from "react";

import Swal from "sweetalert2";

import { Makers, Models, Versions } from "../../services/WebmotorsService";
import { Create, Update, GetById } from "../../services/AdvertisingService";

import DropdownVersion from "./DropdownVersion";
import DropdownModel from "./DropdownModel";
import DropdownMaker from "./DropdownMaker";
import ResumeCard from "./ResumeCard";

const Form = (props) => {
    const id = props.match.params.id || 0;

    const [makers, setMakers] = useState([]);
    const [models, setModels] = useState([]);
    const [versions, setVersions] = useState([]);

    const [current, setCurrent] = useState(null);

    useEffect(() => {
        getCurrentAdvertising();

        // Makers
        getMakers();
        const dropdown = document.getElementById("dropdownMakers");
        mountDropdown(dropdown, getModels);
    }, []);

    const getCurrentAdvertising = () => {
        GetById(id)
        .then(response => {
            if(response.status === 200) {
                setCurrent(response.data);
            }
        })
        .catch(error => {
            Swal.fire({
                icon: "error",
                text: "Houve um erro com a operação!"
            });
        });
    }

    const getMakers = () => {
        Makers()
        .then(response => {
            if(response.status === 200){
                setMakers(response.data);
            }
        })
        .catch(error => {
            Swal.fire({
                icon: "error",
                text: "Houve um erro com a operação!"
            });
        });
    }

    const getModels = (id) => {
        Models(id)
        .then(response => {
            if(response.status === 200){
                setModels(response.data);
            }
        })
        .catch(error => {
            Swal.fire({
                icon: "error",
                text: "Houve um erro com a operação!"
            });
        });

        const dropdown = document.getElementById("dropdownModels");
        mountDropdown(dropdown, getVersions);
    }

    const getVersions = (id) => {
        Versions(id)
        .then(response => {
            if(response.status === 200){
                setVersions(response.data);
            }
        })
        .catch(error => {
            Swal.fire({
                icon: "error",
                text: "Houve um erro com a operação!"
            });
        });
    }

    const mountDropdown = (element, callback) => {
        element.addEventListener("change", (event) => {
            callback(event.target.value);
        }, false);
    };

    const saveChanges = (data) => {
        if(data.id === 0) {
            Create(data)
            .then(response => {
                if(response.status === 201) {
                    Swal.fire({
                        title: 'Pronto!',
                        text: 'Anúncio salvo com sucesso!',
                        icon: 'success'
                    })
                    .then(result => {
                        if(result.isConfirmed) {
                            props.history.goBack();
                        }
                    });
                }
            })
            .catch(error => {
                Swal.fire({
                    icon: "error",
                    text: "Houve um erro com a operação!"
                });
            });
        }
        else {
            Update(data)
            .then(response => {
                if(response.status === 200) {
                    Swal.fire({
                        title: 'Pronto!',
                        text: 'Anúncio salvo com sucesso!',
                        icon: 'success'
                    })
                    .then(result => {
                        if(result.isConfirmed) {
                            props.history.goBack();
                        }
                    });
                }
            })
            .catch(error => {
                Swal.fire({
                    icon: "error",
                    text: "Houve um erro com a operação!"
                });
            });
        }
    }
    
    const handleSubmit = () => {
        const form = document.getElementById("form");
        
        form.addEventListener("submit", (event) => {
            event.preventDefault();
        });

        const data = {
            id: id,
            marca: form.elements["Marca"].value,
            modelo: form.elements["Modelo"].value,
            versao: form.elements["Versao"].value,
            ano: form.elements["Ano"].value,
            quilometragem: form.elements["Quilometragem"].value,
            observacao: form.elements["Observacao"].value
        }

        if(data.marca === "" || data.modelo === "" || data.versao === "" || data.ano === "" || data.quilometragem === "" || data.observacao === "") return;

        
        Swal.fire({
            title: 'Tem certeza?',
            text: "O anúncio será cadastrado.",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sim, continue!'
          }).then((result) => {
            if (result.isConfirmed) {
                saveChanges(data);
            }
          })
    }

    return(<>
        {
            current !== null 
            ? <ResumeCard data={current}/>
            : ""
        }

        <form id="form">
            <div className="row">
                <div className="col-md-4">
                    <div>
                        <label>Marca</label>
                    </div>
                    <DropdownMaker data={makers}/>
                </div>

                <div className="col-md-4">
                    <div>
                        <label>Modelo</label>
                    </div>
                    <DropdownModel data={models}/>
                </div>

                <div className="col-md-4">
                    <div>
                        <label>Versão</label>
                    </div>
                    <DropdownVersion data={versions} />
                </div>
            </div>

            <div className="row">
                <div className="col-md-2">
                    <div>
                        <label>Ano</label>
                    </div>
                    <input className="form-control" name="Ano" type="number" min={0} required/>
                </div>

                <div className="col-md-2">
                    <div>
                        <label>Quilometragem</label>
                    </div>
                    <input className="form-control" name="Quilometragem" type="number" min={0} required/>
                </div>

                <div className="col-md-8">
                    <div>
                        <label>Observação</label>
                    </div>
                    <textarea rows={5} className="form-control" name="Observacao" type="text" required/>
                </div>
            </div>

            <div className="row mt-3">
                <div className="col-md-6">
                    <button className="btn btn-primary mr-1" onClick={() => handleSubmit()}>
                        <i className="fa fa-save"></i> Salvar
                    </button>
                    <button className="btn btn-danger mr-1" type="reset">
                        <i className="fa fa-ban"></i> Limpar</button>
                    <button className="btn btn-dark" onClick={() => props.history.push("/advertising")}>
                        <i class="fa fa-arrow-circle-left"></i> Voltar
                    </button>
                </div>
            </div>
        </form>
    </>);
}

export default Form;