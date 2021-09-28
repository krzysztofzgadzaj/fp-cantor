import service from "./service";

const state = {};

const actions = {
  async createInvestmentPortfolio(state, data) {
    await service.createInvestmentPortfolio(data);
  },
  async getInvestmentPortfolio(state, userId) {
    return await service.getInvestmentPortfolio(userId);
  }
};

const module = {
  namespaced: true,
  state,
  actions
};

export default module;
