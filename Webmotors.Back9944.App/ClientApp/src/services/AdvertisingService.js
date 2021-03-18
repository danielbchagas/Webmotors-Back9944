import axios from "axios";

export const http = axios.create({
    baseURL: "Advertising",
    timeout: 30000,
    headers: {"Content-type": "application/json"}
});

export const Get = () => {
    http.get("Get")
    .then(response => {
        if(response.status === 200)
            return response.data;
    })
    .catch(error => alert(error));
}

export const GetById = (id) => {
    http.get("GetById/" + parseInt(id))
    .then(response => {
        if(response.status === 200)
            return response.data;
    })
    .catch(error => alert(error));
}

export const Create = (data) => {
    http.post("Create/", data)
    .then(response => {
        if(response.status === 200)
            return response;
    })
    .catch(error => alert(error));
}

export const Update = (data) => {
    http.put("Update/", data)
    .then(response => {
        if(response.status === 200)
            return response;
    })
    .catch(error => alert(error));
}

export const Delete = (id) => {
    http.delete("Delete/" + parseInt(id))
    .then(response => {
        if(response.status === 200)
            return response;
    })
    .catch(error => alert(error));
}