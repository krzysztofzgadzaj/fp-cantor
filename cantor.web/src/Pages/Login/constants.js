export const FormValidationMessages = {
  InvalidMailAddressMessage: "Invalid mail address",
  InvalidPasswordMessage:
    "Password must contain minimum eight characters, at least one capital, one number and one special character",
  NoInformationMessage: "Information required"
};

export const FormValidationRegularExpressions = {
  MailAddressRegex: /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@(([[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,24}))$/,
  PasswordRegex: /^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$/
};
