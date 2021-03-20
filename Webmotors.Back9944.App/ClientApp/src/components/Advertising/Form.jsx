import React, { useState, useEffect } from "react";

import { Makers, Models, Versions } from "../../services/WebmotorsService";
import { Create, Update, GetById } from "../../services/AdvertisingService";

const Form = (props) => {
    const [id, setId] = useState(props.match.params.id || 0);
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
        .catch(error => alert(error));
    }

    const getMakers = () => {
        Makers()
        .then(response => {
            if(response.status === 200){
                setMakers(response.data);
            }
        })
        .catch(error => alert(error));
    }

    const getModels = (id) => {
        Models(id)
        .then(response => {
            if(response.status === 200){
                setModels(response.data);
            }
        })
        .catch(error => alert(error));

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
        .catch(error => alert(error));
    }

    //#region Dropdowns
    const mountDropdown = (element, callback) => {
        element.addEventListener("change", (event) => {
            callback(event.target.value);
        }, false);
    };

    const renderDropdownMakers = (data) => {
        return (
            <select name="Marca" disabled={data.length === 0 ? true : false} id="dropdownMakers" className="form-control">
                <option value="0">-- Selecione --</option>
                {
                    data.map(m => 
                        <option key={m.id} value={m.id}>{m.name}</option>    
                    )
                }
            </select>
        );
    }

    const renderDropdownModels = (data) => {
        return (
        <select name="Modelo" disabled={data.length === 0 ? true : false} id="dropdownModels" className="form-control">
            <option value="0">-- Selecione --</option>
            {
                data.map(m => 
                    <option key={m.id} value={m.id}>{m.name}</option>    
                )
            }
        </select>)
    }

    const renderDropdownVersions = (data) => {
        return(
            <select name="Versao" disabled={data.length === 0 ? true : false} id="dropdownVersions" className="form-control">
                <option value="0">-- Selecione --</option>
                {
                    data.map(m => 
                        <option key={m.id} value={m.id}>{m.name}</option>    
                    )
                }
            </select>
        );
    }
    //#endregion

    const handleSubmit = () => {
        const form = document.getElementById("form");
        
        form.addEventListener("submit", (event) => {
            event.preventDefault();
        });

        const data = {
            marca: form.elements["Marca"].value,
            modelo: form.elements["Modelo"].value,
            versao: form.elements["Versao"].value,
            ano: form.elements["Ano"].value,
            quilometragem: form.elements["Quilometragem"].value,
            observacao: form.elements["Observacao"].value
        }

        if(id === 0) {
            Create(data)
            .then(response => {
                if(response.status === 200) {
                    alert("Success!");

                    props.history.goBack();
                }
            })
            .catch(error => alert("Erro ao salvar!"));
        }
        else {
            data.id = id;

            Update(data)
            .then(response => {
                if(response.status === 200) {
                    alert("Success!");

                    props.history.goBack();
                }
            })
            .catch(error => alert("Erro ao atualizar!"));
        }
    }

    return(<>
        {
            current !== null 
            ? <div className="card mb-3">
                <div className="card-body">
                    <h5>Sobre o anúncio:</h5>
                    
                    <div><strong>Marca:</strong> {current.marca}</div>
                    <div><strong>Modelo:</strong> {current.modelo}</div>
                    <div><strong>Versão:</strong> {current.versao}</div>
                    <div><strong>Ano:</strong> {current.ano}</div>
                    <div><strong>Quilometragem:</strong> {current.quilometragem}</div>
                    <div><strong>Observações:</strong> {current.observacao}</div>
                </div>
            </div>  
            : ""
        }
        

        <form id="form">
            <div className="row">
                <div className="col-md-4">
                    <div>
                        <label>Marca</label>
                    </div>
                    {renderDropdownMakers(makers)}
                </div>

                <div className="col-md-4">
                    <div>
                        <label>Modelo</label>
                    </div>
                    {renderDropdownModels(models)}
                </div>

                <div className="col-md-4">
                    <div>
                        <label>Versão</label>
                    </div>
                    {renderDropdownVersions(versions)}
                </div>
            </div>

            <div className="row">
                <div className="col-md-2">
                    <div>
                        <label>Ano</label>
                    </div>
                    <input className="form-control" name="Ano" type="number" min={0}/>
                </div>

                <div className="col-md-2">
                    <div>
                        <label>Quilometragem</label>
                    </div>
                    <input className="form-control" name="Quilometragem" type="number" min={0}/>
                </div>

                <div className="col-md-8">
                    <div>
                        <label>Observacao</label>
                    </div>
                    <textarea rows={5} className="form-control" name="Observacao" type="text"/>
                </div>
            </div>

            <div className="row mt-3">
                <div className="col-md-6">
                    <button className="btn btn-primary mr-1" onClick={() => handleSubmit()}>Save Changes</button>
                    <button className="btn btn-danger mr-1" type="reset">Reset</button>
                    <button className="btn btn-dark" onClick={() => props.history.push("/advertising")}>Back</button>
                </div>
            </div>
        </form>
    </>);
}

export default Form;