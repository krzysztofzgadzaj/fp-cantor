<template>
  <v-row justify="center">
    <v-dialog v-model="visible" persistent max-width="600px">
      <v-card>
        <v-card-title>
          <span class="text-h5">Buy currency</span>
        </v-card-title>
        <v-card-text>
          <v-row>
            <v-slider
              v-model="currencyAmount"
              class="align-center"
              :max="maxCurrencyAmountToBuy"
              :min="0"
              hide-details
            >
              <template v-slot:append>
                <v-text-field
                  v-model="currencyAmount"
                  class="mt-0 pt-0"
                  hide-details
                  single-line
                  type="number"
                  style="width: 60px"
                ></v-text-field>
              </template>
            </v-slider>
          </v-row>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="closeDialog">
            Close
          </v-btn>
          <v-btn color="blue darken-1" text @click="dialog = false">
            Save
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>

<script>
export default {
  data: () => ({
    currencyAmount: 1
  }),
  props: {
    visible: Boolean(false),
    currentCurrencyToBuy: null,
    plnAmount: null
  },
  methods: {
    closeDialog() {
      this.$emit("closeDialog");
    }
  },
  computed: {
    maxCurrencyAmountToBuy() {
      return this.plnAmount / this.currentCurrencyToBuy?.Value;
    }
  }
};
</script>

<style scoped></style>
