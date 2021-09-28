import Vue from "vue";
import App from "./App.vue";
import vuetify from "./plugins/vuetify";
import router from "./router";
import Loading from "vue-loading-overlay";
import store from "./store";
import BootstrapVue from "bootstrap-vue";

import "@/assets/styles/index.scss";
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
import "vue-loading-overlay/dist/vue-loading.css";
import "vue-snotify/styles/material.css";
import "material-design-icons-iconfont/dist/material-design-icons.css";

Vue.config.productionTip = false;

Vue.use(Loading);
Vue.use(BootstrapVue);

const vue = new Vue({
  vuetify,
  router,
  store,
  render: h => h(App)
}).$mount("#app");

export default vue;
