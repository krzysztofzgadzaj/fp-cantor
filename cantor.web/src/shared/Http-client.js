import axios from "axios";
import vm from "@/main";
import { DefaultErrorMessage, LocalStorageJwtKey } from "./constants";

const api = axios.create({
  baseURL: "http://localhost:5080/api"
});

function showExceptionMessage(error) {
  const message = error.response.data.Message
    ? error.response.data.Message
    : DefaultErrorMessage;
  vm.$snotify.error(message);
}

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
    const token = localStorage.getItem(LocalStorageJwtKey);
    const config = {
      params,
      headers: {
        Authorization: `Bearer ${token}`
      }
    };
    try {
      return await api.post(resource, data, config);
    } catch (e) {
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
