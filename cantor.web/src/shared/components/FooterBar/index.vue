<template>
  <v-footer app dark :color="Theme.containerBackgroundColor" padless>
    <v-row justify="center">
      <v-card-text class="text-center">
        <strong class="detail-label">
          Exchange office, created for Future Processing
        </strong>
      </v-card-text>
    </v-row>
  </v-footer>
</template>

<script>
import { Theme } from "@/shared/constants";

export default {
  name: "FooterBar",
  data: () => ({
    Theme
  })
};
</script>
