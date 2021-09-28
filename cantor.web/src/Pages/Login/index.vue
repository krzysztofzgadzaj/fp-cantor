<template>
  <v-container fill-height fluid>
    <v-row class="mb-16" align="center" justify="center">
      <v-col cols="5">
        <section class="text-center isolated-top">
          <h3>Sign in</h3>
          <p class="body-1 text-muted subtitle mb-5">
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
              v-on:click="singInUser"
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
  </v-container>
</template>

<script>
import { Theme } from "@/shared/constants";
import RegisterDialog from "./components/RegisterDialog/index";
import { FormValidationMessages } from "@/Pages/Login/constants";
import {mapActions, mapGetters} from "vuex";

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
    ...mapActions("userModule", ["signIn"]),
    changeRegisterDialogVisibility(visible) {
      this.registerDialogVisible = visible;
    },
    async singInUser() {
      await this.signIn({
        login: this.login,
        password: this.password
      });
      if (this.user) {
        await this.$router.push({
          name: "home"
        });
      }
    }
  },
  computed: {
    ...mapGetters("userModule", ["user"])
  },
  components: {
    RegisterDialog
  }
};
</script>

<style scoped></style>
