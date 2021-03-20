import React from "react";

const ResumeCard = ({data}) => {
    return (
        <div className="card mb-3">
            <div className="card-body">
                <h5>Resumo do anúncio:</h5>
                
                <div><strong>Marca:</strong> {data.marca}</div>
                <div><strong>Modelo:</strong> {data.modelo}</div>
                <div><strong>Versão:</strong> {data.versao}</div>
                <div><strong>Ano:</strong> {data.ano}</div>
                <div><strong>Quilometragem:</strong> {data.quilometragem}</div>
                <div><strong>Observações:</strong> {data.observacao}</div>
            </div>
        </div>
    );
}

export default ResumeCard;