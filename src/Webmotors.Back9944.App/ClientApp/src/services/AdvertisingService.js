import axios from "axios";

export const http = axios.create({
    baseURL: "Advertising",
    // timeout: 30000,
    headers: {"Content-type": "application/json"}
});

export const Get = async () => {
    return await http.get("Get");
}

export const GetById = async (id) => {
    return await http.get("GetById/" + parseInt(id));
}

export const Create = async (data) => {
    return await http.post("Create/", data);
}

export const Update = async (data) => {
    return await http.put("Update/", data);
}

export const Delete = async (id) => {
    return await http.delete("Delete/" + parseInt(id));
}