import Vue from "vue";
import Router from "vue-router";
import { LocalStorageUserKey } from "@/shared/constants";
import loginRoutes from "@/Pages/Login/router";
import homeRoutes from "@/Pages/Home/router";

Vue.use(Router);

const routes = [loginRoutes, homeRoutes];

const router = new Router({
  routes: routes
});

router.beforeEach((to, from, next) => {
  if (to.path !== "/login") {
    if (localStorage.getItem(LocalStorageUserKey)) {
      if (to.path === "/") {
        next("home");
      }
      next();
    } else {
      next("login");
    }
  } else {
    next();
  }
});

export default router;
