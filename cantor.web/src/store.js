import Vue from "vue";
import Vuex from "vuex";

import userModule from "@/shared/modules/User/module";
import investmentPortfolioModule from "@/shared/modules/InvestmentPortfolio/module";

Vue.use(Vuex);

const modules = {
  userModule,
  investmentPortfolioModule
};

const store = new Vuex.Store({
  modules: modules
});

export default store;
