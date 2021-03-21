import React from "react";

const DropdownVersion = ({data}) => {
    return(
        <select name="Versao" disabled={data.length === 0 ? true : false} id="dropdownVersions" className="form-control" required>
            <option value="">-- Selecione --</option>
            {
                data.map(m => 
                    <option key={m.id} value={m.id}>{m.name}</option>    
                )
            }
        </select>
    );
}

export default DropdownVersion;