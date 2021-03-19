import React, { useState, useEffect } from "react";

import { Makers, Models, Versions } from "../../services/WebmotorsService";

const Form = (props) => {
    const [id, setId] = useState(props.match.params.id || 0);
    const [makers, setMakers] = useState([]);
    const [models, setModels] = useState([]);
    const [versions, setVersions] = useState([]);

    useEffect(() => {
        // Makers
        getMakers();
        const dropdown = document.getElementById("dropdownMakers");
        mountDropdown(dropdown, getModels);
    }, []);

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
            <select disabled={data.length === 0 ? true : false} id="dropdownMakers" className="form-control">
                <option value="0">-- selecione --</option>
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
        <select disabled={data.length === 0 ? true : false} id="dropdownModels" className="form-control">
            <option value="0">-- selecione --</option>
            {
                data.map(m => 
                    <option key={m.id} value={m.id}>{m.name}</option>    
                )
            }
        </select>)
    }

    const renderDropdownVersions = (data) => {
        return(
            <select disabled={data.length === 0 ? true : false} id="dropdownVersions" className="form-control">
                <option value="0">-- selecione --</option>
                {
                    data.map(m => 
                        <option key={m.id} value={m.id}>{m.name}</option>    
                    )
                }
            </select>
        );
    }
    //#endregion

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
                <div className="col-md-2">
                    <div>
                        <label>Ano</label>
                    </div>
                    <input className="form-control" name="Ano" type="number" required/>
                </div>

                <div className="col-md-2">
                    <div>
                        <label>Quilometragem</label>
                    </div>
                    <input className="form-control" name="Quilometragem" type="number" required/>
                </div>

                <div className="col-md-8">
                    <div>
                        <label>Observacao</label>
                    </div>
                    <textarea rows={5} className="form-control" name="Observacao" type="text" required/>
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