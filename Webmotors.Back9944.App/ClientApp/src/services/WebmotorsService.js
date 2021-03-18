import axios from "axios";

const http = axios.create({
    baseURL: "Services",
    timeout: 30000,
    headers: {"Content-type": "application/json"}
});

export const Makers = () => {
    http.get("Makers")
    .then(response => {
        if(response.status === 200)
            return response.data;
    })
    .catch(error => alert(error));
}

export const Models = (makerId) => {
    http.get("Models/" + parseInt(makerId))
    .then(response => {
        if(response.status === 200)
            return response.data;
    })
    .catch(error => alert(error));
}

export const Versions = (modelId) => {
    http.get("Versions/" + parseInt(modelId))
    .then(response => {
        if(response.status === 200)
            return response.data;
    })
    .catch(error => alert(error));
}

export const Vehicles = (pageIndex) => {
    http.get("Vehicles/" + parseInt(pageIndex))
    .then(response => {
        if(response.status === 200)
            return response.data;
    })
    .catch(error => alert(error));
}