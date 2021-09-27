import Vue from "vue";
import Router from "vue-router";
import loginRoutes from "@/Pages/Login/router";
import homeRoutes from "@/Pages/Home/router";

Vue.use(Router);

const routes = [loginRoutes, homeRoutes];

const router = new Router({
    routes: routes
});

export default router;
