import React, { useState, useEffect } from "react";

import { Makers, Models, Versions, Vehicles } from "../../services/WebmotorsService";

const Form = (props) => {
    const [id, setId] = useState(props.match.params.id || 0);
    const [makers, setMakers] = useState([]);
    const [models, setModels] = useState([]);
    const [versions, setVersions] = useState([]);
    const [vehicles, setVehicles] = useState([]);

    useEffect(() => {
        // Makers
        if(makers.length === 0) {
            getMakers();
        }
        else {
            const dropdown = document.getElementById("dropdownMakers");
            mountModelsDropdown(dropdown, getModels);
        }

        // Models
        if(models.length > 0) {
            const dropdown = document.getElementById("dropdownModels");
            mountModelsDropdown(dropdown, getVersions);
        }
        
        // Versions
        if(versions.length > 0) {
            const dropdown = document.getElementById("dropdownVersions");
            mountModelsDropdown(dropdown, getVehicles);
        }

        // // Vehicles
        
    }, [makers, models, versions, vehicles]);

    const getMakers = () => {
        Makers()
        .then(response => {
            if(response.status === 200){
                setMakers(response.data);
            }
        })
        .catch(error => alert(error));
    }

    const mountModelsDropdown = (element, callback) => {
        element.addEventListener("change", (event) => {
            callback(event.target.value);
        }, false);
    };

    const getModels = (id) => {
        Models(id)
        .then(response => {
            if(response.status === 200){
                setModels(response.data);
            }
        })
        .catch(error => alert(error));
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

    const getVehicles = (id) => {
        Vehicles(id)
        .then(response => {
            if(response.status === 200){
                setVehicles(response.data);
            }
        })
        .catch(error => alert(error));
    }

    const renderDropdownMakers = (data) => {
        return (
            <select id="dropdownMakers" className="form-control">
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
        <select id="dropdownModels" className="form-control">
            {
                data.map(m => 
                    <option key={m.id} value={m.id}>{m.name}</option>    
                )
            }
        </select>)
    }

    const renderDropdownVersions = (data) => {
        return(
            <select id="dropdownVersions" className="form-control">
                {
                    data.map(m => 
                        <option key={m.id} value={m.id}>{m.name}</option>    
                    )
                }
            </select>
        );
    }

    return(<>
        <form>
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
                <div className="col-md-4">
                    <div>
                        <label>Ano</label>
                    </div>
                    <input className="form-control" name="Ano" type="number" required/>
                </div>

                <div className="col-md-4">
                    <div>
                        <label>Quilometragem</label>
                    </div>
                    <input className="form-control" name="Quilometragem" type="number" required/>
                </div>

                <div className="col-md-4">
                    <div>
                        <label>Observacao</label>
                    </div>
                    <input className="form-control" name="Observacao" type="text" required/>
                </div>
            </div>

            <div className="row mt-3">
                <div className="col-md-6">
                    <button className="btn btn-primary mr-1" type="submit">Save Changes</button>
                    <button className="btn btn-danger mr-1" type="reset">Reset</button>
                    <button className="btn btn-dark" onClick={() => props.history.goBack()}>Back</button>
                </div>
            </div>
        </form>
    </>);
}

export default Form;