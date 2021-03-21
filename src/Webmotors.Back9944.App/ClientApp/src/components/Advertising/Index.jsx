import React, { useEffect, useState } from "react";

import { Get, Delete } from "../../services/AdvertisingService";

const Index = (props) => {
    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        get();
    }, []);

    const get = () => {
        Get()
        .then(response => {
            setLoading(true);

            if(response.status === 200)
                setData(response.data);

            setLoading(false);
        })
        .catch(error => alert(error));
    }

    const remove = (id) => {
        const confirm = window.confirm("Confirma a exclusão?");
        
        if(confirm === true)
            Delete(parseInt(id))
            .then(response => {
                if(response.status === 204)
                    alert("Excluído com sucesso!");

                get();
            })
            .catch(error => alert(error));
    }

    const renderTable = (data) => {
        return (
          <>
            <div className="mb-3">
                <button className="btn btn-primary" onClick={() => props.history.push("/form-advertising")}>
                    <i className="fa fa-plus"></i> Novo Anúncio
                </button>
            </div>

            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                <tr>
                    <th>Marca</th>
                    <th>Modelo</th>
                    <th>Versão</th>
                    <th>Ano</th>
                    <th>Quilometragem</th>
                    <th>Observação</th>
                    <th>Ações</th>
                </tr>
                </thead>
                <tbody>
                {data.map(m =>
                    <tr key={m.id}>
                    <td>{m.marca}</td>
                    <td>{m.modelo}</td>
                    <td>{m.versao}</td>
                    <td>{m.ano}</td>
                    <td>{m.quilometragem}</td>
                    <td>{m.observacao}</td>
                    <td>
                        <button className="btn btn-danger mr-1" onClick={() => props.history.push("/form-advertising/" + m.id)}>
                            <i className="fa fa-edit"></i> Editar
                        </button>
                        <button className="btn btn-primary" onClick={() => remove(m.id)}>
                            <i className="fa fa-trash"></i> Excluir
                        </button>
                    </td>
                    </tr>
                )}
                </tbody>
            </table>
          </>
        );
      }

    return (<>
        {
            loading === true
            ? "Loading..."
            : renderTable(data)
        }
    </>);
}

export default Index;