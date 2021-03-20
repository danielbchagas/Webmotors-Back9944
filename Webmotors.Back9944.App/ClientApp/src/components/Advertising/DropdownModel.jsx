import React from "react";

const DropdownModel = ({data}) => {
    return (
        <select name="Modelo" disabled={data.length === 0 ? true : false} id="dropdownModels" className="form-control" required>
            <option value="">-- Selecione --</option>
            {
                data.map(m => 
                    <option key={m.id} value={m.id}>{m.name}</option>    
                )
            }
        </select>);
}

export default DropdownModel;