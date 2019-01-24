import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import Dashboard from './views/Dashboard.vue'
// @ts-ignore
import Vault from './views/Vault.vue'
// @ts-ignore
import Keep from './views/Keep.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/dashboard',
      name: 'dashboard',
      component: Dashboard
    }, {
      path: '/vault/:vaultid',
      name: 'vault',
      component: Vault
    },
    {
      path: '/keeps/:keepid',
      name: 'keep',
      component: Keep
    }
  ]
})
