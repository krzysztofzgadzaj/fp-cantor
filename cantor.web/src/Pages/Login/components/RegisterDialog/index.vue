<template>
  <v-row justify="center">
    <v-dialog v-model="visible" persistent max-width="600px">
      <v-card>
        <v-card-title>
          <span class="text-h5">Register</span>
        </v-card-title>
        <v-card-text>
          <v-form v-model="validated">
            <v-row>
              <v-col cols="12" md="6" sm="3">
                <v-text-field
                  v-model="name"
                  :rules="firstNameRules"
                  label="First name"
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12" md="6" sm="6">
                <v-text-field
                  v-model="lastName"
                  :rules="lastNameRules"
                  label="Last name"
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-text-field
                  v-model="login"
                  :rules="loginRules"
                  label="Login"
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-text-field
                  v-model="mailAddress"
                  :rules="mailRules"
                  label="Email"
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-text-field
                  v-model="password"
                  :rules="passwordRules"
                  label="Password"
                  required
                  type="password"
                ></v-text-field>
              </v-col>
            </v-row>
          </v-form>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text v-on:click="closeDialog">
            Close
          </v-btn>
          <v-btn
            v-bind:disabled="!validated"
            color="blue darken-1"
            text
            v-on:click="register"
          >
            Save
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>

<script>
import { Theme } from "@/shared/constants";
import { mapActions } from "vuex";
import {
  FormValidationMessages,
  FormValidationRegularExpressions
} from "@/Pages/Login/constants";

export default {
  data: () => ({
    Theme,
    validated: false,
    lastName: "",
    name: "",
    mailAddress: "",
    login: "",
    password: "",
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
      console.log("dupa1");
      const credentials = {
        login: this.login,
        password: this.password,
        mailAddress: this.mailAddress,
        name: this.name,
        lastName: this.lastName
      };
      console.log("dupa2");
      await this.signUp(credentials);
      this.close();
    },
    closeDialog() {
      this.$emit("registerDialogClosed");
    }
  },
  props: {
    visible: Boolean(false)
  }
};
</script>

<style scoped></style>
