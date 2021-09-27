export class AuthenticationResultsDto {
  constructor(data = {}) {
    this.isAuthenticated = data.isAuthenticated;
    this.jsonWebToken = data.jsonWebToken;
    this.tokenOwner = data.tokenOwner;
  }
}
