<template>
  <v-app-bar app clipped-left :color="Theme.mainBackgroundColor">
    <v-toolbar-title class="headline">
      <span class="app-title ml-2">Exchange office</span>
    </v-toolbar-title>
    <v-spacer />
    <v-img max-width="35" max-height="35" :src="Logo" />
  </v-app-bar>
</template>

<script>
import { Theme } from "@/shared/constants";
import Logo from "@/assets/logo.png";

export default {
  data: () => ({
    Theme,
    Logo
  })
};
</script>

<style lang="scss" scoped>
@import "@/assets/styles/_colors.scss";
.app-title {
  font-size: 26px;
  color: $white;
}
.hamburger-menu {
  min-width: 48px;
  top: 65px;
  left: 0px;
  transform-origin: left top;
  z-index: 8;
}
</style>
