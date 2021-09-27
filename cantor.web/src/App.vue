<template>
  <v-app>
    <header-bar />
    <v-main>
      <router-view />
    </v-main>
    <footer-bar />
  </v-app>
</template>

<script>
import HeaderBar from "@/shared/components/HeaderBar";
import FooterBar from "@/shared/components/FooterBar";
import { mapMutations } from "vuex";

export default {
  components: {
    FooterBar,
    HeaderBar
  },
  methods: {
    ...mapMutations("userModule", ["recallUserInfo"])
  },
  created() {
    this.recallUserInfo();
  }
};
</script>

<style></style>
