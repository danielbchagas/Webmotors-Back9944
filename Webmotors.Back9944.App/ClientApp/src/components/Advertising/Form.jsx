import React, { useState, useEffect } from "react";

import { Makers, Models, Versions, Vehicles } from "../../services/WebmotorsService";

const Form = (props) => {
    const [id, setId] = useState(props.match.params.id || 0);
    
    useEffect(() => {
        getMakers();
    }, []);

    const montaDropdown = (element, data) => {
        var option = new Option(data.name, data.id);
        element.add(option);
    }

    const desmontaDropdown = (element) => {
        //
    }

    const getMakers = () => {
        Makers()
        .then(response => {
            if(response.status === 200){
                var dropdown = document.getElementById("dropdownMarcas");
                
                response.data.map(m => {
                    montaDropdown(dropdown, m);
                });
                
                dropdown.removeAttribute("disabled");
                dropdown.addEventListener("change", (event) => {
                    getModels(event.target.value);
                }, false);
            }
        })
        .catch(error => alert(error));
    }

    const getModels = (id) => {
        Models(id)
        .then(response => {
            if(response.status === 200){
                var dropdown = document.getElementById("dropdownModelos");
                
                response.data.map(m => {
                    desmontaDropdown(dropdown);
                    montaDropdown(dropdown, m);
                });
                
                dropdown.removeAttribute("disabled");
                dropdown.addEventListener("change", (event) => {
                getVersions(event.target.value);
                }, false);
            }
        })
        .catch(error => alert(error));
    }

    const getVersions = (id) => {
        Versions(id)
        .then(response => {
            if(response.status === 200){
                var dropdown = document.getElementById("dropdownVersoes");
                
                response.data.map(m => {
                    desmontaDropdown(dropdown);
                    montaDropdown(dropdown, m);
                });
                
                dropdown.removeAttribute("disabled");
                dropdown.addEventListener("change", (event) => {
                // getVersions(event.target.value);
                }, false);
            }
        })
        .catch(error => alert(error));
    }

    const getVehicles = (id) => {
        Vehicles(id)
        .then(response => {
            if(response.status === 200){
                //
            }
        })
        .catch(error => alert(error));
    }

    return(<>
        <form>
            <div className="row">
                <div className="col-md-4">
                    <div>
                        <label>Marca</label>
                    </div>
                    <select id="dropdownMarcas" disabled={true} className="form-control"></select>
                </div>

                <div className="col-md-4">
                    <div>
                        <label>Modelo</label>
                    </div>
                    <select id="dropdownModelos" disabled={true} className="form-control"></select>
                </div>

                <div className="col-md-4">
                    <div>
                        <label>Versao</label>
                    </div>
                    <select id="dropdownVersoes" disabled={true} className="form-control"></select>
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