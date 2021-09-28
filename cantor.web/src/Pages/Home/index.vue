<template>
  <v-row>
    <v-col class="ma-5">
      <v-card>
        <v-card-title>
          <h3 class="m-0">Currencies</h3>
        </v-card-title>
        <v-data-table
          :headers="CurrenciesHeaders"
          :items="currencyTableItems"
          hide-default-footer
          disable-pagination
          class="elevation-1"
          height="300"
        >
          <template v-slot:item.Actions="{ item }">
            <v-btn
              small
              color="primary"
              v-on:click="openBuyCurrencyDialog(item)"
            >
              Buy
            </v-btn>
          </template>
        </v-data-table>
      </v-card>
    </v-col>
    <v-col class="ma-5">
      <v-card>
        <v-card-title>
          <h3 class="m-0">My wallet</h3>
        </v-card-title>
        <v-data-table
          :headers="MyWalletHeaders"
          :items="userWalletItems"
          hide-default-footer
          disable-pagination
          class="elevation-1"
          height="300"
        >
          <template v-slot:item.Actions="{ item }">
            <v-btn small color="primary" v-on:click="temp(item)">
              Sell
            </v-btn>
          </template>
        </v-data-table>
      </v-card>
      <v-card class="mt-4">
        <v-card-title> Available PLN: {{ availablePln }} </v-card-title>
      </v-card>
      <buy-currency-dialog
          v-bind:visible="buyCurrencyDialogVisible"
          v-bind:current-currency-to-buy="currentCurrencyToBuy"
          v-bind:pln-amount="availablePln"
          v-on:closeDialog="closeBuyCurrencyDialog"
      />
      <sell-currency-dialog />
    </v-col>
  </v-row>
</template>

<script>
import {
  CurrenciesHeaders,
  MyWalletHeaders,
  WebSocketAddress
} from "@/Pages/Home/constants";
import { mapActions, mapGetters } from "vuex";
import BuyCurrencyDialog from "./Components/BuyCurrencyDialog";
import SellCurrencyDialog from "./Components/SellCurrencyDialog";

export default {
  data: () => ({
    socket: null,
    CurrenciesHeaders,
    MyWalletHeaders,
    buyCurrencyDialogVisible: false,
    availablePln: 0,
    currencyTableItems: [],
    userWalletItems: [],
    userInvestments: [],
    userInvestmentPortfolio: null,
    currentCurrencyToBuy: null
  }),
  components: {
    BuyCurrencyDialog,
    SellCurrencyDialog
  },
  methods: {
    ...mapActions("investmentPortfolioModule", ["getInvestmentPortfolio"]),
    openBuyCurrencyDialog(item) {
      console.log(item);
      this.currentCurrencyToBuy = item;
      this.buyCurrencyDialogVisible = true;
    },
    closeBuyCurrencyDialog() {
      this.buyCurrencyDialogVisible = false;
    },
    refreshCurrencyRates(request) {
      let currencyRates = JSON.parse(request.data);
      this.currencyTableItems.length = 0;

      this.refreshCurrencyTableItems(currencyRates.Items);
      this.refreshUserWalletItems(currencyRates.Items);
    },
    refreshCurrencyTableItems(items) {
      items.forEach(x =>
        this.currencyTableItems.push({
          Currency: x.Code,
          Unit: x.Unit,
          Value: x.PurchasePrice.toFixed(2)
        })
      );
    },
    refreshUserWalletItems(items) {
      this.userInvestments.forEach(x =>
        this.userWalletItems.push({
          Currency: x.Code,
          UnitPrice: items
            .filter(y => y.Code === x.Code)[0]
            .SellPrice.toFixed(2),
          Amount: x.Amount,
          Value: (
            x.Amount * items.filter(y => y.Code === x.Code)[0].SellPrice
          ).toFixed(2)
        })
      );
    },
    mapInvestmentPortfolio(investmentPortfolio) {
      this.availablePln = investmentPortfolio.plnAmount;
      if (investmentPortfolio.gbpAmount > 0) {
        this.userInvestments.push({
          Code: "CHF",
          Amount: investmentPortfolio.gbpAmount
        });
      }
      if (investmentPortfolio.eurAmount > 0) {
        this.userInvestments.push({
          Code: "PGB",
          Amount: investmentPortfolio.eurAmount
        });
      }
      if (investmentPortfolio.usdAmount > 0) {
        this.userInvestments.push({
          Code: "USD",
          Amount: investmentPortfolio.usdAmount
        });
      }
      if (investmentPortfolio.czkAmount > 0) {
        this.userInvestments.push({
          Code: "CZK",
          Amount: investmentPortfolio.czkAmount
        });
      }
      if (investmentPortfolio.chfAmount > 0) {
        this.userInvestments.push({
          Code: "CHF",
          Amount: investmentPortfolio.chfAmount
        });
      }
      if (investmentPortfolio.rubAmount > 0) {
        this.userInvestments.push({
          Code: "RUB",
          Amount: investmentPortfolio.rubAmount
        });
      }
    }
  },
  computed: {
    ...mapGetters("userModule", ["user"])
  },
  async mounted() {
    let investmentPortfolio = await this.getInvestmentPortfolio(this.user.id);
    this.userInvestmentPortfolio = investmentPortfolio;
    this.mapInvestmentPortfolio(investmentPortfolio);

    this.socket = new WebSocket(WebSocketAddress);
    this.socket.onmessage = this.refreshCurrencyRates;
  }
};
</script>

<style scoped></style>
