import axios from "axios";
import vm from "@/main";
import store from "@/store";
import { DefaultErrorMessage, LocalStorageJwtKey } from "./constants";

const api = axios.create({
  baseURL: "http://localhost:5081/api"
});

function showExceptionMessage(error) {
  const message = error.response.data.Message
    ? error.response.data.Message
    : DefaultErrorMessage;
  vm.$snotify.error(message);
}

api.interceptors.request.use(
  config => {
    // ToDo: eventually omit the commit if ceratin request demands no overlay
    store.commit("requestModule/incrementPendingRequestCount");
    return config;
  },
  error => Promise.reject(error)
);

api.interceptors.response.use(
  response => {
    // ToDo: eventually omit the commit if ceratin request demands no overlay
    store.commit("requestModule/decrementPendingRequestCount");
    return response;
  },
  error => {
    // ToDo: eventually omit the commit if ceratin request demands no overlay
    store.commit("requestModule/decrementPendingRequestCount");
    // ToDo: logout if token expired
    // ToDo: handle error in specific way if needed
    return Promise.reject(error);
  }
);

const client = {
  async get(resource, params, handleError = true) {
    const token = localStorage.getItem(LocalStorageJwtKey);
    const config = {
      params,
      headers: {
        Authorization: `Bearer ${token}`
      }
    };
    try {
      return await api.get(resource, config);
    } catch (e) {
      if (handleError) {
        showExceptionMessage(e);
      } else {
        throw e;
      }
    }
  },
  async post(resource, data, params, handleError = true) {
    console.log(data);
    const token = localStorage.getItem(LocalStorageJwtKey);
    console.log(token);
    const config = {
      params,
      headers: {
        Authorization: `Bearer ${token}`
      }
    };
    try {
      console.log(resource);
      console.log(data);

      return await api.post(resource, data, config);
    } catch (e) {
      console.log(e);
      if (handleError) {
        showExceptionMessage(e);
      } else {
        throw e;
      }
    }
  },
  async put(resource, data, params, handleError = true) {
    const token = localStorage.getItem(LocalStorageJwtKey);
    const config = {
      params,
      headers: {
        Authorization: `Bearer ${token}`
      }
    };
    try {
      return await api.put(resource, data, config);
    } catch (e) {
      if (handleError) {
        showExceptionMessage(e);
      } else {
        throw e;
      }
    }
  },
  async delete(resource, params, handleError = true) {
    const token = localStorage.getItem(LocalStorageJwtKey);
    const config = {
      params,
      headers: {
        Authorization: `Bearer ${token}`
      }
    };
    try {
      const result = await api.delete(resource, config);
      return result;
    } catch (e) {
      if (handleError) {
        showExceptionMessage(e);
      } else {
        throw e;
      }
    }
  }
};

export default client;
