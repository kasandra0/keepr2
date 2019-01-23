import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "http://localhost:5000/account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "http://localhost:5000/api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    publicKeeps: [],
    vaults: [],
    activeVault: {}
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setPublicKeeps(state, publicKeeps) {
      state.publicKeeps = publicKeeps
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    }
  },
  actions: {
    getAllPublicKeeps({ commit, dispatch }) {
      api.get('keeps/')
        .then(res => {
          console.log('Public Keeps', res.data)
          commit("setPublicKeeps", res.data)
        })
        .catch(err => {
          console.log('Cannot get public keeps')
        })
    },
    getAllVaults({ commit, dispatch }) {
      api.get('vaults/')
        .then(res => {
          console.log('user vaults', res.data)
          commit("setVaults", res.data)
        })
        .catch(err => {
          console.log('Cannot get vaults')
        })
    },
    getKeepsByVaultId({ commit, dispatch }, vaultid) {
      api.get('vaultkeeps/' + vaultid)
        .then(res => {
          console.log('keeps in vault', res.data)
        })
        .catch(err => {
          console.log('Cannot get keeps in vault')
        })
    },
    // -------------- AUTH METHODS ------
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    }
    // -----------------------------------
  }
})