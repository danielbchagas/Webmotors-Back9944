import React from "react";

const DropdownMaker = ({data}) => {
    return (
        <select name="Marca" disabled={data.length === 0 ? true : false} id="dropdownMakers" className="form-control" required>
            <option value="">-- Selecione --</option>
            {
                data.map(m => 
                    <option key={m.id} value={m.id}>{m.name}</option>    
                )
            }
        </select>
    );
}

export default DropdownMaker;