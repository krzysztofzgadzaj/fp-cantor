import Vue from "vue";
import Vuex from "vuex";

import userModule from "@/shared/modules/User/module";
import requestModule from "@/shared/modules/Request/module";

Vue.use(Vuex);

const modules = {
  userModule,
  requestModule
};

const store = new Vuex.Store({
  modules: modules
});

export default store;
