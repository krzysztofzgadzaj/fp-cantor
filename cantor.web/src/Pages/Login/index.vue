<template>
  <v-row justify="center">
    <v-col cols="4">
      <section class="text-center isolated-top">
        <h6 class="title">Sign in</h6>
        <p class="body-1 text-muted subtitle">
          Enter your credentials and then click the "Sign in" button
        </p>
        <v-form v-model="validated">
          <v-row justify="center" class="mb-5">
            <v-text-field
              class="form-field mx-2"
              label="Login"
              v-model="login"
              :rules="credentialRules"
            />
            <v-text-field
              class="form-field mx-2"
              label="Password"
              type="password"
              v-model="password"
              :rules="credentialRules"
            />
          </v-row>
        </v-form>
        <v-row justify="center" class="isolated-top">
          <v-btn
            :color="Theme.highlightColor"
            class="white--text mx-3 sign-in-button"
            v-bind:disabled="!validated"
            >SIGN IN</v-btn
          >
          <v-btn
            :color="Theme.highlightColor"
            class="white--text mx-3 sign-in-button"
            v-on:click="changeRegisterDialogVisibility(true)"
            >SIGN UP</v-btn
          >
        </v-row>
      </section>
      <register-dialog
        v-bind:visible="registerDialogVisible"
        v-on:registerDialogClosed="changeRegisterDialogVisibility(false)"
      />
    </v-col>
  </v-row>
</template>

<script>
import { Theme } from "@/shared/constants";
import RegisterDialog from "./components/RegisterDialog/index";
import { FormValidationMessages } from "@/Pages/Login/constants";

export default {
  data: () => ({
    Theme,
    login: null,
    password: null,
    registerDialogVisible: false,
    validated: false,
    credentialRules: [v => !!v || FormValidationMessages.NoInformationMessage]
  }),
  methods: {
    changeRegisterDialogVisibility(visible) {
      this.registerDialogVisible = visible;
    }
  },
  components: {
    RegisterDialog
  }
};
</script>

<style scoped></style>
