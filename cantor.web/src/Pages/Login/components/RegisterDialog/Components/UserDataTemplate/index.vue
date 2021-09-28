<template>
  <v-form ref="form" v-model="validated">
    <v-row>
      <v-col>
        <v-row>
          <v-col>
            <v-text-field
              class="mb-3"
              v-model="firstName"
              :rules="firstNameRules"
              label="First name"
              required
            ></v-text-field>
          </v-col>
          <v-col>
            <v-text-field
              class="mb-3"
              v-model="secondName"
              :rules="lastNameRules"
              label="Last name"
              required
            ></v-text-field>
          </v-col>
        </v-row>
        <v-text-field
          class="mb-3"
          v-model="login"
          :rules="loginRules"
          label="Login"
          required
        ></v-text-field>
        <v-text-field
          class="mb-3"
          v-model="emailAddress"
          :rules="mailRules"
          label="Email"
          required
        ></v-text-field>
        <v-text-field
          class="mb-3"
          v-model="password"
          :rules="passwordRules"
          label="Password"
          required
          type="password"
        ></v-text-field>
      </v-col>
    </v-row>
  </v-form>
</template>

<script>
import {
  FormValidationMessages,
  FormValidationRegularExpressions
} from "@/Pages/Login/constants";
import { mapActions } from "vuex";

export default {
  data: () => ({
    secondName: "",
    firstName: "",
    emailAddress: "",
    login: "",
    password: "",
    validated: false,
    firstNameRules: [v => !!v || FormValidationMessages.NoInformationMessage],
    lastNameRules: [v => !!v || FormValidationMessages.NoInformationMessage],
    loginRules: [v => !!v || FormValidationMessages.NoInformationMessage],
    passwordRules: [
      v => !!v || FormValidationMessages.NoInformationMessage,
      v =>
        FormValidationRegularExpressions.PasswordRegex.test(v) ||
        FormValidationMessages.InvalidPasswordMessage
    ],
    mailRules: [
      v => !!v || FormValidationMessages.NoInformationMessage,
      v =>
        FormValidationRegularExpressions.MailAddressRegex.test(v) ||
        FormValidationMessages.InvalidMailAddressMessage
    ]
  }),
  methods: {
    ...mapActions("userModule", ["signUp"]),
    async register() {
      const credentials = {
        login: this.login,
        password: this.password,
        emailAddress: this.emailAddress,
        firstName: this.firstName,
        secondName: this.secondName
      };
      return await this.signUp(credentials);
    },
    async saveUserData() {
      let response = await this.register();
      let userId = response.data;

      this.resetDialog();
      this.$emit("userDataSaved", userId);
    },
    resetDialog() {
      this.secondName = "";
      this.firstName = "";
      this.emailAddress = "";
      this.login = "";
      this.password = "";
      this.validated = false;
      this.$emit("dialogCleaned");
    }
  },
  watch: {
    validated: function() {
      this.$emit("userDataValidationChanged", this.validated);
    },
    SigningUpFinished: function() {
      if (this.SigningUpFinished === true) {
        this.saveUserData();
      }
    },
    dialogClosed: function () {
      if (this.dialogClosed === true) {
        this.resetDialog();
      }
    }
  },
  props: {
    SigningUpFinished: Boolean(false),
    dialogClosed: Boolean(false)
  }
};
</script>

<style scoped></style>
