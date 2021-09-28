export class InvestmentPortfolioDto {
  constructor(data = {}) {
    this.gbpAmount = data.gbpAmount;
    this.eurAmount = data.eurAmount;
    this.usdAmount = data.usdAmount;
    this.czkAmount = data.czkAmount;
    this.plnAmount = data.plnAmount;
    this.chfAmount = data.chfAmount;
    this.rubAmount = data.rubAmount;
    this.userId = data.userId;
  }
}
