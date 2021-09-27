import client from "@/shared/Http-client";
import vm from "@/main";
import { AuthenticationResultsDto } from "./dto";
import {
  UnsuccessfulAuthenticationMessage,
  UserCreatedMessage
} from "./constants";

const service = {
  async signIn(credentials) {
    try {
      const resource = "/authentication";
      const result = await client.post(resource, credentials, null, false);
      return new AuthenticationResultsDto(result.data);
    } catch (e) {
      const message =
        e.data && e.data.message
          ? e.data.message
          : UnsuccessfulAuthenticationMessage;
      vm.$snotify.error(message);
      return new AuthenticationResultsDto();
    }
  },
  async signUp(credentials) {
    console.log(credentials);
    const resource = "/user";
    const response = await client.post(resource, credentials);
    console.log("dupa5");
    const isCreated =
      response && (response.status === 200 || response.status === 201);
    if (isCreated) {
      vm.$snotify.success(UserCreatedMessage);
    }
  }
};

export default service;
