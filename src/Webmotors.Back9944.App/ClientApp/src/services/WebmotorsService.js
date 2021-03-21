import axios from "axios";

const http = axios.create({
    baseURL: "Services",
    timeout: 30000,
    headers: {"Content-type": "application/json"}
});

export const Makers = async () => {
    return await http.get("Makers");
}

export const Models = async (makerId) => {
    return await http.get("Models/" + parseInt(makerId));
}

export const Versions = async (modelId) => {
    return await http.get("Versions/" + parseInt(modelId));
}

export const Vehicles = async (pageIndex) => {
    return await http.get("Vehicles/" + parseInt(pageIndex));
}