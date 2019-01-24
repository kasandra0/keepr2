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
    activeVault: {},
    userKeeps: [],
    activeKeep: {}
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
    },
    setActiveVault(state, vault) {
      state.activeVault = vault
    },
    setUserKeeps(state, keeps) {
      state.userKeeps = keeps
    },
    setActiveKeep(state, keep) {
      state.activeKeep = keep
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
    // ===================VAULT METHODS ====================
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
    createNewVault({ commit, dispatch }, newVault) {
      api.post('vaults/', newVault)
        .then(res => {
          console.log(res.data)
          dispatch('getAllVaults')
        })
        .catch(err => {
          console.log('Cannot post new vault')
        })
    },
    getKeepsByVaultId({ commit, dispatch }, vaultid) {
      let promises = [api.get('vaults/' + vaultid), api.get('vaultkeeps/' + vaultid)]
      Promise.all(promises)
        .then(res => {
          let vault = res[0].data
          vault.keeps = res[1].data
          console.log("vault", vault)
          commit("setActiveVault", vault)
        })
        .catch(err => {
          console.log('Cannot get keeps in vault')
        })
    },
    // ===================KEEP METHODS ====================
    getAllKeepsByUser({ commit, dispatch }) {
      api.get('keeps/user')
        .then(res => {
          commit('setUserKeeps', res.data)
        })
        .catch(err => {
          console.log('Cannot get all keeps by user')
        })
    },
    createNewKeep({ commit, dispatch }, newKeep) {
      api.post('keeps/', newKeep)
        .then(res => {
          console.log(res.data)
          dispatch('getAllKeepsByUser')
        })
        .catch(err => {
          console.log('Cannot create new keep')
        })
    },
    getKeepById({ commit, dispatch }, keepid) {
      api.get('keeps/' + keepid)
        .then(res => {
          console.log('keep', res.data)
          commit('setActiveKeep', res.data)
        })
        .catch(err => {
          console.log('Cannot get keep')
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
          // router.push({ name: 'home' })
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