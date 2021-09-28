import client from "@/shared/Http-client";
import { InvestmentPortfolioDto } from "@/shared/modules/InvestmentPortfolio/dto";

const service = {
  async createInvestmentPortfolio(data) {
    const resource = "/cantor";
    console.log(data);
    const result = await client.post(resource, data);

    console.log(result);
    return result;
  },
  async getInvestmentPortfolio(userId) {
    const resource = "cantor/" + userId + "/balance";
    console.log(resource);
    const result = await client.get(resource);
    const balance = result.data
      ? new InvestmentPortfolioDto(result.data)
      : null;

    return balance;
  }
};

export default service;
