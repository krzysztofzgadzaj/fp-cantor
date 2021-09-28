<template>
  <v-form>
    <v-row align="center" justify="center">
      <v-select
        style="width: 100px"
        class="ma-4 mb-0"
        v-model="currentCurrency"
        :items="currencyItems"
        solo
        label="Currency"
      />
      <v-text-field
        style="width: 100px"
        solo
        class="ma-4 mb-0"
        type="number"
        v-model="currencyAmount"
        label="Currency amount"
      />
    </v-row>
    <v-row align="center" justify="center">
      <v-col cols="7">
        <v-card>
          <v-data-table
            class="mt-0 mb-0"
            height="200"
            hide-default-footer
            :items="selectedCurrencies"
            :headers="CurrenciesHeaders"
          >
            <template v-slot:item.Remove="{ item }">
              <v-btn
                small
                color="primary"
                v-on:click="removeCurrencyFromList(item)"
              >
                Remove
              </v-btn>
            </template>
          </v-data-table>
        </v-card>
      </v-col>
      <v-col>
        <v-btn
          class="ma-4"
          v-bind:disabled="!addCurrencyButtonEnabled"
          v-on:click="addCurrency"
          color="primary"
          >Add currency</v-btn
        >
      </v-col>
    </v-row>
  </v-form>
</template>

<script>
import { Currencies, CurrenciesHeaders } from "./constants";
import { mapActions } from "vuex";

export default {
  data: () => ({
    Currencies,
    CurrenciesHeaders,
    currentCurrency: null,
    currencyAmount: null,
    currencyItems: Currencies.map(obj => obj),
    selectedCurrencies: []
  }),
  methods: {
    ...mapActions("investmentPortfolioModule", ["createInvestmentPortfolio"]),
    addCurrency() {
      this.selectedCurrencies.push({
        Currency: this.currentCurrency,
        Amount: this.currencyAmount
      });

      let indexToRemove = this.currencyItems.indexOf(this.currentCurrency);
      this.currencyItems.splice(indexToRemove, 1);
      this.currentCurrency = null;
      this.currencyAmount = null;
    },
    removeCurrencyFromList(item) {
      let indexToRemove = this.selectedCurrencies.indexOf(item);
      this.selectedCurrencies.splice(indexToRemove, 1);

      this.currencyItems.push(item.Currency);
    },
    prepareData() {
      return {
        UserId: this.userId,
        GbpAmount: this.getCurrencyAmount("GBP"),
        EurAmount: this.getCurrencyAmount("EUR"),
        UsdAmount: this.getCurrencyAmount("USD"),
        CzkAmount: this.getCurrencyAmount("CZK"),
        PlnAmount: this.getCurrencyAmount("PLN"),
        RubAmount: this.getCurrencyAmount("RUB"),
        ChfAmount: this.getCurrencyAmount("CHF")
      };
    },
    getCurrencyAmount(currencyName) {
      let currencyList = this.selectedCurrencies.filter(
        x => x.Currency === currencyName
      );

      if (currencyList.length === 0) {
        return 0;
      } else {
        return currencyList[0].Amount;
      }
    },
    async saveInvestmentPortfolio() {
      let command = this.prepareData();

      await this.createInvestmentPortfolio(command);
      this.resetDialog();
      this.$emit("dataSaved");
    },
    resetDialog() {
      this.currentCurrency = null;
      this.currencyAmount = null;
      this.currencyItems.length = 0;
      this.currencyItems = Currencies.map(obj => obj);
      this.selectedCurrencies.splice(0, this.selectedCurrencies.length);
      this.$emit("dialogCleaned");
    }
  },
  computed: {
    addCurrencyButtonEnabled() {
      return this.currentCurrency !== null && this.currencyAmount !== null;
    }
  },
  watch: {
    investmentSavingStarted: function() {
      if (this.investmentSavingStarted === true) {
        this.saveInvestmentPortfolio();
      }
    },
    dialogClosed: function () {
      if (this.dialogClosed === true) {
        this.resetDialog();
      }
    }
  },
  props: {
    userId: String(),
    investmentSavingStarted: Boolean(false),
    dialogClosed: Boolean(false)
  }
};
</script>

<style scoped></style>
