import userService from "./service";
import { LocalStorageUserKey, LocalStorageJwtKey } from "@/shared/constants";

const state = {
  user: null
};

const getters = {
  user: state => state.user
};

const actions = {
  async signIn({ commit }, credentials) {
    const authenticationResult = await userService.signIn(credentials);
    commit("setAuthenticationResults", authenticationResult);
  },
  async signUp(state, credentials) {
    console.log("dupa3");
    await userService.signUp(credentials);
  }
};

const mutations = {
  setAuthenticationResults(state, authenticationResults) {
    if (authenticationResults.isAuthenticated) {
      localStorage.setItem(
        LocalStorageUserKey,
        JSON.stringify(authenticationResults.tokenOwner)
      );
      localStorage.setItem(
        LocalStorageJwtKey,
        authenticationResults.jsonWebToken
      );
      state.user = authenticationResults.tokenOwner;
    }
  },
  recallUserInfo(state) {
    const user = JSON.parse(localStorage.getItem(LocalStorageUserKey));
    if (user) {
      state.user = user;
    }
  },
  signOut(state) {
    localStorage.removeItem(LocalStorageJwtKey);
    localStorage.removeItem(LocalStorageUserKey);
    state.user = null;
  }
};

const module = {
  namespaced: true,
  state,
  getters,
  actions,
  mutations
};

export default module;
