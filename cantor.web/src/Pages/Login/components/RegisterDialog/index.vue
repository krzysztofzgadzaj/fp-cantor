<template>
  <v-row justify="center">
    <v-dialog v-model="visible" persistent max-width="600">
      <v-card>
        <v-toolbar class="mb-6" color="primary" dark flat>
          <v-row justify="space-between">
            <v-col>
              <v-toolbar-title style="font-size: 30px"
                >Register</v-toolbar-title
              >
            </v-col>
            <v-col align="right">
              <v-btn icon color="white darken-1" text @click="closeDialog">
                <v-icon>mdi-close</v-icon>
              </v-btn>
            </v-col>
          </v-row>
          <template v-slot:extension>
            <v-tabs>
              <v-tab
                style="color: white; margin: 0"
                v-for="tab in Tabs"
                v-bind:key="tab.key"
                v-on:click="changeSelectedDataTab(tab.key)"
              >
                {{ tab.name }}
              </v-tab>
            </v-tabs>
          </template>
        </v-toolbar>
        <v-card-text>
          <div v-show="selectedDataKey === TabKeys.UserData">
            <user-template
              v-on:userDataValidationChanged="changeSaveButtonAccessibility"
              v-on:userDataSaved="saveInvestmentPortfolioData"
              v-bind:signing-up-finished="signingUpFinished"
              v-bind:dialog-closed="userDialogClosed"
              v-on:dialogCleaned="resetUserMechanics"
            />
          </div>
          <div v-show="selectedDataKey === TabKeys.InvestmentPortfolioData">
            <investment-portfolio-template
              v-bind:user-id="newUserId"
              v-bind:investment-saving-started="investmentSavingStarted"
              v-on:dataSaved="closeDialog"
              v-bind:dialog-closed="investmentDialogClosed"
              v-on:dialogCleaned="resetInvestmentMechanics"
            />
          </div>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text v-on:click="closeDialog">
            Close
          </v-btn>
          <v-btn
            v-bind:disabled="!userDataValidated"
            color="blue darken-1"
            text
            v-on:click="saveUserData"
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
import { Tabs, TabKeys } from "./constants";
import InvestmentPortfolioTemplate from "./Components/InvestmentPortfolioDataTemplate";
import UserTemplate from "./Components/UserDataTemplate";

export default {
  data: () => ({
    Theme,
    Tabs,
    TabKeys,
    selectedDataKey: TabKeys.UserData,
    userDataValidated: false,
    signingUpFinished: false,
    investmentSavingStarted: false,
    newUserId: null,
    userDialogClosed: false,
    investmentDialogClosed: false
  }),
  components: {
    InvestmentPortfolioTemplate,
    UserTemplate
  },
  methods: {
    async saveUserData() {
      this.signingUpFinished = true;
    },
    saveInvestmentPortfolioData(userId) {
      this.signingUpFinished = false;
      this.newUserId = userId;
      this.investmentSavingStarted = true;
    },
    changeSelectedDataTab(newDataTabKey) {
      this.selectedDataKey = newDataTabKey;
    },
    closeDialog() {
      this.resetDialog();
      this.$emit("registerDialogClosed");
    },
    changeSaveButtonAccessibility(validated) {
      this.userDataValidated = validated;
    },
    resetDialog() {
      this.selectedDataKey = TabKeys.UserData;
      this.userDataValidated = false;
      this.signingUpFinished = false;
      this.investmentSavingStarted = false;
      this.newUserId = null;
      this.userDialogClosed = true;
      this.investmentDialogClosed = true;
    },
    resetUserMechanics() {
      this.userDialogClosed = false;
    },
    resetInvestmentMechanics() {
      this.investmentDialogClosed = false;
    }
  },
  props: {
    visible: Boolean(false)
  },
  mounted() {
    this.currencyItems = this.Currencies;
  }
};
</script>

<style scoped></style>
